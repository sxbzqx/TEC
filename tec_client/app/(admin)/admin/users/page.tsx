"use client";

import React, { useMemo, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { Alert, Badge, Card, Input, Space, Table, Tag, Typography } from "antd";
import type { ColumnsType } from "antd/es/table";
import { SearchOutlined } from "@ant-design/icons";
import UserAdminDrawer from "@/components/admin/UserAdminDrawer";
import { adminUserKeys, adminUserService } from "@/services/adminUserService";
import { useRealtime } from "@/context/RealtimeContext";
import { useLocale } from "@/context/LocaleContext";
import { getRoleTagColor } from "@/utils/roles";
import type { AdminUserRow } from "@/types/adminUser";

const { Title, Text } = Typography;

const ROLE_FILTERS = ["SuperAdmin", "Admin", "Worker", "User"].map((r) => ({ text: r, value: r }));

export default function AdminUsersPage() {
  const { t } = useLocale();
  const { status } = useRealtime();
  const [searchQuery, setSearchQuery] = useState("");
  const [selectedId, setSelectedId] = useState<number | null>(null);

  const {
    data: users = [],
    isLoading,
    error,
  } = useQuery<AdminUserRow[], Error>({
    queryKey: adminUserKeys.list,
    queryFn: adminUserService.getAll,
  });

  const filteredUsers = useMemo(() => {
    const q = searchQuery.trim().toLowerCase();
    if (!q) return users;
    return users.filter((u) =>
      [u.username, u.email, u.otdel, u.tabel].some((v) => v?.toLowerCase().includes(q)),
    );
  }, [users, searchQuery]);

  const columns: ColumnsType<AdminUserRow> = [
    {
      title: t("auColUser"),
      key: "user",
      sorter: (a, b) => a.username.localeCompare(b.username),
      render: (_, u) => (
        <Space align="start">
          <Badge status={u.isOnline ? "success" : "default"} style={{ marginTop: 6 }} />
          <div>
            <Text strong>{u.username}</Text>
            <Text type="secondary" style={{ display: "block", fontSize: 12 }}>
              {u.email || "—"}
            </Text>
          </div>
        </Space>
      ),
    },
    {
      title: t("auColRole"),
      dataIndex: "role",
      key: "role",
      filters: ROLE_FILTERS,
      onFilter: (value, u) => u.role === value,
      render: (role: string) => (
        <Tag color={getRoleTagColor(role)} style={{ fontWeight: 500 }}>
          {role.toUpperCase()}
        </Tag>
      ),
    },
    {
      title: t("auDepartment"),
      dataIndex: "otdel",
      key: "otdel",
      responsive: ["md"],
      render: (otdel: string | null) => otdel || "—",
    },
    {
      title: t("auStatus"),
      key: "status",
      render: (_, u) =>
        u.isBanned ? <Tag color="red">{t("auStatusBanned")}</Tag> : <Tag color="green">{t("auStatusActive")}</Tag>,
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
      <Space align="baseline" style={{ width: "100%", justifyContent: "space-between" }}>
        <Title level={3} style={{ marginBottom: "6px" }}>
          {t("adminUsersTitle")}
        </Title>
        <Badge
          status={status === "connected" ? "success" : "warning"}
          text={<Text type="secondary">Live</Text>}
        />
      </Space>
      <Text type="secondary" style={{ display: "block", marginBottom: "24px" }}>
        {t("adminUsersSubtitle")}
      </Text>

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
            allowClear
          />
        </div>
      </Card>

      <Card
        variant="borderless"
        style={{ boxShadow: "0 4px 12px rgba(0,0,0,0.05)", borderRadius: "12px" }}
      >
        <Table<AdminUserRow>
          dataSource={filteredUsers}
          columns={columns}
          rowKey="id"
          loading={isLoading}
          pagination={{ pageSize: 10, placement: ["bottomCenter"] }}
          onRow={(u) => ({
            onClick: () => setSelectedId(u.id),
            style: { cursor: "pointer" },
          })}
        />
      </Card>

      <UserAdminDrawer userId={selectedId} onClose={() => setSelectedId(null)} />
    </div>
  );
}
