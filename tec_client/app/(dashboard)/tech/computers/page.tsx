"use client";

import { useMemo, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import {
  Table,
  Input,
  Select,
  Button,
  Drawer,
  Descriptions,
  Tooltip,
  Alert,
} from "antd";
import type { ColumnsType } from "antd/es/table";
import { SearchOutlined } from "@ant-design/icons";

interface OfficeComputer {
  id: number;
  invNum: string;
  networkName: string;
  phone: string;
  name: string;
  department: string;
  userDep: string;
  userFio: string;
  cpu: string;
  ram1: string;
  ram2: string;
  hdd1: string;
  hdd2: string;
  optical: string;
  video: string;
  audio: string;
  speakers: string;
  monitor: string;
  inputMonth: string;
  inputYear: string;
}

const HeaderFilter = ({
  title,
  children,
}: {
  title: string;
  children: React.ReactNode;
}) => (
  <div style={{ display: "flex", flexDirection: "column", gap: 4 }}>
    <span>{title}</span>
    <div onClick={(e) => e.stopPropagation()}>{children}</div>
  </div>
);

const includes = (value: string, query: string): boolean =>
  value.toLowerCase().includes(query.trim().toLowerCase());

export default function OfficeComputersPage() {
  const { data = [], isLoading, error } = useQuery<OfficeComputer[]>({
    queryKey: ["office-computers"],
    queryFn: async () => {
      const res = await axios.get<OfficeComputer[]>("/api/OfficeComputers", {
        withCredentials: true,
      });
      return res.data;
    },
    staleTime: 5 * 60 * 1000,
  });

  const [inv, setInv] = useState("");
  const [net, setNet] = useState("");
  const [phone, setPhone] = useState("");
  const [dept, setDept] = useState<string | undefined>(undefined);
  const [selected, setSelected] = useState<OfficeComputer | null>(null);

  const departments = useMemo<string[]>(
    () =>
      Array.from(
        new Set(data.map((d: OfficeComputer) => d.department).filter(Boolean))
      ).sort(),
    [data]
  );

  const rows = useMemo<OfficeComputer[]>(
    () =>
      data.filter(
        (d: OfficeComputer) =>
          includes(d.invNum, inv) &&
          includes(d.networkName, net) &&
          includes(d.phone, phone) &&
          (!dept || d.department === dept)
      ),
    [data, inv, net, phone, dept]
  );

  const columns: ColumnsType<OfficeComputer> = [
    {
      title: (
        <HeaderFilter title="Инвентарный номер">
          <Input size="small" value={inv} onChange={(e) => setInv(e.target.value)} />
        </HeaderFilter>
      ),
      dataIndex: "invNum",
      width: 150,
    },
    {
      title: (
        <HeaderFilter title="Сетевое имя">
          <Input size="small" value={net} onChange={(e) => setNet(e.target.value)} />
        </HeaderFilter>
      ),
      dataIndex: "networkName",
      width: 140,
    },
    {
      title: (
        <HeaderFilter title="Номер телефона">
          <Input size="small" value={phone} onChange={(e) => setPhone(e.target.value)} />
        </HeaderFilter>
      ),
      dataIndex: "phone",
      width: 130,
    },
    { title: "Наименование", dataIndex: "name", ellipsis: true },
    {
      title: (
        <HeaderFilter title="Отдел">
          <Select
            size="small"
            allowClear
            value={dept}
            onChange={(v: string | undefined) => setDept(v)}
            style={{ width: "100%" }}
            options={departments.map((d) => ({ value: d, label: d }))}
          />
        </HeaderFilter>
      ),
      dataIndex: "department",
      ellipsis: true,
    },
    { title: "Пользователь", dataIndex: "userDep", width: 140 },
    { title: "ФИО пользователя", dataIndex: "userFio", ellipsis: true },
    {
      title: "Введен в эксплуатацию",
      width: 150,
      render: (_: unknown, r: OfficeComputer) =>
        r.inputMonth || r.inputYear ? `${r.inputMonth}-${r.inputYear}` : "",
    },
    {
      title: "Действия",
      width: 90,
      align: "center",
      render: (_: unknown, r: OfficeComputer) => (
        <Tooltip title="Подробнее">
          <Button
            type="text"
            icon={<SearchOutlined />}
            onClick={() => setSelected(r)}
          />
        </Tooltip>
      ),
    },
  ];

  return (
    <>
      {error && (
        <Alert
          type="error"
          showIcon
          message="Не удалось загрузить список техники"
          style={{ marginBottom: 16 }}
        />
      )}

      <Table<OfficeComputer>
        rowKey="id"
        size="small"
        loading={isLoading}
        columns={columns}
        dataSource={rows}
        pagination={{ pageSize: 25, showSizeChanger: false }}
        scroll={{ x: 1200 }}
      />

      <Drawer
        open={!!selected}
        onClose={() => setSelected(null)}
        width={480}
        title={selected?.name}
      >
        {selected && (
          <Descriptions column={1} size="small" bordered>
            <Descriptions.Item label="Процессор">{selected.cpu}</Descriptions.Item>
            <Descriptions.Item label="ОЗУ 1">{selected.ram1}</Descriptions.Item>
            <Descriptions.Item label="ОЗУ 2">{selected.ram2}</Descriptions.Item>
            <Descriptions.Item label="HDD 1">{selected.hdd1}</Descriptions.Item>
            <Descriptions.Item label="HDD 2">{selected.hdd2}</Descriptions.Item>
            <Descriptions.Item label="Оптический привод">{selected.optical}</Descriptions.Item>
            <Descriptions.Item label="Видео">{selected.video}</Descriptions.Item>
            <Descriptions.Item label="Аудио">{selected.audio}</Descriptions.Item>
            <Descriptions.Item label="Колонки">{selected.speakers}</Descriptions.Item>
            <Descriptions.Item label="Монитор">{selected.monitor}</Descriptions.Item>
          </Descriptions>
        )}
      </Drawer>
    </>
  );
}