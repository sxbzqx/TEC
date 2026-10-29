const rawApiUrl = process.env.NEXT_PUBLIC_API_URL;

export const apiBaseUrl = rawApiUrl?.trim().replace(/\/$/, "");

const rawServerApiUrl =
  typeof window === "undefined" ? process.env.API_URL : undefined;

export const serverApiBaseUrl =
  rawServerApiUrl?.trim().replace(/\/$/, "") || apiBaseUrl;

// SignalR-хаб живёт на корне бэкенда (/hubs/portal), а не под /api, поэтому берём origin из API URL.
// Прод: https://host/api-backend → https://host/hubs/portal (nginx проксирует /hubs/ на бэкенд).
// Dev: http://localhost:8080/api → http://localhost:8080/hubs/portal.
export const hubUrl = (() => {
  try {
    return `${new URL(apiBaseUrl ?? "").origin}/hubs/portal`;
  } catch {
    return "/hubs/portal";
  }
})();

export const backendUrl = (path: string) => `${apiBaseUrl}/${path.replace(/^\/+/, "")}`;

export const serverBackendUrl = (path: string) =>
  `${serverApiBaseUrl}/${path.replace(/^\/+/, "")}`;