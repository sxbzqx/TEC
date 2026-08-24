import { NextRequest, NextResponse } from "next/server";
import { serverApiBaseUrl } from "@/utils/config";

export async function POST(request: NextRequest) {
  const body = await request.json().catch(() => null);

  if (!body?.tabel) {
    return NextResponse.json({ message: "Укажите табельный номер" }, { status: 400 });
  }

  let backendResponse: Response;
  try {
    backendResponse = await fetch(`${serverApiBaseUrl}/auth/employee/lookup`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ tabel: body.tabel }),
    });
  } catch (error) {
    console.error("[api/auth/employee/lookup] Не удалось связаться с backend:", error);
    return NextResponse.json({ message: "Сервер недоступен" }, { status: 502 });
  }

  const data = await backendResponse.json().catch(() => ({}));

  return NextResponse.json(data, { status: backendResponse.status });
}