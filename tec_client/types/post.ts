/** 0 — обычная, 1 — важная, 2 — срочная */
export type PostPriority = 0 | 1 | 2;

export interface PostCategory {
  id: number;
  name: string;
}

export interface Post {
  id: number;
  title: string;
  content: string;
  summary?: string | null;
  createdAt: string;
  updatedAt?: string | null;
  creatorName: string;
  creatorDepartment: string | null;
  categoryId: number;
  category?: PostCategory;
  isPublished: boolean;
  showOnMain: boolean;
  priority: PostPriority;
}

export interface PostPayload {
  title: string;
  content: string;
  summary?: string | null;
  categoryId: number;
  isPublished: boolean;
  showOnMain: boolean;
  priority: PostPriority;
}

export interface PostFlagsPayload {
  isPublished?: boolean;
  showOnMain?: boolean;
  priority?: PostPriority;
}
