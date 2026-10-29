import axios from "axios";
import Cookies from "js-cookie";
import { apiBaseUrl } from "@/utils/config";

const API_URL = apiBaseUrl;

export const $api = axios.create({
  baseURL: API_URL,
  headers: { "Content-Type": "application/json" },
});

let refreshPromise: Promise<string> | null = null;

/**
 * Обновляет токены через Route Handler /api/auth/refresh (он же ставит cookie).
 * Refresh-токен одноразовый (ротируется на каждый вызов), поэтому параллельные вызовы
 * из axios, SignalR и т.д. обязаны делить один запрос — иначе второй получит 401 и сбросит сессию.
 */
export function refreshAccessToken(): Promise<string> {
  if (!refreshPromise) {
    refreshPromise = (async () => {
      const res = await fetch("/api/auth/refresh", { method: "POST" });
      const data = await res.json().catch(() => null);

      if (!res.ok || !data?.accessToken) {
        throw new Error(data?.message || "Не удалось обновить токен");
      }

      return data.accessToken as string;
    })().finally(() => {
      refreshPromise = null;
    });
  }

  return refreshPromise;
}

$api.interceptors.request.use((config) => {
  const token = Cookies.get("accessToken");
  if (token && config.headers) {
    config.headers.Authorization = `Bearer ${token}`;
  }
  return config;
});

$api.interceptors.response.use(
  (response) => response,
  async (error) => {
    const originalRequest = error.config;

    if (error.response?.status === 401 && originalRequest && !originalRequest._retry) {
      originalRequest._retry = true;

      try {
        const token = await refreshAccessToken();
        originalRequest.headers.Authorization = `Bearer ${token}`;
        return $api(originalRequest);
      } catch (refreshError) {
        console.warn("[Axios] Рефреш полностью провалился. Сброс сессии.");
        if (typeof window !== "undefined") {
          window.location.href = "/login";
        }

        return Promise.reject(refreshError);
      }
    }

    return Promise.reject(error);
  },
);
