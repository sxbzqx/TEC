"use client";

import React, { useMemo, useState } from "react";
import { Alert, App, Badge, Card, Descriptions, Input, Modal, Space, Table, Tag, Typography } from "antd";
import { CommentOutlined, SearchOutlined } from "@ant-design/icons";
import type { ColumnsType } from "antd/es/table";
import { useLocale } from "@/context/LocaleContext";
import { useRealtime } from "@/context/RealtimeContext";
import { useAdminSuggestions, useSetSuggestionComment } from "@/hooks/useSuggestions";
import { getApiErrorMessage } from "@/utils/apiError";
import type { AdminSuggestion } from "@/types/suggestion";

const { Title, Text } = Typography;

export default function AdminSuggestionsPage() {
  const { t } = useLocale();
  const { message } = App.useApp();
  const { status } = useRealtime();
  const [searchQuery, setSearchQuery] = useState("");
  const [selectedId, setSelectedId] = useState<number | null>(null);
  const [draft, setDraft] = useState("");

  const { data: suggestions = [], isLoading, isError } = useAdminSuggestions();
  const setComment = useSetSuggestionComment();

  // Открытая в модалке запись берём из актуального списка, чтобы realtime-обновления не терялись.
  const selected = useMemo(
    () => suggestions.find((s) => s.id === selectedId) ?? null,
    [suggestions, selectedId],
  );

  const filtered = useMemo(() => {
    const q = searchQuery.trim().toLowerCase();
    if (!q) return suggestions;
    return suggestions.filter((s) =>
      [s.userName, s.userLogin, s.userDepartment, s.text, s.comment, s.adminComment].some((v) =>
        v?.toLowerCase().includes(q),
      ),
    );
  }, [suggestions, searchQuery]);

  const openSuggestion = (s: AdminSuggestion) => {
    setSelectedId(s.id);
    setDraft(s.adminComment ?? "");
  };

  const closeModal = () => setSelectedId(null);

  const handleSave = async () => {
    if (!selected) return;
    try {
      await setComment.mutateAsync({ id: selected.id, comment: draft.trim() });
      message.success(draft.trim() ? t("adminSuggestionsCommentSaved") : t("adminSuggestionsCommentRemoved"));
      closeModal();
    } catch (err) {
      message.error(getApiErrorMessage(err, t("adminSuggestionsCommentError")));
    }
  };

  const columns: ColumnsType<AdminSuggestion> = [
    {
      title: t("suggestionsColSent"),
      dataIndex: "createdAt",
      key: "createdAt",
      width: 170,
      render: (date: string) => new Date(date).toLocaleString(),
      sorter: (a, b) => new Date(a.createdAt).getTime() - new Date(b.createdAt).getTime(),
      defaultSortOrder: "descend",
    },
    {
      title: t("suggestionsColUser"),
      key: "user",
      width: 240,
      sorter: (a, b) => a.userName.localeCompare(b.userName),
      render: (_, s) => (
        <div>
          <Text strong>{s.userName}</Text>
          <Text type="secondary" style={{ display: "block", fontSize: 12 }}>
            {[s.userLogin, s.userDepartment].filter(Boolean).join(" · ")}
          </Text>
        </div>
      ),
    },
    {
      title: t("suggestionsColText"),
      dataIndex: "text",
      key: "text",
      render: (v: string) => <span style={{ whiteSpace: "pre-wrap" }}>{v}</span>,
    },
    {
      title: t("colComment"),
      dataIndex: "comment",
      key: "comment",
      responsive: ["lg"],
      render: (v: string | null) =>
        v ? <span style={{ whiteSpace: "pre-wrap" }}>{v}</span> : "—",
    },
    {
      title: t("suggestionsColAdminComment"),
      key: "adminComment",
      width: 150,
      filters: [
        { text: t("adminSuggestionsReplied"), value: "replied" },
        { text: t("suggestionsNoReply"), value: "none" },
      ],
      onFilter: (value, s) => (value === "replied" ? !!s.adminComment : !s.adminComment),
      render: (_, s) =>
        s.adminComment ? (
          <Tag color="green" icon={<CommentOutlined />}>
            {t("adminSuggestionsReplied")}
          </Tag>
        ) : (
          <Tag>{t("suggestionsNoReply")}</Tag>
        ),
    },
  ];

  if (isError) {
    return (
      <div style={{ padding: 24 }}>
        <Alert message={t("adminSuggestionsLoadError")} type="error" showIcon />
      </div>
    );
  }

  return (
    <div style={{ padding: 12 }}>
      <Space align="baseline" style={{ width: "100%", justifyContent: "space-between" }}>
        <Title level={3} style={{ marginBottom: 6 }}>
          {t("adminSuggestionsTitle")}
        </Title>
        <Badge
          status={status === "connected" ? "success" : "warning"}
          text={<Text type="secondary">Live</Text>}
        />
      </Space>
      <Text type="secondary" style={{ display: "block", marginBottom: 24 }}>
        {t("adminSuggestionsSubtitle")}
      </Text>

      <Card size="small" style={{ marginBottom: 20, borderRadius: 8 }}>
        <div style={{ maxWidth: 400 }}>
          <Input
            placeholder={t("adminSuggestionsSearchPlaceholder")}
            prefix={<SearchOutlined style={{ color: "var(--ink-faint)" }} />}
            value={searchQuery}
            onChange={(e) => setSearchQuery(e.target.value)}
            allowClear
          />
        </div>
      </Card>

      <Card
        variant="borderless"
        style={{ boxShadow: "0 4px 12px rgba(0,0,0,0.05)", borderRadius: 12 }}
      >
        <Table<AdminSuggestion>
          dataSource={filtered}
          columns={columns}
          rowKey="id"
          loading={isLoading}
          locale={{ emptyText: t("adminSuggestionsEmpty") }}
          pagination={{ pageSize: 10, placement: ["bottomCenter"] }}
          onRow={(s) => ({
            onClick: () => openSuggestion(s),
            style: { cursor: "pointer" },
          })}
        />
      </Card>

      <Modal
        title={t("adminSuggestionsModalTitle")}
        open={selected !== null}
        onCancel={closeModal}
        onOk={handleSave}
        okText={t("adminSuggestionsSave")}
        cancelText={t("bidDecisionCancel")}
        confirmLoading={setComment.isPending}
        destroyOnHidden
        width={640}
      >
        {selected && (
          <>
            <Descriptions column={1} size="small" bordered style={{ marginBottom: 16 }}>
              <Descriptions.Item label={t("suggestionsColUser")}>
                {selected.userName}
                {selected.userDepartment ? ` (${selected.userDepartment})` : ""}
              </Descriptions.Item>
              <Descriptions.Item label={t("suggestionsColSent")}>
                {new Date(selected.createdAt).toLocaleString()}
              </Descriptions.Item>
              <Descriptions.Item label={t("suggestionsColText")}>
                <span style={{ whiteSpace: "pre-wrap" }}>{selected.text}</span>
              </Descriptions.Item>
              {selected.comment && (
                <Descriptions.Item label={t("colComment")}>
                  <span style={{ whiteSpace: "pre-wrap" }}>{selected.comment}</span>
                </Descriptions.Item>
              )}
            </Descriptions>

            <Text strong style={{ display: "block", marginBottom: 6 }}>
              {t("suggestionsColAdminComment")}
            </Text>
            <Input.TextArea
              rows={4}
              maxLength={500}
              showCount
              value={draft}
              onChange={(e) => setDraft(e.target.value)}
              placeholder={t("adminSuggestionsCommentPlaceholder")}
            />
            {selected.adminCommentAt && (
              <Text type="secondary" style={{ display: "block", marginTop: 8, fontSize: 12 }}>
                {[selected.adminCommentBy, new Date(selected.adminCommentAt).toLocaleString()]
                  .filter(Boolean)
                  .join(" · ")}
              </Text>
            )}
          </>
        )}
      </Modal>
    </div>
  );
}