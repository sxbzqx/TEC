import { useQuery } from "@tanstack/react-query";
import { resourceService } from "@/services/resourceService";

export const useResources = () => {
  return useQuery({
    queryKey: ["resources"],
    queryFn: resourceService.getAll,
    staleTime: 5 * 60000,
  });
};
