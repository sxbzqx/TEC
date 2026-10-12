"use client";

import { useMemo, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import {
    Table,
    Input,
    Select,
    Button,
    Drawer,
    Descriptions,
    Tooltip,
    Alert,
    Card,
    Space,
    Typography,
} from "antd";
import type { ColumnsType } from "antd/es/table";
import { EyeOutlined, LaptopOutlined } from "@ant-design/icons";
import { $api } from "@/app/api/api";
import { OfficeComputer } from "@/types/officeComputer";

const { Title, Text } = Typography;

interface OfficeLaptop {
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
    <div
        style={{ display: "flex", flexDirection: "column", gap: 6, paddingTop: 4, paddingBottom: 4 }}
        onClick={(e) => e.stopPropagation()}
        onMouseDown={(e) => e.stopPropagation()}
    >
        <Text strong style={{ fontSize: 13, color: "#262626" }}>{title}</Text>
        {children}
    </div>
);

const includes = (value: string, query: string): boolean =>
    value.toLowerCase().includes(query.trim().toLowerCase());

export default function OfficeLaptopsPage() {
    const { data = [], isLoading, error } = useQuery<OfficeComputer[]>({
        queryKey: ["office-laptops"],
        queryFn: async () => {
            const res = await $api.get<OfficeComputer[]>("/OfficeEquipment/laptops");
            return res.data;
        },
        staleTime: 5 * 60 * 1000,
    });

    const [inv, setInv] = useState("");
    const [net, setNet] = useState("");
    const [phone, setPhone] = useState("");
    const [dept, setDept] = useState<string | undefined>(undefined);
    const [selected, setSelected] = useState<OfficeLaptop | null>(null);

    const departments = useMemo<string[]>(
        () =>
            Array.from(
                new Set(data.map((d: OfficeLaptop) => d.department).filter(Boolean))
            ).sort(),
        [data]
    );

    const rows = useMemo<OfficeLaptop[]>(
        () =>
            data.filter(
                (d: OfficeLaptop) =>
                    includes(d.invNum, inv) &&
                    includes(d.networkName, net) &&
                    includes(d.phone, phone) &&
                    (!dept || d.department === dept)
            ),
        [data, inv, net, phone, dept]
    );

    const columns: ColumnsType<OfficeLaptop> = [
        {
            title: (
                <HeaderFilter title="Инвентарный номер">
                    <Input
                        size="small"
                        placeholder="Фильтр..."
                        value={inv}
                        onChange={(e) => setInv(e.target.value)}
                        allowClear
                    />
                </HeaderFilter>
            ),
            dataIndex: "invNum",
            width: 150,
            render: (val) => <Text code>{val || "—"}</Text>,
        },
        {
            title: (
                <HeaderFilter title="Сетевое имя">
                    <Input
                        size="small"
                        placeholder="Фильтр..."
                        value={net}
                        onChange={(e) => setNet(e.target.value)}
                        allowClear
                    />
                </HeaderFilter>
            ),
            dataIndex: "networkName",
            width: 140,
            render: (val) => <Text strong>{val || "—"}</Text>,
        },
        {
            title: (
                <HeaderFilter title="Телефон">
                    <Input
                        size="small"
                        placeholder="Фильтр..."
                        value={phone}
                        onChange={(e) => setPhone(e.target.value)}
                        allowClear
                    />
                </HeaderFilter>
            ),
            dataIndex: "phone",
            width: 120,
        },
        {
            title: <div style={{ padding: "16px 0 6px" }}>Наименование</div>,
            dataIndex: "name",
            ellipsis: true,
            width: 220,
        },
        {
            title: (
                <HeaderFilter title="Отдел">
                    <Select
                        size="small"
                        allowClear
                        showSearch
                        placeholder="Все отделы"
                        value={dept}
                        onChange={(v: string | undefined) => setDept(v)}
                        style={{ width: "100%" }}
                        options={departments.map((d) => ({ value: d, label: d }))}
                        optionFilterProp="label"
                    />
                </HeaderFilter>
            ),
            dataIndex: "department",
            ellipsis: true,
            width: 220,
        },
        {
            title: <div style={{ padding: "16px 0 6px" }}>Пользователь</div>,
            dataIndex: "userDep",
            width: 150,
            ellipsis: true,
        },
        {
            title: <div style={{ padding: "16px 0 6px" }}>ФИО пользователя</div>,
            dataIndex: "userFio",
            ellipsis: true,
            width: 200,
        },
        {
            title: <div style={{ padding: "16px 0 6px" }}>В эксплуатации</div>,
            width: 130,
            render: (_: unknown, r: OfficeLaptop) =>
                r.inputMonth || r.inputYear ? (
                    <Text type="secondary" style={{ fontSize: 12 }}>
                        {r.inputMonth} {r.inputYear}
                    </Text>
                ) : "—",
        },
        {
            title: <div style={{ padding: "16px 0 6px" }}>Действия</div>,
            width: 90,
            align: "center",
            render: (_: unknown, r: OfficeLaptop) => (
                <Tooltip title="Просмотреть характеристики">
                    <Button
                        type="text"
                        icon={<EyeOutlined style={{ color: "#4f46e5" }} />}
                        onClick={() => setSelected(r)}
                    />
                </Tooltip>
            ),
        },
    ];

    return (
        <div style={{ padding: "24px" }}>
            <div style={{ marginBottom: 20, display: "flex", justifyContent: "space-between", alignItems: "center" }}>
                <div>
                    <Title level={3} style={{ margin: 0, display: "flex", alignItems: "center", gap: 10 }}>
                        <LaptopOutlined /> Учет ноутбуков
                    </Title>
                    <Text type="secondary">Реестр переносных персональных компьютеров и ноутбуков ТЭЦ</Text>
                </div>
            </div>

            {error && (
                <Alert
                    type="error"
                    showIcon
                    message="Не удалось загрузить список ноутбуков с сервера"
                    style={{ marginBottom: 16 }}
                />
            )}

            <Card
                bodyStyle={{ padding: 0 }}
                bordered={true}
                style={{
                    border: "1px solid #e5e7eb",
                    boxShadow: "0 1px 3px 0 rgba(0, 0, 0, 0.02)",
                    borderRadius: 8,
                    overflow: "hidden"
                }}
            >
                <Table<OfficeLaptop>
                    rowKey="id"
                    size="middle"
                    bordered
                    loading={isLoading}
                    columns={columns}
                    dataSource={rows}
                    pagination={{ pageSize: 20, showSizeChanger: true, pageSizeOptions: ["10", "20", "50"] }}
                    scroll={{ x: 1300 }}
                />
            </Card>

            <Drawer
                open={!!selected}
                onClose={() => setSelected(null)}
                width={520}
                title={
                    <Space>
                        <LaptopOutlined style={{ color: "#4f46e5" }} />
                        <span>{selected?.name || "Информация о ноутбуке"}</span>
                    </Space>
                }
            >
                {selected && (
                    <div style={{ display: "flex", flexDirection: "column", gap: 20 }}>
                        <Descriptions title="Параметры владельца" column={1} size="small" bordered>
                            <Descriptions.Item label="Инвентарный номер">
                                <Text code>{selected.invNum || "—"}</Text>
                            </Descriptions.Item>
                            <Descriptions.Item label="Сетевое имя">
                                <Text strong>{selected.networkName || "—"}</Text>
                            </Descriptions.Item>
                            <Descriptions.Item label="Отдел">{selected.department || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Подразделение / Склад">{selected.userDep || "—"}</Descriptions.Item>
                            <Descriptions.Item label="ФИО сотрудника">{selected.userFio || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Телефон">{selected.phone || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Ввод в эксплуатацию">
                                {selected.inputMonth || selected.inputYear ? `${selected.inputMonth} ${selected.inputYear}` : "Не указано"}
                            </Descriptions.Item>
                        </Descriptions>

                        <Descriptions title="Аппаратная база" column={1} size="small" bordered>
                            <Descriptions.Item label="Процессор">{selected.cpu || "—"}</Descriptions.Item>
                            <Descriptions.Item label="ОЗУ (Слот 1)">{selected.ram1 || "—"}</Descriptions.Item>
                            <Descriptions.Item label="ОЗУ (Слот 2)">{selected.ram2 || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Накопитель (HDD/SSD 1)">{selected.hdd1 || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Накопитель (HDD/SSD 2)">{selected.hdd2 || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Видеокарта">{selected.video || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Монитор">{selected.monitor || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Оптический привод">{selected.optical || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Аудиоустройство">{selected.audio || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Колонки">{selected.speakers || "—"}</Descriptions.Item>
                        </Descriptions>
                    </div>
                )}
            </Drawer>
        </div>
    );
}