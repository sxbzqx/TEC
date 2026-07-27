"use client";

import { useState } from "react";
import { Worker } from "@/types/worker";
import { $api } from "@/app/api/api";
import { useQuery } from "@tanstack/react-query";
import {
  Table,
  Input,
  Select,
  Button,
  Card,
  Typography,
  Alert,
  Space,
  TableColumnsType,
} from "antd";
import { PrinterOutlined, SearchOutlined } from "@ant-design/icons";
import { useLocale } from "@/context/LocaleContext";

const { Title, Text } = Typography;

const fetchWorkers = async () => {
  const response = await $api.get<Worker[]>("/workers");
  return response.data;
};

export default function WorkersList() {
  const { t } = useLocale();
  const {
    data: workers = [],
    isLoading,
    error,
  } = useQuery<Worker[], Error>({
    queryKey: ["workers"],
    queryFn: fetchWorkers,
  });

  const [searchQuery, setSearchQuery] = useState<string>("");
  const [selectedOtdel, setSelectedOtdel] = useState<string>("");


  const uniqueOtdels = Array.from(
    new Set(workers.map((w) => w.otdel?.trim())),
  ).filter(Boolean) as string[];


  const filteredWorkers = workers.filter((worker) => {
    const matchesSearch = worker.fio
      ? worker.fio.toLowerCase().includes(searchQuery.toLowerCase())
      : false;
    const matchesOtdel = selectedOtdel
      ? worker.otdel?.trim() === selectedOtdel
      : true;
    return matchesSearch && matchesOtdel;
  });

  const formatDate = (dateString: string) => {
    if (!dateString) return "—";
    const date = new Date(dateString);
    return new Intl.DateTimeFormat("ru-RU", {
      day: "2-digit",
      month: "2-digit",
      year: "numeric",
    }).format(date);
  };


  const columns: TableColumnsType<Worker> = [
    { title: t("colTabel"), dataIndex: "tabel", key: "tabel", width: 100 },
    {
      title: t("colFio"),
      dataIndex: "fio",
      key: "fio",
      sorter: (a, b) => a.fio.localeCompare(b.fio),
      defaultSortOrder: 'ascend',
      render: (text: string) => <Text strong>{text}</Text>,
    },
    {
      title: t("colPosition"),
      dataIndex: "doljnost",
      key: "doljnost",
      render: (text: string) => (
        <span
          style={{
            backgroundColor: "var(--info-soft)",
            color: "var(--info-dark)",
            padding: "4px 8px",
            borderRadius: "4px",
            fontSize: "12px",
            fontWeight: 500,
          }}
        >
          {text}
        </span>
      ),
    },
    {
      title: t("colDept"),
      dataIndex: "otdel",
      key: "otdel",
      render: (text: string) => text?.trim(),
    },
    { title: t("colCategory"), dataIndex: "kategoriyaName", key: "kategoriyaName" },
    {
      title: t("colPhone"),
      dataIndex: "phone",
      key: "phone",
      render: (text: string) => text || "—",
    },
    {
      title: t("colDr"),
      dataIndex: "dr",
      key: "dr",
      render: (text: string) => formatDate(text),
    },
    {
      title: t("colHired"),
      dataIndex: "datePriem",
      key: "datePriem",
      render: (text: string) => formatDate(text),
    },
  ];

  if (error) {
    const backendMessage = (error as any).response?.data?.message;
    return (
      <div style={{ padding: "24px" }}>
        <Alert
          message={t("workersLoadError")}
          description={
            backendMessage ||
            error.message ||
            t("workersLoadErrorFallback")
          }
          type="error"
          showIcon
        />
      </div>
    );
  }

  return (
    <div style={{ padding: "12px", fontFamily: "sans-serif" }}>
      {/* Стили для адаптации таблицы под распечатку на принтере */}
      <style>{`
        @media print {
          header, .no-print, .ant-pagination {
            display: none !important;
          }
          body {
            background: #fff !important;
            padding: 0 !important;
          }
          .ant-card {
            box-shadow: none !important;
            padding: 0 !important;
          }
          .ant-table {
            color: #000 !important;
          }
          .ant-table-thead > tr > th {
            background: #f5f5f5 !important;
            border: 1px solid #000 !important;
          }
          .ant-table-tbody > tr > td {
            border: 1px solid #000 !important;
          }
        }
      `}</style>

      <Title level={3} style={{ marginBottom: "24px", color: "var(--ink)" }}>
        {t("workersTitle")}
      </Title>

      {/* Панель фильтров (скрывается при печати) */}
      <Card
        className="no-print"
        size="small"
        style={{
          marginBottom: "24px",
          borderRadius: "8px",
          boxShadow: "0 2px 8px rgba(0,0,0,0.04)",
        }}
      >
        <Space
          wrap
          size="middle"
          style={{ width: "100%", justifyContent: "space-between" }}
        >
          <Space wrap size="middle">
            <div style={{ width: 280 }}>
              <Text strong style={{ display: "block", marginBottom: 6 }}>
                {t("workersSearchLabel")}
              </Text>
              <Input
                placeholder={t("workersSearchPlaceholder")}
                prefix={<SearchOutlined style={{ color: "var(--ink-faint)" }} />}
                value={searchQuery}
                onChange={(e) => setSearchQuery(e.target.value)}
                size="large"
              />
            </div>

            <div style={{ width: 220 }}>
              <Text strong style={{ display: "block", marginBottom: 6 }}>
                {t("workersDeptLabel")}
              </Text>
              <Select
                value={selectedOtdel}
                onChange={(value) => setSelectedOtdel(value)}
                style={{ width: "100%" }}
                size="large"
                placeholder={t("workersAllDepts")}
              >
                <Select.Option value="">{t("workersAllDepts")}</Select.Option>
                {uniqueOtdels.map((name) => (
                  <Select.Option key={name} value={name}>
                    {name}
                  </Select.Option>
                ))}
              </Select>
            </div>
          </Space>

          <Button
            type="primary"
            icon={<PrinterOutlined />}
            onClick={() => window.print()}
            style={{
              backgroundColor: "#319795",
              borderColor: "#319795",
              height: 40,
              marginTop: 22,
            }}
            size="large"
          >
            {t("workersPrint")}
          </Button>
        </Space>
      </Card>

      <div className="no-print" style={{ marginBottom: 16 }}>
        <Text type="secondary">{t("workersFoundLabel")} </Text>
        <Text strong>{filteredWorkers.length}</Text>
      </div>

      {}
      <Card
        variant="borderless"
        style={{
          boxShadow: "0 4px 12px rgba(0,0,0,0.05)",
          borderRadius: "12px",
        }}
      >
        <Table
          dataSource={filteredWorkers}
          columns={columns}
          rowKey="id"
          loading={isLoading}
          pagination={{ pageSize: 10, placement: ["bottomCenter"] }}
          scroll={{ x: 900 }}
        />
      </Card>
    </div>
  );
}
