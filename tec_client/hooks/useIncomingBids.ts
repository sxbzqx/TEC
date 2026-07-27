import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { documentService } from "@/services/documentService";

export const useIncomingBids = () => {
  return useQuery({
    queryKey: ["documents", "incoming"],
    queryFn: documentService.getIncoming,
  });
};

export const useBidDetail = (id: number | string | undefined) => {
  return useQuery({
    queryKey: ["documents", "detail", id],
    queryFn: () => documentService.getById(id as number | string),
    enabled: id !== undefined && id !== "",
  });
};

export const useDecideBid = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: ({ id, action, comment }: { id: number; action: 1 | 2 | 3; comment?: string }) =>
      documentService.decide(id, action, comment),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["documents", "incoming"] });
      queryClient.invalidateQueries({ queryKey: ["documents", "detail"] });
    },
  });
};

export const useCompleteBid = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (id: number) => documentService.complete(id),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ["documents", "incoming"] });
      queryClient.invalidateQueries({ queryKey: ["documents", "detail"] });
    },
  });
};
