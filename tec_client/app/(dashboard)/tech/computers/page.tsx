"use client";

import { useMemo, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { Table, Input, Select, Button, Drawer, Descriptions, Tooltip, Alert, Card, Space, Typography } from "antd";
import type { ColumnsType } from "antd/es/table";
import { EyeOutlined, PrinterOutlined, EditOutlined, DesktopOutlined } from "@ant-design/icons";
import { $api } from "@/app/api/api";
import { OfficeEquipment } from "@/types/officeEquipment";
import { useRouter } from "next/navigation";

const { Title, Text } = Typography;

const HeaderFilter = ({ title, children }: { title: string; children: React.ReactNode }) => (
  <div style={{ display: "flex", flexDirection: "column", gap: 6, paddingTop: 4, paddingBottom: 4 }} onClick={(e) => e.stopPropagation()} onMouseDown={(e) => e.stopPropagation()}>
    <Text strong style={{ fontSize: 13, color: "#262626" }}>{title}</Text>
    {children}
  </div>
);

const includes = (value: string | null, query: string): boolean =>
  (value ?? "").toLowerCase().includes(query.trim().toLowerCase());

export default function OfficeComputersPage() {

  const router = useRouter()

  const { data = [], isLoading, error } = useQuery<OfficeEquipment[]>({
    queryKey: ["office-computers"],
    queryFn: async () => (await $api.get<OfficeEquipment[]>("/OfficeEquipment/computers")).data,
    staleTime: 5 * 60 * 1000,
  });

  const [inv, setInv] = useState("");
  const [nameQuery, setNameQuery] = useState("");
  const [dept, setDept] = useState<string | undefined>(undefined);
  const [selected, setSelected] = useState<OfficeEquipment | null>(null);

  const departments = useMemo(() => Array.from(new Set(data.map((d) => d.department).filter(Boolean))).sort() as string[], [data]);
  const rows = useMemo(() => data.filter((d) => includes(d.invNum, inv) && includes(d.name, nameQuery) && (!dept || d.department === dept)), [data, inv, nameQuery, dept]);

  const columns: ColumnsType<OfficeEquipment> = [
    {
      title: <HeaderFilter title="Инвентарный номер"><Input size="small" placeholder="Фильтр..." value={inv} onChange={(e) => setInv(e.target.value)} allowClear /></HeaderFilter>,
      dataIndex: "invNum",
      width: 140,
      render: (val) => <Text code>{val || "—"}</Text>,
    },
    {
      title: <HeaderFilter title="Конфигурация / Название"><Input size="small" placeholder="Фильтр..." value={nameQuery} onChange={(e) => setNameQuery(e.target.value)} allowClear /></HeaderFilter>,
      dataIndex: "name",
      ellipsis: true,
      width: 280,
      render: (val) => <Text strong>{val || "—"}</Text>,
    },
    {
      title: <HeaderFilter title="Отдел"><Select size="small" allowClear showSearch placeholder="Все отделы" value={dept} onChange={setDept} style={{ width: "100%" }} options={departments.map((d) => ({ value: d, label: d }))} optionFilterProp="label" /></HeaderFilter>,
      dataIndex: "department",
      ellipsis: true,
      width: 220,
    },
    { title: <div style={{ padding: "16px 0 6px" }}>Сотрудник</div>, dataIndex: "userFio", width: 180, ellipsis: true },
    { title: <div style={{ padding: "16px 0 6px" }}>Процессор</div>, dataIndex: "cpu", width: 180, ellipsis: true, render: (val) => val ? <Text code>{val}</Text> : "—" },
    { title: <div style={{ padding: "16px 0 6px" }}>ОЗУ</div>, dataIndex: "ram1", width: 100, ellipsis: true, render: (val) => val || "—" },
    {
      title: <div style={{ padding: "16px 0 6px" }}>Действия</div>,
      width: 90,
      align: "center",
      render: (_, r: OfficeEquipment) => (
        <Tooltip title="Редактировать характеристики">
          <Button
            type="text"
            icon={<EditOutlined style={{ color: "#4f46e5" }} />}
            onClick={() => router.push(`/tech/${r.id}`)}
          />
        </Tooltip>
      ),
    }
  ];

  return (
    <div style={{ padding: "24px" }}>
      <div style={{ marginBottom: 20 }}>
        <div style={{ marginBottom: 20, display: "flex", justifyContent: "space-between", alignItems: "center" }}>
          <div>
            <Title level={3} style={{ margin: 0, display: "flex", alignItems: "center", gap: 10 }}>
               Компьютеры
            </Title>
            <Text type="secondary">Реестр персональных компьютеров ТЭЦ</Text>
          </div>
          <Button type="primary" onClick={() => router.push("/tech/new")}>
            + Добавить оборудование
          </Button>
        </div>
      </div>
      {error && <Alert type="error" showIcon message="Ошибка загрузки данных" style={{ marginBottom: 16 }} />}
      <Card bodyStyle={{ padding: 0 }} style={{ borderRadius: 8, border: "1px solid #e5e7eb" }}>
        <Table rowKey="id" size="middle" bordered loading={isLoading} columns={columns} dataSource={rows} pagination={{ pageSize: 20 }} scroll={{ x: 1200 }} />
      </Card>
      <Drawer open={!!selected} onClose={() => setSelected(null)} width={520} title={<Space><DesktopOutlined style={{ color: "#4f46e5" }} /><span>{selected?.name}</span></Space>}>
        {selected && (
          <div style={{ display: "flex", flexDirection: "column", gap: 20 }}>
            <Descriptions title="Основное" column={1} size="small" bordered>
              <Descriptions.Item label="Инвентарный номер"><Text code>{selected.invNum || "—"}</Text></Descriptions.Item>
              <Descriptions.Item label="Сетевое имя"><Text code>{selected.networkName || "—"}</Text></Descriptions.Item>
              <Descriptions.Item label="Отдел">{selected.department || "—"}</Descriptions.Item>
              <Descriptions.Item label="Сотрудник">{selected.userFio || "—"}</Descriptions.Item>
              <Descriptions.Item label="Телефон"><Text code>{selected.phone || "—"}</Text></Descriptions.Item>
            </Descriptions>
            <Descriptions title="Железо" column={1} size="small" bordered>
              <Descriptions.Item label="Процессор"><Text code>{selected.cpu || "—"}</Text></Descriptions.Item>
              <Descriptions.Item label="Оперативная память (RAM 1)">{selected.ram1 || "—"}</Descriptions.Item>
              <Descriptions.Item label="Оперативная память (RAM 2)">{selected.ram2 || "—"}</Descriptions.Item>
              <Descriptions.Item label="Диск 1 (HDD/SSD)">{selected.hdd1 || "—"}</Descriptions.Item>
              <Descriptions.Item label="Диск 2">{selected.hdd2 || "—"}</Descriptions.Item>
              <Descriptions.Item label="Видеокарта">{selected.video || "—"}</Descriptions.Item>
              <Descriptions.Item label="Монитор">{selected.monitor || "—"}</Descriptions.Item>
            </Descriptions>
          </div>
        )}
      </Drawer>
    </div>
  );
}