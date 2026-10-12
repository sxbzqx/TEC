export const ROUTE_PERMISSIONS: Record<string, string[]> = {
  "/admin/activity-log": ["SuperAdmin"],
  "/admin": ["SuperAdmin", "Admin"],
  "/biznesplan": ["SuperAdmin", "Admin"],
  "/workers": ["SuperAdmin", "Admin"],
  "/otdels": ["SuperAdmin", "Admin", "Worker"],
  "/chat": ["SuperAdmin", "Admin", "Worker"],
  "/archive": ["SuperAdmin", "Admin", "Worker"],
  "/profile": ["SuperAdmin", "Admin", "Worker", "User"],
  "/bids/create": ["Admin", "SuperAdmin", "Worker"],
  "/bids/incoming": ["SuperAdmin", "Admin", "Worker"],
  "/create": ["Worker", "Guest", "SuperAdmin", "Admin"],
};
