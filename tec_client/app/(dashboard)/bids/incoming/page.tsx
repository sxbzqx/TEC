"use client";

import React from "react";
import { useRouter } from "next/navigation";
import { Typography, Table, Tag, Spin, Button } from "antd";
import { ReloadOutlined } from "@ant-design/icons";
import type { ColumnsType } from "antd/es/table";
import { useLocale } from "@/context/LocaleContext";
import { useIncomingBids } from "@/hooks/useIncomingBids";
import { DocumentIncoming } from "@/types/document";

const { Title, Text } = Typography;

export default function IncomingBidsPage() {
  const { t } = useLocale();
  const router = useRouter();

  const { data: bids, isLoading, isError, refetch } = useIncomingBids();

  const statusMeta = (record: DocumentIncoming): { label: string; color: string } => {
    if (record.action === 0) return { label: t("bidStatusPending"), color: "gold" };
    if (record.action === 2) return { label: t("bidStatusRejected"), color: "red" };
    if (record.action === 3) return { label: t("bidStatusPostponed"), color: "default" };
    // action === 1 (разрешено)
    return record.made === 1
      ? { label: t("bidStatusDone"), color: "green" }
      : { label: t("bidStatusApproved"), color: "blue" };
  };

  const columns: ColumnsType<DocumentIncoming> = [
    { title: t("colId"), dataIndex: "id", key: "id", width: 70 },
    {
      title: t("colSubmitDate"),
      dataIndex: "dateFirst",
      key: "dateFirst",
      render: (date: string) => new Date(date).toLocaleString(),
      sorter: (a, b) => new Date(a.dateFirst).getTime() - new Date(b.dateFirst).getTime(),
      defaultSortOrder: "descend",
    },
    { title: t("colMaterial"), dataIndex: "resourceName", key: "resourceName" },
    {
      title: t("bidDetailCreator"),
      key: "creator",
      render: (_, record) =>
        record.creatorDepartment
          ? `${record.creatorName} (${record.creatorDepartment})`
          : record.creatorName,
    },
    { title: t("colAmount"), dataIndex: "amount", key: "amount", render: (v: number | null) => v ?? "—" },
    { title: t("colComment"), dataIndex: "comment", key: "comment", render: (v: string | null) => v || "—" },
    {
      title: t("colStatus"),
      key: "status",
      render: (_, record) => {
        const meta = statusMeta(record);
        return <Tag color={meta.color}>{meta.label}</Tag>;
      },
    },
  ];

  return (
    <div style={{ padding: 24 }}>
      <Title level={2}>{t("bidsIncomingTitle")}</Title>

      {isLoading ? (
        <div style={{ textAlign: "center", padding: 50 }}>
          <Spin size="large" />
        </div>
      ) : isError ? (
        <div style={{ textAlign: "center" }}>
          <Text type="danger">{t("bidsIncomingLoadError")}</Text>
          <br />
          <Button icon={<ReloadOutlined />} onClick={() => refetch()} style={{ marginTop: 10 }}>
            {t("bidsRetry")}
          </Button>
        </div>
      ) : (
        <Table
          dataSource={bids}
          columns={columns}
          rowKey="id"
          locale={{ emptyText: t("bidsIncomingEmpty") }}
          onRow={(record) => ({
            onClick: () => router.push(`/bids/${record.id}`),
            style: { cursor: "pointer" },
          })}
        />
      )}
    </div>
  );
}