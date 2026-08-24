import { $api } from "@/app/api/api";
import { Bid, BidIncoming } from "@/types/bid";

export interface CreateDocumentPayload {
  idResource: number;
  amount?: number | null;
  comment?: string | null;
}

export const bidService = {
  async create(payload: CreateDocumentPayload) {
    const { data } = await $api.post<Document>("/bids", payload);
    return data;
  },

  async getIncoming() {
    const { data } = await $api.get<BidIncoming[]>("/bids/incoming");
    return data;
  },

  async getById(id: number | string) {
    const { data } = await $api.get<BidIncoming>(`/bids/${id}`);
    return data;
  },

  async decide(id: number, action: 1 | 2 | 3, comment?: string) {
    const { data } = await $api.put<Document>(`/bids/${id}/decision`, {
      action,
      comment: comment ?? null,
    });
    return data;
  },

  async complete(id: number) {
    const { data } = await $api.put<Document>(`/bids/${id}/complete`);
    return data;
  },
};
