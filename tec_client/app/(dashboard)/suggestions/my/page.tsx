"use client";

import React from "react";
import Link from "next/link";
import { Button, Spin, Table, Tag, Typography } from "antd";
import { PlusOutlined, ReloadOutlined } from "@ant-design/icons";
import type { ColumnsType } from "antd/es/table";
import { useLocale } from "@/context/LocaleContext";
import { useMySuggestions } from "@/hooks/useSuggestions";
import type { Suggestion } from "@/types/suggestion";

const { Title, Text } = Typography;

export default function MySuggestionsPage() {
  const { t } = useLocale();
  const { data: suggestions, isLoading, isError, refetch } = useMySuggestions();

  const columns: ColumnsType<Suggestion> = [
    {
      title: t("suggestionsColSent"),
      dataIndex: "createdAt",
      key: "createdAt",
      width: 190,
      render: (date: string) => new Date(date).toLocaleString(),
      sorter: (a, b) => new Date(a.createdAt).getTime() - new Date(b.createdAt).getTime(),
      defaultSortOrder: "descend",
    },
    {
      title: t("suggestionsColText"),
      dataIndex: "text",
      key: "text",
      render: (v: string) => <span style={{ whiteSpace: "pre-wrap" }}>{v}</span>,
    },
    {
      title: t("colComment"),
      dataIndex: "comment",
      key: "comment",
      responsive: ["md"],
      render: (v: string | null) =>
        v ? <span style={{ whiteSpace: "pre-wrap" }}>{v}</span> : "—",
    },
    {
      title: t("suggestionsColAdminComment"),
      key: "adminComment",
      render: (_, s) =>
        s.adminComment ? (
          <div>
            <span style={{ whiteSpace: "pre-wrap" }}>{s.adminComment}</span>
            {s.adminCommentAt && (
              <Text type="secondary" style={{ display: "block", fontSize: 12 }}>
                {new Date(s.adminCommentAt).toLocaleString()}
              </Text>
            )}
          </div>
        ) : (
          <Tag>{t("suggestionsNoReply")}</Tag>
        ),
    },
  ];

  return (
    <div style={{ padding: 24 }}>
      <div
        style={{
          display: "flex",
          alignItems: "flex-start",
          justifyContent: "space-between",
          gap: 12,
          flexWrap: "wrap",
        }}
      >
        <div>
          <Title level={2} style={{ marginBottom: 4 }}>
            {t("suggestionsMyTitle")}
          </Title>
          <Text type="secondary">{t("suggestionsMySubtitle")}</Text>
        </div>
        <Link href="/suggestions">
          <Button type="primary" icon={<PlusOutlined />}>
            {t("suggestionsNew")}
          </Button>
        </Link>
      </div>

      <div style={{ marginTop: 20 }}>
        {isLoading ? (
          <div style={{ textAlign: "center", padding: 50 }}>
            <Spin size="large" />
          </div>
        ) : isError ? (
          <div style={{ textAlign: "center" }}>
            <Text type="danger">{t("suggestionsMyLoadError")}</Text>
            <br />
            <Button icon={<ReloadOutlined />} onClick={() => refetch()} style={{ marginTop: 10 }}>
              {t("bidsRetry")}
            </Button>
          </div>
        ) : (
          <Table<Suggestion>
            dataSource={suggestions}
            columns={columns}
            rowKey="id"
            locale={{ emptyText: t("suggestionsMyEmpty") }}
          />
        )}
      </div>
    </div>
  );
}