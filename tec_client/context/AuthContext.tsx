"use client";

import React, { createContext, useContext, useState, useEffect, useCallback } from "react";
import Cookies from "js-cookie";
import { authService } from "@/services/authService";

interface AuthState {
  role: string;
  loginName: string;
  /** ФИО сотрудника из кадровой записи (есть только у пользователей, привязанных к сотруднику). */
  fio?: string;
}

interface AuthContextType {
  auth: AuthState;
  isMounted: boolean;
  isLoading: boolean;
  /** silent = не переключать isLoading (для фоновых обновлений по realtime). */
  refreshAuth: (silent?: boolean) => Promise<void>;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider: React.FC<{
  children: React.ReactNode;
  initialAuth?: AuthState;
}> = ({ children, initialAuth }) => {
  const [auth, setAuth] = useState<AuthState>(initialAuth ?? { role: "Guest", loginName: "" });
  const [isMounted, setIsMounted] = useState(false);
  const [isLoading, setIsLoading] = useState(true);

  const refreshAuth = useCallback(async (silent = false) => {
    if (!silent) setIsLoading(true);
    try {
      if (Cookies.get("accessToken")) {
        const userData = await authService.getCurrentUser();
        setAuth(userData ?? { role: "Guest", loginName: "" });
      } else {
        setAuth({ role: "Guest", loginName: "" });
      }
    } catch (error) {
      console.error("[AuthContext] Ошибка загрузки пользователя:", error);
      setAuth({ role: "Guest", loginName: "" });
    } finally {
      if (!silent) setIsLoading(false); // Обязательно снимаем флаг загрузки
    }
  }, []);

  useEffect(() => {
    setIsMounted(true);
    refreshAuth();
  }, [refreshAuth]);

  return (
    <AuthContext.Provider value={{ auth, isMounted, isLoading, refreshAuth }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuthContext = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error("useAuthContext must be used within AuthProvider");
  return context;
};