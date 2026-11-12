import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { suggestionKeys, suggestionService } from "@/services/suggestionService";

export const useMySuggestions = () =>
  useQuery({
    queryKey: suggestionKeys.my,
    queryFn: suggestionService.getMy,
  });

export const useAdminSuggestions = () =>
  useQuery({
    queryKey: suggestionKeys.admin,
    queryFn: suggestionService.getAll,
  });

export const useSetSuggestionComment = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: ({ id, comment }: { id: number; comment: string }) =>
      suggestionService.setAdminComment(id, comment),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: suggestionKeys.all });
    },
  });
};

export const useCreateSuggestion = () => {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: suggestionService.create,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: suggestionKeys.all });
    },
  });
};