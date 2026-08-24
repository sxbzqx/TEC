"use client";

import React, { useState } from "react";
import { useQuery } from "@tanstack/react-query";
import {
  Table,
  Select,
  Typography,
  Card,
  Alert,
  Space,
  DatePicker,
  Tag,
} from "antd";
import type { Dayjs } from "dayjs";
import { $api } from "@/app/api/api";

const { Title } = Typography;
const { RangePicker } = DatePicker;

interface ActivityLogItem {
  id: number;
  action: string;
  title: string;
  subtitle: string | null;
  actorUserId: number | null;
  actorLogin: string | null;
  createdAt: string;
}

interface ActivityLogResponse {
  total: number;
  page: number;
  pageSize: number;
  items: ActivityLogItem[];
}

const ACTION_COLORS: Record<string, string> = {
  post_created: "green",
  post_updated: "blue",
  post_deleted: "red",
  role_changed: "purple",
};

const fetchActions = async () => {
  const response = await $api.get<string[]>("/activity/actions");
  return response.data;
};

const fetchLog = async (params: {
  page: number;
  pageSize: number;
  action?: string;
  from?: string;
  to?: string;
}) => {
  const response = await $api.get<ActivityLogResponse>("/activity/log", {
    params,
  });
  return response.data;
};

export default function ActivityLogPage() {
  const [page, setPage] = useState(1);
  const [pageSize, setPageSize] = useState(25);
  const [action, setAction] = useState<string | undefined>(undefined);
  const [range, setRange] = useState<[Dayjs | null, Dayjs | null] | null>(
    null,
  );

  const { data: actions = [] } = useQuery<string[], Error>({
    queryKey: ["activity-log-actions"],
    queryFn: fetchActions,
  });

  const {
    data,
    isLoading,
    error,
  } = useQuery<ActivityLogResponse, Error>({
    queryKey: ["activity-log", page, pageSize, action, range],
    queryFn: () =>
      fetchLog({
        page,
        pageSize,
        action,
        from: range?.[0]?.toISOString(),
        to: range?.[1]?.toISOString(),
      }),
  });

  return (
    <Card>
      <Title level={3}>Журнал действий</Title>

      <Space style={{ marginBottom: 16 }} wrap>
        <Select
          allowClear
          placeholder="Тип события"
          style={{ width: 220 }}
          value={action}
          onChange={(value) => {
            setAction(value);
            setPage(1);
          }}
          options={actions.map((a) => ({ label: a, value: a }))}
        />
        <RangePicker
          showTime
          value={range as any}
          onChange={(value) => {
            setRange(value as [Dayjs | null, Dayjs | null] | null);
            setPage(1);
          }}
        />
      </Space>

      {error && (
        <Alert
          type="error"
          message="Не удалось загрузить журнал"
          style={{ marginBottom: 16 }}
        />
      )}

      <Table<ActivityLogItem>
        rowKey="id"
        loading={isLoading}
        dataSource={data?.items ?? []}
        pagination={{
          current: page,
          pageSize,
          total: data?.total ?? 0,
          showSizeChanger: true,
          onChange: (nextPage, nextPageSize) => {
            setPage(nextPage);
            setPageSize(nextPageSize);
          },
        }}
        columns={[
          {
            title: "Дата",
            dataIndex: "createdAt",
            width: 180,
            render: (value: string) => new Date(value).toLocaleString("ru-RU"),
          },
          {
            title: "Событие",
            dataIndex: "action",
            width: 160,
            render: (value: string) => (
              <Tag color={ACTION_COLORS[value] ?? "default"}>{value}</Tag>
            ),
          },
          {
            title: "Описание",
            dataIndex: "title",
          },
          {
            title: "Детали",
            dataIndex: "subtitle",
          },
          {
            title: "Кто",
            dataIndex: "actorLogin",
            width: 160,
            render: (value: string | null) => value ?? "—",
          },
        ]}
      />
    </Card>
  );
}