export const ROUTE_PERMISSIONS: Record<string, string[]> = {

  // Все (Guest -> не зареганный пользователь)
  "/news": ["Guest", "Worker", "Admin", "SuperAdmin"],
  "/navigation": ["Guest", "Worker", "Admin", "SuperAdmin"],
  "/map": ["Guest", "Worker", "Admin", "SuperAdmin"],



  // Сотрудники
  "/otdels": ["SuperAdmin", "Admin", "Worker"],
  "/profile": ["SuperAdmin", "Admin", "Worker"],
  "/bids/create": ["SuperAdmin", "Admin", "Worker"],
  "/bids/outgoing": ["SuperAdmin", "Admin", "Worker"],
  "/suggestions": ["SuperAdmin", "Admin", "Worker"],
  
  
  // Администраторы
  "/bids/incoming": ["SuperAdmin", "Admin"],
  "/workers": ["SuperAdmin", "Admin"],
  "/admin/news": ["SuperAdmin", "Admin"],
  "/admin/suggestions": ["SuperAdmin", "Admin"],
  "/tech/computers": ["SuperAdmin", "Admin"],
  "/tech/laptops": ["SuperAdmin", "Admin"],
  "/tech/printers": ["SuperAdmin", "Admin"],
  "/tech/others": ["SuperAdmin", "Admin"],

    
  
  // SuperAdmin 
  "/admin/activity-log": ["SuperAdmin"],
  "/admin/users": ["SuperAdmin"],
};
