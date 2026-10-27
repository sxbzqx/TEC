"use client";

import { useEffect } from "react";
import { useParams, useRouter } from "next/navigation";
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { Form, Input, Button, Card, Typography, Space, message, Select, Popconfirm } from "antd";
import { ArrowLeftOutlined, SaveOutlined, DeleteOutlined } from "@ant-design/icons";
import { $api } from "@/app/api/api";
import { OfficeEquipment } from "@/types/officeEquipment";

const { Title } = Typography;

export default function OfficeEquipmentEditorPage() {
    const params = useParams();
    const router = useRouter();
    const queryClient = useQueryClient();
    const [form] = Form.useForm<OfficeEquipment>();

    const id = params.id as string;
    const isNew = id === "new";

    const { data: item, isLoading } = useQuery<OfficeEquipment>({
        queryKey: ["office-equipment", id],
        queryFn: async () => (await $api.get<OfficeEquipment>(`/OfficeEquipment/${id}`)).data,
        enabled: !isNew,
    });

    useEffect(() => {
        if (item) {
            form.setFieldsValue(item);
        }
    }, [item, form]);

    const saveMutation = useMutation({
        mutationFn: async (values: OfficeEquipment) => {
            if (isNew) {
                return await $api.post("/OfficeEquipment", { ...values, type: "computer" }); // дефолтный тип или селект
            } else {
                return await $api.put(`/OfficeEquipment/${id}`, values);
            }
        },
        onSuccess: () => {
            message.success(isNew ? "Оборудование успешно добавлено" : "Изменения сохранены");
            queryClient.invalidateQueries({ queryKey: ["office-computers"] });
            router.back();
        },
        onError: () => message.error("Ошибка при сохранении"),
    });

    const deleteMutation = useMutation({
        mutationFn: async () => await $api.delete(`/OfficeEquipment/${id}`),
        onSuccess: () => {
            message.success("Оборудование удалено");
            queryClient.invalidateQueries({ queryKey: ["office-computers"] });
            router.back();
        },
        onError: () => message.error("Не удалось удалить запись"),
    });

    return (
        <div style={{ padding: 24, maxWidth: 800, margin: "0 auto" }}>
            <Space style={{ marginBottom: 20 }}>
                <Button icon={<ArrowLeftOutlined />} onClick={() => router.back()}>Назад</Button>
                <Title level={3} style={{ margin: 0 }}>
                    {isNew ? "Добавить оборудование" : `Редактирование: ${item?.name || ""}`}
                </Title>
            </Space>

            <Card loading={isLoading} style={{ borderRadius: 8, border: "1px solid #e5e7eb" }}>
                <Form form={form} layout="vertical" onFinish={(vals) => saveMutation.mutate(vals)}>
                    <Form.Item name="type" label="Тип оборудования" rules={[{ required: true }]}>
                        <Select options={[
                            { value: "computer", label: "Компьютер" },
                            { value: "laptop", label: "Ноутбук" },
                            { value: "printer", label: "Принтер" },
                            { value: "other", label: "Прочее" },
                        ]} />
                    </Form.Item>

                    <Form.Item name="invNum" label="Инвентарный номер">
                        <Input />
                    </Form.Item>

                    <Form.Item name="name" label="Наименование / Модель" rules={[{ required: true }]}>
                        <Input />
                    </Form.Item>

                    <Form.Item name="department" label="Отдел">
                        <Input />
                    </Form.Item>

                    <Form.Item name="userFio" label="ФИО сотрудника">
                        <Input />
                    </Form.Item>

                    <Form.Item name="cpu" label="Процессор (CPU)">
                        <Input />
                    </Form.Item>

                    <Space style={{ display: "flex", justifyContent: "space-between", marginTop: 24 }}>
                        <Button type="primary" htmlType="submit" icon={<SaveOutlined />} loading={saveMutation.isPending}>
                            Сохранить
                        </Button>

                        {!isNew && (
                            <Popconfirm title="Точно удалить?" onConfirm={() => deleteMutation.mutate()} okText="Да" cancelText="Нет">
                                <Button danger icon={<DeleteOutlined />} loading={deleteMutation.isPending}>Удалить</Button>
                            </Popconfirm>
                        )}
                    </Space>
                </Form>
            </Card>
        </div>
    );
}