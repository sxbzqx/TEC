"use client";

import React, { useState, useMemo } from "react";
import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import {
  Table,
  Select,
  Typography,
  Card,
  Alert,
  message,
  Tag,
  Space,
  Input,
} from "antd";
import { SearchOutlined, UserOutlined } from "@ant-design/icons";
import { $api } from "@/app/api/api";
import { User } from "@/types/user";
import { AxiosError } from "axios";
import { useLocale } from "@/context/LocaleContext";

const { Title, Text } = Typography;

const fetchUsers = async () => {
  const response = await $api.get<User[]>("/admin/users");
  return response.data;
};

const updateUserRole = async ({
  userId,
  newRole,
}: {
  userId: string;
  newRole: string;
}) => {
  const response = await $api.put(`/admin/users/${userId}/role`, {
    role: newRole,
  });
  return response.data;
};

export default function AdminUsersPage() {
  const { t } = useLocale();
  const queryClient = useQueryClient();
  const [searchQuery, setSearchQuery] = useState<string>("");

  const {
    data: users = [],
    isLoading,
    error,
  } = useQuery<User[], Error>({
    queryKey: ["admin-users"],
    queryFn: fetchUsers,
  });

  const mutation = useMutation({
    mutationFn: updateUserRole,
    onSuccess: () => {
      message.success(t("adminUsersRoleUpdated"));
      queryClient.invalidateQueries({ queryKey: ["admin-users"] });
    },
    onError: (err: AxiosError<{ message?: string }>) => {
      const errorMsg =
        err.response?.data?.message || err.message || t("workersLoadErrorFallback");
      message.error(`${t("adminUsersRoleUpdateError")} ${errorMsg}`);
    },
  });

  const handleRoleChange = (userId: string, newRole: string) => {
    mutation.mutate({ userId, newRole });
  };

  // Оптимизация: мемоизируем отфильтрованный список, чтобы не пересчитывать его при каждом рендере,
  // если users или запрос не изменились.
  const filteredUsers = useMemo(() => {
    const lowerQuery = searchQuery.toLowerCase();
    return users.filter((user) =>
      user.username?.toLowerCase().includes(lowerQuery) ||
      user.email?.toLowerCase().includes(lowerQuery)
    );
  }, [users, searchQuery]);

  const getRoleTagColor = (role: string) => {
    switch (role) {
      case "SuperAdmin":
        return "volcano";
      case "Admin":
        return "gold";
      case "Worker":
        return "blue";
      default:
        return "gray";
    }
  };

  const columns = [
    {
      title: t("colLogin"),
      dataIndex: "username",
      key: "username",
      render: (text: string) => (
        <Space>
          <UserOutlined style={{ color: "var(--brand)" }} />
          <Text strong>{text}</Text>
        </Space>
      ),
    },
    {
      title: t("colEmail"),
      dataIndex: "email",
      key: "email",
      render: (text: string) => text || "—",
    },
    {
      title: t("colCurrentRole"),
      dataIndex: "role",
      key: "role",
      render: (role: string) => (
        <Tag color={getRoleTagColor(role)} style={{ fontWeight: 500 }}>
          {role.toUpperCase()}
        </Tag>
      ),
    },
    {
      title: t("colRoleAction"),
      key: "action",
      render: (_: any, record: User) => (
        <Select
          value={record.role}
          style={{ width: 160 }}
          onChange={(value) => handleRoleChange(record.id, value)}
          disabled={mutation.isPending}
        >
          <Select.Option value="Guest">Guest</Select.Option>
          <Select.Option value="User">User</Select.Option>
          <Select.Option value="Worker">Worker</Select.Option>
          <Select.Option value="Admin">Admin</Select.Option>
        </Select>
      ),
    },
  ];

  if (error) {
    return (
      <div style={{ padding: "24px" }}>
        <Alert
          message={t("adminUsersAccessDeniedTitle")}
          description={t("adminUsersAccessDeniedDesc")}
          type="error"
          showIcon
        />
      </div>
    );
  }

  return (
    <div style={{ padding: "12px" }}>
      <Title level={3} style={{ marginBottom: "6px" }}>
        {t("adminUsersTitle")}
      </Title>
      <Text type="secondary" style={{ display: "block", marginBottom: "24px" }}>
        {t("adminUsersSubtitle")}
      </Text>

      {/* Поиск */}
      <Card size="small" style={{ marginBottom: "20px", borderRadius: "8px" }}>
        <div style={{ maxWidth: 400 }}>
          <Text strong style={{ display: "block", marginBottom: 6 }}>
            {t("adminUsersSearchLabel")}
          </Text>
          <Input
            placeholder={t("adminUsersSearchPlaceholder")}
            prefix={<SearchOutlined style={{ color: "var(--ink-faint)" }} />}
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
          />
        </div>
      </Card>

      {/* Таблица пользователей */}
      <Card
        variant="borderless"
        style={{
          boxShadow: "0 4px 12px rgba(0,0,0,0.05)",
          borderRadius: "12px",
        }}
      >
        <Table
          dataSource={filteredUsers}
          columns={columns}
          rowKey="id"
          loading={isLoading}
          pagination={{ pageSize: 10, placement: ["bottomCenter"] }}
        />
      </Card>
    </div>
  );
}
