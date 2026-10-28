"use client";

import React, { useMemo, useState } from "react";
import Link from "next/link";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { App, Button, Input, Popconfirm, Segmented, Select, Space, Switch, Table, Tooltip } from "antd";
import type { ColumnsType } from "antd/es/table";
import {
  DeleteOutlined,
  EditOutlined,
  EditFilled,
  FireOutlined,
  LinkOutlined,
  PlusOutlined,
  ReadOutlined,
} from "@ant-design/icons";
import { useLocale } from "@/context/LocaleContext";
import {
  deletePost,
  fetchAdminPosts,
  fetchCategories,
  newsKeys,
  updatePostFlags,
} from "@/services/newsService";
import type { Post, PostFlagsPayload, PostPriority } from "@/types/post";
import {
  PRIORITIES,
  PRIORITY_META,
  formatNewsDateShort,
  getExcerpt,
  normalizePriority,
} from "@/utils/news";
import PostEditorDrawer from "@/components/news/PostEditorDrawer";
import styles from "@/components/styles/News.module.css";

type Filter = "all" | "published" | "drafts" | "main";

export default function AdminNewsPage() {
  const { t } = useLocale();
  const { message } = App.useApp();
  const queryClient = useQueryClient();

  const [editorOpen, setEditorOpen] = useState(false);
  const [editingPost, setEditingPost] = useState<Post | null>(null);
  const [search, setSearch] = useState("");
  const [categoryId, setCategoryId] = useState<number | undefined>();
  const [filter, setFilter] = useState<Filter>("all");

  const { data: posts = [], isLoading } = useQuery({
    queryKey: newsKeys.admin,
    queryFn: fetchAdminPosts,
  });
  const { data: categories = [] } = useQuery({
    queryKey: newsKeys.categories,
    queryFn: fetchCategories,
  });

  const invalidateAll = () => {
    queryClient.invalidateQueries({ queryKey: newsKeys.admin });
    queryClient.invalidateQueries({ queryKey: newsKeys.public });
    queryClient.invalidateQueries({ queryKey: newsKeys.featuredAll });
  };

  const flagsMutation = useMutation({
    mutationFn: ({ id, payload }: { id: number; payload: PostFlagsPayload }) =>
      updatePostFlags(id, payload),
    onSuccess: () => {
      message.success(t("adminNewsFlagsUpdated"));
      invalidateAll();
    },
  });

  const deleteMutation = useMutation({
    mutationFn: (id: number) => deletePost(id),
    onSuccess: () => {
      message.success(t("adminNewsDeleted"));
      invalidateAll();
    },
  });

  const stats = useMemo(
    () => ({
      total: posts.length,
      main: posts.filter((p) => p.isPublished && p.showOnMain).length,
      drafts: posts.filter((p) => !p.isPublished).length,
    }),
    [posts],
  );

  const filtered = useMemo(() => {
    const q = search.trim().toLowerCase();
    return posts.filter((p) => {
      if (q && !p.title?.toLowerCase().includes(q)) return false;
      if (categoryId && p.categoryId !== categoryId) return false;
      if (filter === "published") return p.isPublished;
      if (filter === "drafts") return !p.isPublished;
      if (filter === "main") return p.isPublished && p.showOnMain;
      return true;
    });
  }, [posts, search, categoryId, filter]);

  const openEditor = (post: Post | null) => {
    setEditingPost(post);
    setEditorOpen(true);
  };

  const columns: ColumnsType<Post> = [
    {
      title: t("colTitle"),
      key: "title",
      render: (_, p) => (
        <div className={styles.titleCell} onClick={() => openEditor(p)}>
          <div className={styles.titleMain}>
            <span>{p.title}</span>
            {!p.isPublished && <span className={styles.draftTag}>{t("newsDraftBadge")}</span>}
          </div>
          <div className={styles.titleSub}>{getExcerpt(p, 90)}</div>
        </div>
      ),
    },
    {
      title: t("colCategoryFull"),
      key: "category",
      width: 150,
      render: (_, p) =>
        p.category?.name ? (
          <span className={styles.catTag}>{p.category.name}</span>
        ) : (
          <span style={{ color: "var(--ink-faint)" }}>{t("noCategory")}</span>
        ),
    },
    {
      title: t("colPriority"),
      key: "priority",
      width: 150,
      render: (_, p) => (
        <Select<PostPriority>
          size="small"
          variant="borderless"
          className={styles.prioSelect}
          value={normalizePriority(p.priority)}
          onChange={(value) => flagsMutation.mutate({ id: p.id, payload: { priority: value } })}
          options={PRIORITIES.map((value) => ({
            value,
            label: (
              <span style={{ display: "inline-flex", alignItems: "center", gap: 8 }}>
                <span
                  className={styles.priorityDot}
                  style={{ background: PRIORITY_META[value].color, width: 8, height: 8 }}
                />
                {t(PRIORITY_META[value].labelKey)}
              </span>
            ),
          }))}
        />
      ),
    },
    {
      title: t("colOnMain"),
      key: "onMain",
      width: 110,
      align: "center",
      render: (_, p) => (
        <Tooltip title={!p.isPublished ? t("edShowOnMainDraftHint") : undefined}>
          <Switch
            size="small"
            checked={p.showOnMain}
            onChange={(checked) => flagsMutation.mutate({ id: p.id, payload: { showOnMain: checked } })}
          />
        </Tooltip>
      ),
    },
    {
      title: t("colPublished"),
      key: "published",
      width: 120,
      align: "center",
      render: (_, p) => (
        <Switch
          size="small"
          checked={p.isPublished}
          onChange={(checked) => flagsMutation.mutate({ id: p.id, payload: { isPublished: checked } })}
        />
      ),
    },
    {
      title: t("fieldAuthorName"),
      key: "creator",
      responsive: ["lg"],
      render: (_, p) => (
        <div style={{ fontSize: 13 }}>
          <div style={{ color: "var(--ink)" }}>{p.creatorName}</div>
          {p.creatorDepartment && (
            <div style={{ color: "var(--ink-faint)", fontSize: 12 }}>{p.creatorDepartment}</div>
          )}
        </div>
      ),
    },
    {
      title: t("colDate"),
      key: "date",
      width: 110,
      responsive: ["md"],
      render: (_, p) => (
        <span style={{ fontSize: 13, color: "var(--ink-soft)" }}>{formatNewsDateShort(p.createdAt)}</span>
      ),
    },
    {
      title: t("colActions"),
      key: "actions",
      width: 140,
      render: (_, p) => (
        <Space size={4}>
          <Tooltip title={t("edEditTitle")}>
            <Button type="text" icon={<EditOutlined />} onClick={() => openEditor(p)} />
          </Tooltip>
          {p.isPublished && (
            <Tooltip title={t("adminNewsOpenPublic")}>
              <Link href={`/news/${p.id}`} target="_blank">
                <Button type="text" icon={<LinkOutlined />} />
              </Link>
            </Tooltip>
          )}
          <Popconfirm
            title={t("confirmDeleteTitle")}
            okButtonProps={{ danger: true }}
            onConfirm={() => deleteMutation.mutate(p.id)}
          >
            <Button type="text" danger icon={<DeleteOutlined />} />
          </Popconfirm>
        </Space>
      ),
    },
  ];

  const statChips: { key: Filter; label: string; value: number; icon: React.ReactNode; bg: string; color: string }[] = [
    { key: "all", label: t("adminNewsStatTotal"), value: stats.total, icon: <ReadOutlined />, bg: "var(--brand-soft)", color: "var(--brand-dark)" },
    { key: "main", label: t("adminNewsStatMain"), value: stats.main, icon: <FireOutlined />, bg: "var(--warning-soft)", color: "var(--warning-dark)" },
    { key: "drafts", label: t("adminNewsStatDrafts"), value: stats.drafts, icon: <EditFilled />, bg: "var(--info-soft)", color: "var(--info-dark)" },
  ];

  return (
    <div className={styles.adminPage}>
      <div className={styles.adminHead}>
        <div>
          <h1 className={styles.adminTitle}>{t("adminNewsTitle")}</h1>
          <p className={styles.adminSub}>{t("adminNewsSubtitle")}</p>
        </div>
        <Button type="primary" size="large" icon={<PlusOutlined />} onClick={() => openEditor(null)}>
          {t("adminNewsAdd")}
        </Button>
      </div>

      <div className={styles.statGrid}>
        {statChips.map((c) => (
          <button
            key={c.key}
            type="button"
            className={`${styles.statChip} ${filter === c.key ? styles.statChipActive : ""}`}
            onClick={() => setFilter(c.key)}
          >
            <span className={styles.statChipIcon} style={{ background: c.bg, color: c.color }}>
              {c.icon}
            </span>
            <span>
              <div className={styles.statChipValue}>{c.value}</div>
              <div className={styles.statChipLabel}>{c.label}</div>
            </span>
          </button>
        ))}
      </div>

      <div className={styles.toolbar}>
        <Input.Search
          allowClear
          className={styles.toolbarGrow}
          placeholder={t("adminNewsSearch")}
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />
        <Select
          allowClear
          style={{ minWidth: 190 }}
          placeholder={t("fieldCategoryPlaceholder")}
          value={categoryId}
          onChange={setCategoryId}
          options={categories.map((c) => ({ value: c.id, label: c.name }))}
        />
        <Segmented<Filter>
          value={filter}
          onChange={setFilter}
          options={[
            { value: "all", label: t("adminNewsFilterAll") },
            { value: "published", label: t("adminNewsFilterPublished") },
            { value: "main", label: t("adminNewsFilterMain") },
            { value: "drafts", label: t("adminNewsFilterDrafts") },
          ]}
        />
      </div>

      <div className={styles.tableCard}>
        <Table<Post>
          rowKey="id"
          loading={isLoading}
          dataSource={filtered}
          columns={columns}
          pagination={{ pageSize: 10, hideOnSinglePage: true, showSizeChanger: false }}
          scroll={{ x: 860 }}
        />
      </div>

      <PostEditorDrawer
        open={editorOpen}
        post={editingPost}
        categories={categories}
        onClose={() => setEditorOpen(false)}
      />
    </div>
  );
}
