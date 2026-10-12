import type { NextRequest } from "next/server";
import { handleAuthAndPermissions } from "@/middleware/authCheck";

export async function proxy(request: NextRequest) {
  return handleAuthAndPermissions(request);
}

export const config = {
  matcher: [
    "/((?!_next/static|_next/image|favicon.ico|.*\\.(?:svg|png|jpg|jpeg|gif|webp|woff|woff2)$).*)",
    "/bids",
    "/bids/",
  ],
};