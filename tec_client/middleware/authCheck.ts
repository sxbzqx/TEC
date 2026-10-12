import { NextResponse } from "next/server";
import type { NextRequest } from "next/server";
import { decodeAccessToken } from "@/utils/jwt";
import { ROUTE_PERMISSIONS } from "./config";
import { tryRefreshTokens, applyTokens } from "./tokens";

export function redirectTo(request: NextRequest, path: string): NextResponse {
  return NextResponse.redirect(new URL(path, request.url));
}

export async function handleAuthAndPermissions(request: NextRequest) {
  const { pathname } = request.nextUrl;
  const accessToken = request.cookies.get("accessToken")?.value;
  const refreshToken = request.cookies.get("refreshToken")?.value;

  const targetRoute = Object.keys(ROUTE_PERMISSIONS).find((route) =>
    pathname.startsWith(route)
  );

  if (targetRoute) {
    const allowedRoles = ROUTE_PERMISSIONS[targetRoute];
    const decoded = decodeAccessToken(accessToken);

    if (!decoded.isExpired && decoded.role) {
      if (!allowedRoles.includes(decoded.role)) {
        console.log(`[Middleware] Пользователь ${decoded.role} не имеет доступа к ${pathname}. Редирект на 403`);
        return redirectTo(request, "/403");
      }
      return NextResponse.next();
    }

    if (!refreshToken) {
      console.log(`[Middleware] Нет валидных токенов. Доступ к ${pathname} запрещён. На /login`);
      return redirectTo(request, "/login");
    }

    console.log("[Middleware] accessToken недействителен. Пробуем обновить...");
    const refreshed = await tryRefreshTokens(refreshToken);
    if (!refreshed) {
      return redirectTo(request, "/login");
    }

    const refreshedDecoded = decodeAccessToken(refreshed.accessToken);
    if (!refreshedDecoded.role) {
      console.warn("[Middleware] Бэкенд вернул нерабочий accessToken при refresh");
      return redirectTo(request, "/login");
    }

    if (!allowedRoles.includes(refreshedDecoded.role)) {
      console.log(`[Middleware] Пользователь ${refreshedDecoded.role} не имеет доступа к ${pathname} (после refresh). Редирект на 403`);
      return applyTokens(request, redirectTo(request, "/403"), refreshed);
    }

    return applyTokens(request, NextResponse.next({ request }), refreshed);
  }

  // 2. Страницы авторизации (/login, /register)
  if (pathname === "/login" || pathname === "/register") {
    const decoded = decodeAccessToken(accessToken);

    if (!decoded.isExpired && decoded.role) {
      console.log(`[Middleware] Пользователь уже авторизован. Редирект с ${pathname} на главную`);
      return redirectTo(request, "/");
    }

    if (refreshToken) {
      console.log("[Middleware] Пробуем refresh на странице /login...");
      const refreshed = await tryRefreshTokens(refreshToken);
      if (refreshed) {
        console.log("[Middleware] Refresh успешен -> Авто-вход на /");
        return applyTokens(request, redirectTo(request, "/"), refreshed);
      }
    }
  }

  // 3. Редиректы со старых/вспомогательных путей
  if (pathname === "/bids" || pathname === "/bids/") {
    const url = request.nextUrl.clone();
    url.pathname = "/bids/create";
    return NextResponse.redirect(url);
  }

  return NextResponse.next();
}