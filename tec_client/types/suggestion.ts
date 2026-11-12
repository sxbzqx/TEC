export interface Suggestion {
  id: number;
  text: string;
  comment: string | null;
  createdAt: string;
  /** Ответ администратора (если есть). */
  adminComment: string | null;
  adminCommentAt: string | null;
}

/** Предложение в админке: дополнительно — кто его оставил. */
export interface AdminSuggestion extends Suggestion {
  userId: number;
  userName: string;
  userLogin: string;
  userDepartment: string | null;
  /** Кто из администраторов оставил комментарий. */
  adminCommentBy: string | null;
}

export interface CreateSuggestionPayload {
  text: string;
  comment?: string | null;
}