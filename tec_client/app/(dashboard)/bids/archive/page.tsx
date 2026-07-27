"use client";

import React, { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { $api } from "@/app/api/api";
import { Typography, Spin, Table, Select, Button, Space, Row, Col } from "antd";
import { PrinterOutlined, ReloadOutlined } from "@ant-design/icons";
import { Document } from "@/types/document";
import { useLocale } from "@/context/LocaleContext";

const { Title, Text } = Typography;

export default function DocumentsPage() {
  const { t } = useLocale();
  const [year, setYear] = useState<number>(2024);
  const [month, setMonth] = useState<number>(3);

  const { data: documents, isLoading, isError, refetch } = useQuery({
    queryKey: ["documents", year, month],
    queryFn: async () => {
      const response = await $api.get(`/documents/${year}/${month}`);
      return response.data as Document[];
    },
  });

  const handlePrint = () => {
    window.print();
  };

  const columns = [
    { title: t("colId"), dataIndex: "id", key: "id" },
    { title: t("colSender"), dataIndex: "idUser", key: "idUser", render: (id: number) => `${t("userHashPrefix")}${id}` },
    { title: t("colReceiver"), dataIndex: "idReceiver", key: "idReceiver", render: (id: number) => `${t("userHashPrefix")}${id}` },
    { title: t("colResource"), dataIndex: "idResource", key: "idResource", render: (id: number) => `${t("resourcePrefix")} ${id}` },
    { title: t("colAmount"), dataIndex: "amount", key: "amount" },
    { title: t("colComment"), dataIndex: "comment", key: "comment", render: (text: string) => text || "—" },
    { title: t("colSubmitDate"), dataIndex: "dateFirst", key: "dateFirst", render: (date: string) => new Date(date).toLocaleString() },
    {
      title: t("colStatus"),
      dataIndex: "made",
      key: "made",
      render: (made: number) => (
        made === 1
          ? <span style={{ color: 'var(--success)', fontWeight: 'bold' }}>{t("bidsDone")}</span>
          : <span style={{ color: 'var(--warning)' }}>{t("bidsInProgress")}</span>
      )
    },
  ];

  return (
    <div style={{ padding: "24px" }}>
      {/* Стили для печати остаются те же */}
      <style>{`
        @media print {
          .no-print { display: none !important; }
        }
      `}</style>

      <Title level={2}>{t("bidsArchiveTitle")}</Title>

      <div className="no-print" style={{ marginBottom: 24 }}>
        <Space size="middle">
          <Select value={year} onChange={setYear} style={{ width: 120 }}>
            {[2024, 2025, 2026].map(y => <Select.Option key={y} value={y}>{y}</Select.Option>)}
          </Select>
          <Select value={month} onChange={setMonth} style={{ width: 120 }}>
            {Array.from({ length: 12 }, (_, i) => i + 1).map(m => (
              <Select.Option key={m} value={m}>{m.toString().padStart(2, '0')}</Select.Option>
            ))}
          </Select>
          <Button icon={<PrinterOutlined />} onClick={handlePrint} disabled={!documents || documents.length === 0}>
            {t("bidsPrint")}
          </Button>
        </Space>
      </div>

      {isLoading ? (
        <div style={{ textAlign: "center", padding: 50 }}><Spin size="large" /></div>
      ) : isError ? (
        <div style={{ textAlign: "center" }}>
          <Text type="danger">{t("bidsLoadError")}</Text>
          <br />
          <Button icon={<ReloadOutlined />} onClick={() => refetch()} style={{ marginTop: 10 }}>{t("bidsRetry")}</Button>
        </div>
      ) : (
        <Table
          dataSource={documents}
          columns={columns}
          rowKey="id"
          pagination={false}
        />
      )}
    </div>
  );
}
