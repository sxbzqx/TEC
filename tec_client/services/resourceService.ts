import { $api } from "@/app/api/api";
import { Resource } from "@/types/resource";

export const resourceService = {
  async getAll() {
    const { data } = await $api.get<Resource[]>("/resources");
    return data;
  },
};
