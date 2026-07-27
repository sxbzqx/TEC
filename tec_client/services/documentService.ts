import { $api } from "@/app/api/api";
import { Document, DocumentIncoming } from "@/types/document";

export interface CreateDocumentPayload {
  idResource: number;
  amount?: number | null;
  comment?: string | null;
}

export const documentService = {
  async create(payload: CreateDocumentPayload) {
    const { data } = await $api.post<Document>("/documents", payload);
    return data;
  },

  async getIncoming() {
    const { data } = await $api.get<DocumentIncoming[]>("/documents/incoming");
    return data;
  },

  async getById(id: number | string) {
    const { data } = await $api.get<DocumentIncoming>(`/documents/${id}`);
    return data;
  },

  async decide(id: number, action: 1 | 2 | 3, comment?: string) {
    const { data } = await $api.put<Document>(`/documents/${id}/decision`, {
      action,
      comment: comment ?? null,
    });
    return data;
  },

  async complete(id: number) {
    const { data } = await $api.put<Document>(`/documents/${id}/complete`);
    return data;
  },
};
