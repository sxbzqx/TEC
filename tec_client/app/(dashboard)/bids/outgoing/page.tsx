"use client";

import React from "react";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { Button, Spin, Table, Tag, Typography } from "antd";
import { PlusOutlined, ReloadOutlined } from "@ant-design/icons";
import type { ColumnsType } from "antd/es/table";
import { useLocale } from "@/context/LocaleContext";
import { useOutgoingBids } from "@/hooks/useIncomingBids";
import { getBidStatus, type BidStatusKey } from "@/utils/bidStatus";
import type { BidIncoming } from "@/types/bid";

const { Title, Text } = Typography;

export default function OutgoingBidsPage() {
  const { t } = useLocale();
  const router = useRouter();

  const { data: bids, isLoading, isError, refetch } = useOutgoingBids();

  const statusFilters = (["pending", "approved", "done", "rejected", "postponed"] as BidStatusKey[]).map(
    (key) => ({
      value: key,
      text: getBidStatus(
        {
          action: key === "pending" ? 0 : key === "rejected" ? 2 : key === "postponed" ? 3 : 1,
          made: key === "done" ? 1 : 0,
        },
        t,
      ).label,
    }),
  );

  const columns: ColumnsType<BidIncoming> = [
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
      title: t("colReceiver"),
      dataIndex: "receiverDepartment",
      key: "receiverDepartment",
      responsive: ["md"],
      render: (v: string | null) => v || "—",
    },
    {
      title: t("colAmount"),
      dataIndex: "amount",
      key: "amount",
      responsive: ["md"],
      render: (v: number | null) => v ?? "—",
    },
    {
      title: t("colComment"),
      dataIndex: "comment",
      key: "comment",
      responsive: ["lg"],
      ellipsis: true,
      render: (v: string | null) => v || "—",
    },
    {
      title: t("colStatus"),
      key: "status",
      filters: statusFilters,
      onFilter: (value, record) => getBidStatus(record, t).key === value,
      render: (_, record) => {
        const meta = getBidStatus(record, t);
        return <Tag color={meta.color}>{meta.label}</Tag>;
      },
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
            {t("bidsOutgoingTitle")}
          </Title>
          <Text type="secondary">{t("bidsOutgoingSubtitle")}</Text>
        </div>
        <Link href="/bids/create">
          <Button type="primary" icon={<PlusOutlined />}>
            {t("bidsOutgoingCreate")}
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
            <Text type="danger">{t("bidsOutgoingLoadError")}</Text>
            <br />
            <Button icon={<ReloadOutlined />} onClick={() => refetch()} style={{ marginTop: 10 }}>
              {t("bidsRetry")}
            </Button>
          </div>
        ) : (
          <Table<BidIncoming>
            dataSource={bids}
            columns={columns}
            rowKey="id"
            locale={{ emptyText: t("bidsOutgoingEmpty") }}
            onRow={(record) => ({
              onClick: () => router.push(`/bids/${record.id}`),
              style: { cursor: "pointer" },
            })}
          />
        )}
      </div>
    </div>
  );
}
