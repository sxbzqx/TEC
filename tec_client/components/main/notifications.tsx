"use client";

import { Button, Card, Spin, Alert } from "antd";
import { BellOutlined } from "@ant-design/icons";
import Link from "next/link";
import { useQuery } from "@tanstack/react-query";
import { $api } from "@/app/api/api";
import { useLocale } from "@/context/LocaleContext";

export const Notifications = () => {
  const { t } = useLocale();
  const {
    data: posts,
    isLoading,
    error,
  } = useQuery({
    queryKey: ["notifications"],
    queryFn: async () => (await $api.get("/admin/posts/public")).data,
  });

  const truncateText = (text: string, limit: number) => {
    const words = text.split(" ");
    if (words.length <= limit) return text;
    return words.slice(0, limit).join(" ") + "...";
  };

  return (
    <Card
      title={
        <div
          style={{
            display: "flex",
            justifyContent: "space-between",
            gap: "8px",
          }}
        >
          <div style={{ display: "flex", alignItems: "center", gap: "8px" }}>
            <BellOutlined style={{ color: "var(--brand)" }} />
            {t("notifImportantNews")}
          </div>
          <Link href="/news">
            <Button type="link" style={{ color: "var(--brand)" }}>
              {t("notifOpen")}
            </Button>
          </Link>
        </div>
      }
      className="hover-card"
    >
      {isLoading && <Spin style={{ display: "block", margin: "20px auto" }} />}

      {error && <Alert message={t("notifLoadError")} type="error" showIcon />}

      {!isLoading && posts && (
        <div style={{ display: "flex", flexDirection: "column", gap: "16px" }}>
          {posts.map((post: any) => (
            <Link key={post.id} href={`/news/${post.id}`}>
              <Card
                size="small"
                title={post.title}
                style={{
                  borderLeft: `4px solid ${post.isImportant ? "var(--brand)" : "var(--ink-faint)"}`,
                }}
              >
                {truncateText(post.content || post.description || "", 5)}
              </Card>
            </Link>
          ))}
        </div>
      )}
    </Card>
  );
};
