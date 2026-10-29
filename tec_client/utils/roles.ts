export const STAFF_ROLES = ["SuperAdmin", "Admin"];

export const isStaffRole = (role: string | null | undefined): boolean =>
  !!role && STAFF_ROLES.includes(role);

export const getRoleTagColor = (role: string): string => {
  switch (role) {
    case "SuperAdmin":
      return "volcano";
    case "Admin":
      return "gold";
    case "Worker":
      return "blue";
    default:
      return "default";
  }
};

/**
 * Какие роли может назначать просматривающий. Зеркалит правила бэкенда (AdminUsersController):
 * Admin не может выдавать Admin/SuperAdmin, иначе мог бы повысить сам себя.
 */
export const getAssignableRoles = (viewerRole: string): string[] =>
  viewerRole === "SuperAdmin" ? ["User", "Worker", "Admin", "SuperAdmin"] : ["User", "Worker"];

/** Может ли просматривающий управлять учётной записью с такой ролью. */
export const canManageRole = (viewerRole: string, targetRole: string): boolean =>
  viewerRole === "SuperAdmin" || !isStaffRole(targetRole);
