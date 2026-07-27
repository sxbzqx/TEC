"use client";

import React, { useState, useMemo } from "react";
import { useQuery } from "@tanstack/react-query";
import { $api } from "@/app/api/api";
import { Biznesplan } from "@/types/biznesplan";
import { Spin, Alert, Table, Input, Select, Typography, Space } from "antd";
import { useLocale } from "@/context/LocaleContext";

const { Title } = Typography;
const { Option } = Select;

export default function BusinessPlansList() {
  const { t } = useLocale();
  const [searchQuery, setSearchQuery] = useState<string>("");
  const [selectedYear, setSelectedYear] = useState<string>("");
  const [selectedType, setSelectedType] = useState<string>("");
  const [currentPage, setCurrentPage] = useState<number>(1);
  const itemsPerPage = 10;

  // 1. React Query запрос
  const { data: plans = [], isLoading, error } = useQuery({
    queryKey: ["biznesplans"],
    queryFn: async () => {
      const response = await $api.get("/biznesplan");
      return response.data as Biznesplan[];
    },
  });

  // 2. Мемоизация фильтров
  const uniqueYears = useMemo(() =>
    Array.from(new Set(plans.map((p) => p.year.trim()))).filter(Boolean).sort((a, b) => b.localeCompare(a)),
    [plans]
  );

  const uniqueTypes = useMemo(() =>
    Array.from(new Set(plans.map((p) => p.typeBp.trim()))).filter(Boolean).sort(),
    [plans]
  );

  // 3. Логика фильтрации
  const filteredPlans = useMemo(() => {
    return plans.filter((plan) => {
      const matchesSearch = plan.comment?.toLowerCase().includes(searchQuery.toLowerCase()) ?? true;
      const matchesYear = selectedYear ? plan.year.trim() === selectedYear : true;
      const matchesType = selectedType ? plan.typeBp.trim() === selectedType : true;
      return matchesSearch && matchesYear && matchesType;
    });
  }, [plans, searchQuery, selectedYear, selectedType]);

  // Сброс страницы при изменении фильтров
  React.useEffect(() => {
    setCurrentPage(1);
  }, [searchQuery, selectedYear, selectedType]);

  const currentPlans = filteredPlans.slice((currentPage - 1) * itemsPerPage, currentPage * itemsPerPage);
  const totalPages = Math.ceil(filteredPlans.length / itemsPerPage);

  // 4. Отработка состояний
  if (isLoading) return <div style={{ padding: 50, textAlign: "center" }}><Spin size="large" /></div>;
  if (error) return <Alert message={t("bizLoadError")} description={(error as Error).message} type="error" showIcon />;

  return (
    <div style={{ padding: "24px", backgroundColor: "var(--bg)"}}>
      <Title level={2}>{t("bizTitle")}</Title>

      {/* Панель фильтров */}
      <Space wrap style={{ marginBottom: 24, padding: 16, background: "var(--surface)", borderRadius: 8 }}>
        <Input
          placeholder={t("bizSearchPlaceholder")}
          onChange={(e) => setSearchQuery(e.target.value)}
          style={{ width: 250 }}
        />
        <Select placeholder={t("bizYear")} allowClear onChange={setSelectedYear} style={{ width: 120 }}>
          {uniqueYears.map(y => <Option key={y} value={y}>{y}</Option>)}
        </Select>
        <Select placeholder={t("bizType")} allowClear onChange={setSelectedType} style={{ width: 120 }}>
          {uniqueTypes.map(type => <Option key={type} value={type}>{type}</Option>)}
        </Select>
      </Space>

      {/* Таблица */}
      <div style={{ background: "var(--surface)", padding: 16, borderRadius: 8 }}>
        <Table
          dataSource={currentPlans}
          rowKey="id"
          pagination={false}
          columns={[
            { title: t("colId"), dataIndex: "id" },
            { title: t("colYear"), dataIndex: "year" },
            { title: t("colType"), dataIndex: "typeBp" },
            { title: t("colComment"), dataIndex: "comment" },
            { title: t("colCreatedDate"), dataIndex: "datecreate", render: (d) => new Date(d).toLocaleString() }
          ]}
        />

        {/* Пагинация */}
        <div style={{ marginTop: 20, textAlign: "center" }}>
          <Space>
            <button disabled={currentPage === 1} onClick={() => setCurrentPage(p => p - 1)}>{t("bizPrev")}</button>
            <span>{currentPage} {t("bizPageOf")} {totalPages || 1}</span>
            <button disabled={currentPage === totalPages} onClick={() => setCurrentPage(p => p + 1)}>{t("bizNext")}</button>
          </Space>
        </div>
      </div>
    </div>
  );
}
