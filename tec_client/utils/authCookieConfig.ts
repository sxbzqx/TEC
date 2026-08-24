import { NextRequest } from "next/server";

export const ACCESS_TOKEN_MAX_AGE = 60 * 60 * 24; // 1 день
export const REFRESH_TOKEN_MAX_AGE = 7 * 24 * 60 * 60; // 7 дней
export const isProd = process.env.NODE_ENV === "production";

// Динамически проверяем, идет ли соединение по HTTPS
export function getIsSecure(request?: NextRequest): boolean {
  if (!request) return false;
  
  // Проверяем прямое HTTPS соединение или заголовок от Nginx / прокси
  const proto = request.headers.get("x-forwarded-proto") || request.nextUrl.protocol;
  return proto.includes("https");
}