const rawApiUrl = process.env.NEXT_PUBLIC_API_URL;

export const apiBaseUrl = rawApiUrl?.trim().replace(/\/$/, "");

const rawServerApiUrl =
  typeof window === "undefined" ? process.env.API_URL : undefined;

export const serverApiBaseUrl =
  rawServerApiUrl?.trim().replace(/\/$/, "") || apiBaseUrl;

export const backendUrl = (path: string) => `${apiBaseUrl}/${path.replace(/^\/+/, "")}`;

export const serverBackendUrl = (path: string) =>
  `${serverApiBaseUrl}/${path.replace(/^\/+/, "")}`;