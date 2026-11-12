import { $api } from "@/app/api/api";
import type { AdminSuggestion, CreateSuggestionPayload, Suggestion } from "@/types/suggestion";

export const suggestionKeys = {
  /** Префикс: по нему realtime-тема "suggestions" перезапрашивает оба списка. */
  all: ["suggestions"] as const,
  my: ["suggestions", "my"] as const,
  admin: ["suggestions", "admin"] as const,
};

export const suggestionService = {
  async create(payload: CreateSuggestionPayload) {
    const { data } = await $api.post<Suggestion>("/suggestions", payload);
    return data;
  },

  /** Пустая строка удаляет комментарий администратора. */
  async setAdminComment(id: number, comment: string) {
    const { data } = await $api.put<Suggestion>(`/suggestions/${id}/comment`, { comment });
    return data;
  },

  async getMy() {
    const { data } = await $api.get<Suggestion[]>("/suggestions/my");
    return data;
  },

  async getAll() {
    const { data } = await $api.get<AdminSuggestion[]>("/suggestions");
    return data;
  },
};