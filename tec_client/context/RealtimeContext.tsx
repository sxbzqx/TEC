"use client";

import React, {
  createContext,
  useContext,
  useEffect,
  useMemo,
  useRef,
  useState,
} from "react";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { App } from "antd";
import Cookies from "js-cookie";
import { useQueryClient } from "@tanstack/react-query";
import { usePathname, useRouter } from "next/navigation";
import { refreshAccessToken } from "@/app/api/api";
import { authService } from "@/services/authService";
import { adminUserKeys } from "@/services/adminUserService";
import { useAuth } from "@/hooks/useAuth";
import { useLocale } from "@/context/LocaleContext";
import { hubUrl } from "@/utils/config";
import { decodeAccessToken } from "@/utils/jwt";
import { invalidateTopic, isPathAllowed } from "@/utils/realtime";
import type { AdminUserDetail, AdminUserRow } from "@/types/adminUser";

export type RealtimeStatus = "connecting" | "connected" | "reconnecting" | "disconnected";

interface RealtimeContextType {
  status: RealtimeStatus;
}

interface AuthChangedPayload {
  reason: "role" | "profile" | "stale";
  role?: string | null;
}

interface ForceLogoutPayload {
  reason: "banned" | "sessions" | "password";
}

interface PresencePayload {
  userId: number;
  online: boolean;
}

const RealtimeContext = createContext<RealtimeContextType>({ status: "disconnected" });

export const useRealtime = () => useContext(RealtimeContext);

const RETRY_DELAYS = [0, 2000, 5000, 10000, 30000];
const START_RETRY_MS = 5000;

export const RealtimeProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const queryClient = useQueryClient();
  const router = useRouter();
  const pathname = usePathname();
  const { notification } = App.useApp();
  const { t } = useLocale();
  const { auth, refreshAuth } = useAuth();

  const [status, setStatus] = useState<RealtimeStatus>("disconnected");

  // Обработчики живут в долгоживущем подключении — держим в ref всегда свежие значения,
  // чтобы не пересоздавать подключение при каждой смене пути, языка и т.п.
  const latest = useRef({ t, router, pathname, notification, refreshAuth, loginName: auth.loginName });
  useEffect(() => {
    latest.current = { t, router, pathname, notification, refreshAuth, loginName: auth.loginName };
  });

  useEffect(() => {
    let disposed = false;
    let retryTimer: ReturnType<typeof setTimeout> | undefined;
    let hadFailure = false;

    const connection = new HubConnectionBuilder()
      .withUrl(hubUrl, {
        accessTokenFactory: async () => {
          const token = Cookies.get("accessToken");
          if (token && !decodeAccessToken(token).isExpired) return token;

          // Гость подключается без токена. Но если пользователь залогинен, а токен протух
          // (вкладка простояла > 30 минут), берём свежий, иначе соединение станет анонимным.
          if (!latest.current.loginName) return "";
          try {
            return await refreshAccessToken();
          } catch {
            return "";
          }
        },
      })
      .withAutomaticReconnect(RETRY_DELAYS)
      .configureLogging(LogLevel.Warning)
      .build();

    // ── Данные изменились ───────────────────────────────────────────────
    connection.on("DataChanged", (topic: string) => invalidateTopic(queryClient, topic));

    // ── Кто-то вошёл / вышел (только админам) ───────────────────────────
    connection.on("PresenceChanged", ({ userId, online }: PresencePayload) => {
      queryClient.setQueryData<AdminUserRow[]>(adminUserKeys.list, (old) =>
        old?.map((u) => (u.id === userId ? { ...u, isOnline: online } : u)),
      );
      queryClient.setQueryData<AdminUserDetail>(adminUserKeys.one(userId), (old) =>
        old ? { ...old, isOnline: online } : old,
      );
    });

    // ── Изменились мои права / профиль ──────────────────────────────────
    connection.on("AuthChanged", async ({ reason, role }: AuthChangedPayload) => {
      try {
        // Новый токен несёт новую роль: бэкенд берёт её из БД при refresh.
        await refreshAccessToken();
        await latest.current.refreshAuth(true);
      } catch {
        return; // сессия недействительна — дальше разберётся axios/middleware
      }

      const actualRole = decodeAccessToken(Cookies.get("accessToken")).role;
      const { t, notification, router, pathname } = latest.current;

      if (reason === "role") {
        notification.info({ message: `${t("rtRoleChanged")} ${role ?? actualRole ?? ""}` });
      } else if (reason === "profile") {
        notification.info({ message: t("rtProfileChanged") });
      }

      if (actualRole && !isPathAllowed(pathname, actualRole)) {
        router.replace("/forbidden");
      } else {
        router.refresh(); // серверные компоненты и middleware увидят новый токен
      }

      // Соединение было открыто со старым токеном (stale) — переподключаем с новым,
      // чтобы сервер выдал правильные группы.
      if (reason === "stale" && !disposed) {
        await connection.stop();
        await start();
      }
    });

    // ── Меня вышвырнули ─────────────────────────────────────────────────
    connection.on("ForceLogout", ({ reason }: ForceLogoutPayload) => {
      const { t, notification } = latest.current;
      const text =
        reason === "banned"
          ? t("rtForceBanned")
          : reason === "password"
            ? t("rtForcePassword")
            : t("rtForceSessions");

      notification.warning({ message: text, duration: 4 });
      setTimeout(() => authService.logout(), 1500);
    });

    connection.onreconnecting(() => !disposed && setStatus("reconnecting"));
    connection.onreconnected(() => {
      if (disposed) return;
      setStatus("connected");
      queryClient.invalidateQueries(); // за время обрыва могли пропустить события
    });
    connection.onclose(() => !disposed && setStatus("disconnected"));

    async function start() {
      if (disposed) return;
      try {
        setStatus("connecting");
        await connection.start();
        if (disposed) return;
        setStatus("connected");
        if (hadFailure) {
          hadFailure = false;
          queryClient.invalidateQueries();
        }
      } catch {
        if (disposed) return;
        hadFailure = true;
        setStatus("disconnected");
        retryTimer = setTimeout(start, START_RETRY_MS);
      }
    }

    start();

    return () => {
      disposed = true;
      clearTimeout(retryTimer);
      connection.stop();
    };
    // Переподключаемся при входе/выходе (смене логина), а не при смене роли:
    // группы после смены роли сервер обновляет сам.
  }, [auth.loginName, queryClient]);

  const value = useMemo(() => ({ status }), [status]);

  return <RealtimeContext.Provider value={value}>{children}</RealtimeContext.Provider>;
};
