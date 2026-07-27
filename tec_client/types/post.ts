export interface Post {
  id: number;
  title: string;
  content: string;
  createdAt: string;
  creatorName: string;
  creatorDepartment: string | null;
  categoryId: number;
  category?: {
    id: number;
    name: string;
  };
}