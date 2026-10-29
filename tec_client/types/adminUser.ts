export type AppRole = "SuperAdmin" | "Admin" | "Worker" | "User" | "Guest";

export interface AdminUserRow {
  id: number;
  username: string;
  email: string | null;
  role: string;
  isBanned: boolean;
  otdelId: number | null;
  otdel: string | null;
  tabel: string | null;
  isOnline: boolean;
}

export interface AdminUserActivity {
  id: number;
  action: string;
  title: string;
  subtitle: string | null;
  createdAt: string;
}

export interface AdminUserDetail extends AdminUserRow {
  fio: string | null;
  doljnost: string | null;
  comeDate: string | null;
  banDate: string | null;
  banComment: string | null;
  banAmount: number;
  activeSessions: number;
  recentActivity: AdminUserActivity[];
}

export interface UpdateProfilePayload {
  login: string;
  mail: string | null;
  otdelId: number | null;
}
