import { $api } from "@/app/api/api";
import type {
  AdminUserDetail,
  AdminUserRow,
  UpdateProfilePayload,
} from "@/types/adminUser";

export const adminUserKeys = {
  list: ["admin-users"] as const,
  one: (id: number) => ["admin-user", id] as const,
  oneAll: ["admin-user"] as const,
};

export const adminUserService = {
  async getAll(): Promise<AdminUserRow[]> {
    return (await $api.get<AdminUserRow[]>("/admin/users")).data;
  },

  async getOne(id: number): Promise<AdminUserDetail> {
    return (await $api.get<AdminUserDetail>(`/admin/users/${id}`)).data;
  },

  async updateRole(id: number, role: string) {
    return (await $api.put(`/admin/users/${id}/role`, { role })).data;
  },

  async updateProfile(id: number, payload: UpdateProfilePayload) {
    return (await $api.put(`/admin/users/${id}/profile`, payload)).data;
  },

  async ban(id: number, comment: string) {
    return (await $api.post(`/admin/users/${id}/ban`, { comment })).data;
  },

  async unban(id: number) {
    return (await $api.post(`/admin/users/${id}/unban`)).data;
  },

  async revokeSessions(id: number) {
    return (await $api.post(`/admin/users/${id}/sessions/revoke`)).data;
  },

  async resetPassword(id: number, newPassword: string) {
    return (await $api.post(`/admin/users/${id}/password`, { newPassword })).data;
  },
};
