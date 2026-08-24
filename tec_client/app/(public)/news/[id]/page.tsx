"use client";

import React from "react";
import { useParams } from "next/navigation";
import { useQuery } from "@tanstack/react-query";
import { $api } from "@/app/api/api";
import { Typography, Spin, Card } from "antd";
import { useLocale } from "@/context/LocaleContext";

const { Title, Paragraph, Text } = Typography;

export default function PostPage() {
  const { id } = useParams();
  const { t } = useLocale();

  const { data: post, isLoading, error } = useQuery({
    queryKey: ["post", id],
    queryFn: async () => (await $api.get(`/admin/posts/${id}`)).data,
    enabled: !!id,
  });

  if (isLoading) return <Spin size="large" style={{ display: 'block', marginTop: 50 }} />;
  if (error || !post) return <Title level={3}>{t("newsPostNotFound")}</Title>;

  return (
    <div style={{ maxWidth: 800, margin: "40px auto", padding: "0 20px" }}>
      <Card>
        <Title level={1}>{post.title}</Title>
        <Text type="secondary">{t("newsPublishedLabel")} {new Date(post.createdAt).toLocaleDateString()}</Text>
        <div style={{ marginTop: 20 }}>
          <Paragraph style={{ fontSize: 18 }}>{post.content}</Paragraph>
        </div>
        <hr />
        <Text italic>{t("newsAuthorLabel")} {post.creatorName}, {t("newsCategoryLabel")} {post.category.name}</Text>
      </Card>
    </div>
  );
}