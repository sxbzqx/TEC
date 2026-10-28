import { $api } from "@/app/api/api";
import type { Post, PostCategory, PostFlagsPayload, PostPayload } from "@/types/post";

export const newsKeys = {
  admin: ["admin-posts"] as const,
  public: ["public-posts"] as const,
  featured: (take: number) => ["featured-posts", take] as const,
  featuredAll: ["featured-posts"] as const,
  one: (id: string | number) => ["post", String(id)] as const,
  categories: ["categories"] as const,
};

export const fetchAdminPosts = async (): Promise<Post[]> =>
  (await $api.get("/admin/posts")).data;

export const fetchPublicPosts = async (): Promise<Post[]> =>
  (await $api.get("/admin/posts/public")).data;

export const fetchFeaturedPosts = async (take = 5): Promise<Post[]> =>
  (await $api.get("/admin/posts/featured", { params: { take } })).data;

export const fetchPostById = async (id: string | number): Promise<Post> =>
  (await $api.get(`/admin/posts/${id}`)).data;

export const fetchCategories = async (): Promise<PostCategory[]> =>
  (await $api.get("/categories")).data;

export const createPost = (payload: PostPayload) => $api.post("/admin/posts", payload);

export const updatePost = (id: number, payload: PostPayload) =>
  $api.put(`/admin/posts/${id}`, payload);

export const updatePostFlags = (id: number, payload: PostFlagsPayload) =>
  $api.patch(`/admin/posts/${id}/flags`, payload);

export const deletePost = (id: number) => $api.delete(`/admin/posts/${id}`);
