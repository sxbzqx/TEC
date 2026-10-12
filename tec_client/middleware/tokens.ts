import { NextResponse } from "next/server";
import type { NextRequest } from "next/server";
import { serverApiBaseUrl } from "@/utils/config";
import { extractTokens, type TokenPair } from "@/utils/tokens";
import {
  ACCESS_TOKEN_MAX_AGE,
  REFRESH_TOKEN_MAX_AGE,
  getIsSecure,
} from "@/utils/authCookieConfig";

const API_URL = serverApiBaseUrl;

export async function tryRefreshTokens(refreshToken: string): Promise<TokenPair | null> {
  try {
    const response = await fetch(`${API_URL}/auth/refresh`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ refreshToken: refreshToken.trim() }),
    });

    if (!response.ok) {
      console.warn("[Middleware] Refresh ответ не OK:", response.status);
      return null;
    }

    const data = await response.json();
    const tokens = extractTokens(data);

    if (!tokens) {
      console.warn("[Middleware] В ответе refresh нет токенов");
      return null;
    }

    return tokens;
  } catch (error) {
    console.error("[Middleware] Ошибка refresh:", error);
    return null;
  }
}

export function applyTokens(
  request: NextRequest,
  response: NextResponse,
  tokens: TokenPair
): NextResponse {
  request.cookies.set("accessToken", tokens.accessToken);
  request.cookies.set("refreshToken", tokens.refreshToken);

  const isSecure = getIsSecure(request);

  response.cookies.set("accessToken", tokens.accessToken, {
    path: "/",
    sameSite: "lax",
    secure: isSecure,
    httpOnly: false,
    maxAge: ACCESS_TOKEN_MAX_AGE,
  });

  response.cookies.set("refreshToken", tokens.refreshToken, {
    path: "/",
    sameSite: "lax",
    secure: isSecure,
    httpOnly: true,
    maxAge: REFRESH_TOKEN_MAX_AGE,
  });

  return response;
}