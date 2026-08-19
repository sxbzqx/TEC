import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { bidService } from "@/services/bidService";

export const useIncomingBids = () => {
  return useQuery({
    queryKey: ["bid", "incoming"],
    queryFn: bidService.getIncoming,
  });
};

export const useBidDetail = (id: number | string | undefined) => {
  return useQuery({
    queryKey: ["bid", "detail", id],
    queryFn: () => bidService.getById(id as number | string),
    enabled: id !== undefined && id !== "",
  });
};

export const useDecideBid = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: ({ id, action, comment }: { id: number; action: 1 | 2 | 3; comment?: string }) =>
      bidService.decide(id, action, comment),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["bids", "incoming"] });
      queryClient.invalidateQueries({ queryKey: ["bid", "detail"] });
    },
  });
};

export const useCompleteBid = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (id: number) => bidService.complete(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["bids", "incoming"] });
      queryClient.invalidateQueries({ queryKey: ["bids", "detail"] });
    },
  });
};
