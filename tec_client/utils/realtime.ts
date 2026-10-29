import type { QueryClient, QueryKey } from "@tanstack/react-query";
import { newsKeys } from "@/services/newsService";
import { adminUserKeys } from "@/services/adminUserService";
import { ROUTE_PERMISSIONS } from "@/middleware/config";

/**
 * Тема события DataChanged → какие react-query запросы перезапросить.
 * Темы задаёт бэкенд (RealtimeTopics в PortalNotifier.cs) по тому, какие таблицы изменил SaveChanges.
 * Чтобы новый экран стал realtime — достаточно добавить его queryKey сюда.
 */
const TOPIC_QUERY_KEYS: Record<string, readonly QueryKey[]> = {
  posts: [
    newsKeys.admin,
    newsKeys.public,
    newsKeys.featuredAll,
    ["post"],
    ["notifications"],
  ],
  categories: [newsKeys.categories],
  activity: [["recent-activity"], ["activity-log"], ["activity-log-actions"]],
  departments: [["departments"]],
  bids: [["bid"]],
  resources: [["resources"]],
  equipment: [
    ["office-computers"],
    ["office-laptops"],
    ["office-printers"],
    ["office-other"],
    ["office-equipment"],
  ],
  workers: [["workers"]],
  users: [adminUserKeys.list, adminUserKeys.oneAll],
};

export function invalidateTopic(queryClient: QueryClient, topic: string) {
  const keys = TOPIC_QUERY_KEYS[topic];
  if (!keys) return;

  for (const queryKey of keys) {
    queryClient.invalidateQueries({ queryKey });
  }
}

/** Та же проверка, что делает middleware (authCheck.ts), — чтобы увести со страницы, на которую роль больше не пускает. */
export function isPathAllowed(pathname: string, role: string): boolean {
  const route = Object.keys(ROUTE_PERMISSIONS).find((r) => pathname.startsWith(r));
  return !route || ROUTE_PERMISSIONS[route].includes(role);
}
