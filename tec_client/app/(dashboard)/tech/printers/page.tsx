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

export default function OfficePrintersPage() {

    const router = useRouter()

    const { data = [], isLoading, error } = useQuery<OfficeEquipment[]>({
        queryKey: ["office-printers"],
        queryFn: async () => (await $api.get<OfficeEquipment[]>("/OfficeEquipment/printers")).data,
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
            title: <HeaderFilter title="Наименование / Модель"><Input size="small" placeholder="Фильтр..." value={nameQuery} onChange={(e) => setNameQuery(e.target.value)} allowClear /></HeaderFilter>,
            dataIndex: "name",
            ellipsis: true,
            width: 260,
            render: (val) => <Text strong>{val || "—"}</Text>,
        },
        {
            title: <HeaderFilter title="Отдел"><Select size="small" allowClear showSearch placeholder="Все отделы" value={dept} onChange={setDept} style={{ width: "100%" }} options={departments.map((d) => ({ value: d, label: d }))} optionFilterProp="label" /></HeaderFilter>,
            dataIndex: "department",
            ellipsis: true,
            width: 220,
        },
        { title: <div style={{ padding: "16px 0 6px" }}>Сотрудник / Место</div>, dataIndex: "userDep", width: 180, ellipsis: true },
        { title: <div style={{ padding: "16px 0 6px" }}>Картридж</div>, dataIndex: "typeCartr", width: 130, ellipsis: true, render: (val) => val ? <Text code>{val}</Text> : "—" },
        { title: <div style={{ padding: "16px 0 6px" }}>Заправок</div>, dataIndex: "numZapr", width: 90, align: "center", render: (val) => val || "0" },
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
                {/* <Title level={3} style={{ margin: 0, display: "flex", alignItems: "center", gap: 10 }}>
                    <PrinterOutlined /> Принтеры и оргтехника
                </Title>
                <Text type="secondary">Реестр печатающих устройств и картриджей ТЭЦ</Text> */}
                <div style={{ marginBottom: 20, display: "flex", justifyContent: "space-between", alignItems: "center" }}>
                    <div>
                        <Title level={3} style={{ margin: 0, display: "flex", alignItems: "center", gap: 10 }}>
                            Принтеры
                        </Title>
                        <Text type="secondary">Реестр принтеров/МФУ/сканеров ТЭЦ</Text>
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
            <Drawer open={!!selected} onClose={() => setSelected(null)} width={520} title={<Space><PrinterOutlined style={{ color: "#4f46e5" }} /><span>{selected?.name}</span></Space>}>
                {selected && (
                    <div style={{ display: "flex", flexDirection: "column", gap: 20 }}>
                        <Descriptions title="Размещение" column={1} size="small" bordered>
                            <Descriptions.Item label="Инвентарный номер"><Text code>{selected.invNum || "—"}</Text></Descriptions.Item>
                            <Descriptions.Item label="Наименование"><Text strong>{selected.name || "—"}</Text></Descriptions.Item>
                            <Descriptions.Item label="Отдел">{selected.department || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Ответственный / Место">{selected.userDep || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Серийный номер"><Text code>{selected.serialNumber || "—"}</Text></Descriptions.Item>
                        </Descriptions>
                        <Descriptions title="Расходные материалы" column={1} size="small" bordered>
                            <Descriptions.Item label="Тип картриджа"><Text code>{selected.typeCartr || "—"}</Text></Descriptions.Item>
                            <Descriptions.Item label="Количество заправок">{selected.numZapr || "0"}</Descriptions.Item>
                            <Descriptions.Item label="Тип селена">{selected.typeSelen || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Замена селена">{selected.replaceSelen === "1" ? "Да" : "Нет"}</Descriptions.Item>
                            <Descriptions.Item label="Тип тонера">{selected.typeToner || "—"}</Descriptions.Item>
                            <Descriptions.Item label="Количество тонера">{selected.kolToner || "0"}</Descriptions.Item>
                        </Descriptions>
                    </div>
                )}
            </Drawer>
        </div>
    );
}