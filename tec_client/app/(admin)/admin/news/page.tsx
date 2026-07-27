"use client";

import React, { useState } from "react";
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import {
  Table,
  Button,
  Modal,
  Form,
  Input,
  Select,
  Typography,
  Card,
  Space,
  Popconfirm,
} from "antd";
import { PlusOutlined, EditOutlined, DeleteOutlined } from "@ant-design/icons";
import { $api } from "@/app/api/api";
import { Post } from "@/types/post";
import { useLocale } from "@/context/LocaleContext";

import { App } from "antd";

const { Title } = Typography;
const { TextArea } = Input;

export default function AdminNewsPage() {
  const { t } = useLocale();
  const { message } = App.useApp();
  const queryClient = useQueryClient();
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [editingPost, setEditingPost] = useState<Post | null>(null);
  const [form] = Form.useForm();

  // 1. Запрос постов
  const { data: posts = [], isLoading } = useQuery<Post[]>({
    queryKey: ["admin-posts"],
    queryFn: async () => (await $api.get("/admin/posts")).data,
  });

  // 2. Запрос категорий для выпадающего списка
  const { data: categories = [] } = useQuery({
    queryKey: ["categories"],
    queryFn: async () => (await $api.get("/categories")).data,
  });

  // 3. Мутация для создания/обновления.
  // Автор (creatorName/creatorDepartment) определяется бэком автоматически
  // по текущему аккаунту — тут его не отправляем и не редактируем.
  const mutation = useMutation({
    mutationFn: async (values: any) => {
      if (editingPost) {
        return $api.put(`/admin/posts/${editingPost.id}`, values);
      }
      return $api.post("/admin/posts", values);
    },
    onSuccess: () => {
      message.success(editingPost ? t("adminNewsUpdated") : t("adminNewsCreated"));
      setIsModalOpen(false);
      form.resetFields();
      setEditingPost(null);
      queryClient.invalidateQueries({ queryKey: ["admin-posts"] });
    },
  });

  // 4. Мутация для удаления
  const deleteMutation = useMutation({
    mutationFn: (id: number) => $api.delete(`/admin/posts/${id}`),
    onSuccess: () => {
      message.success(t("adminNewsDeleted"));
      queryClient.invalidateQueries({ queryKey: ["admin-posts"] });
    },
  });

  const columns = [
    { title: t("colTitle"), dataIndex: "title", key: "title" },
    {
      title: t("colCategoryFull"),
      dataIndex: "category",
      key: "category",
      render: (cat: any) => cat?.name || t("noCategory"),
    },
    {
      title: t("fieldAuthorName"),
      key: "creator",
      render: (_: any, record: Post) =>
        record.creatorDepartment ? `${record.creatorName} (${record.creatorDepartment})` : record.creatorName,
    },
    {
      title: t("colActions"),
      key: "actions",
      render: (_: any, record: Post) => (
        <Space>
          <Button
            icon={<EditOutlined />}
            onClick={() => {
              setEditingPost(record);
              form.setFieldsValue({
                title: record.title,
                content: record.content,
                categoryId: record.category?.id,
              });
              setIsModalOpen(true);
            }}
          />
          <Popconfirm
            title={t("confirmDeleteTitle")}
            onConfirm={() => deleteMutation.mutate(record.id)}
          >
            <Button danger icon={<DeleteOutlined />} />
          </Popconfirm>
        </Space>
      ),
    },
  ];

  return (
    <div style={{ padding: "24px" }}>
      <div
        style={{
          display: "flex",
          justifyContent: "space-between",
          marginBottom: 20,
        }}
      >
        <Title level={3}>{t("adminNewsTitle")}</Title>
        <Button
          type="primary"
          icon={<PlusOutlined />}
          onClick={() => {
            setEditingPost(null);
            form.resetFields();
            setIsModalOpen(true);
          }}
        >
          {t("adminNewsAdd")}
        </Button>
      </div>

      <Card>
        <Table
          dataSource={posts}
          columns={columns}
          rowKey="id"
          loading={isLoading}
        />
      </Card>

      <Modal
        title={editingPost ? t("adminNewsEditModalTitle") : t("adminNewsCreateModalTitle")}
        open={isModalOpen}
        onOk={() => form.submit()}
        onCancel={() => setIsModalOpen(false)}
      >
        <Form
          form={form}
          layout="vertical"
          onFinish={(values) => mutation.mutate(values)}
        >
          <Form.Item
            name="categoryId"
            label={t("fieldCategory")}
            rules={[{ required: true }]}
          >
            <Select placeholder={t("fieldCategoryPlaceholder")}>
              {categories.map((cat: any) => (
                <Select.Option key={cat.id} value={cat.id}>
                  {cat.name}
                </Select.Option>
              ))}
            </Select>
          </Form.Item>

          <Form.Item
            name="title"
            label={t("fieldTitle")}
            rules={[{ required: true }]}
          >
            <Input />
          </Form.Item>

          <Form.Item
            name="content"
            label={t("fieldContent")}
            rules={[{ required: true }]}
          >
            <TextArea rows={4} />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
}