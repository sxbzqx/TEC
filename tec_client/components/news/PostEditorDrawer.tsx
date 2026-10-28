"use client";

import React, { useCallback, useEffect, useState } from "react";
import { App, Button, Drawer, Form, Input, Select, Switch, Tabs } from "antd";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useLocale } from "@/context/LocaleContext";
import { createPost, newsKeys, updatePost } from "@/services/newsService";
import type { Post, PostCategory, PostPayload, PostPriority } from "@/types/post";
import {
  PRIORITIES,
  PRIORITY_META,
  formatNewsDate,
  getExcerpt,
  normalizePriority,
  readingMinutes,
  toneStyle,
} from "@/utils/news";
import MarkdownEditor from "@/components/news/MarkdownEditor";
import MarkdownLite from "@/components/news/MarkdownLite";
import PriorityBadge from "@/components/news/PriorityBadge";
import styles from "@/components/styles/News.module.css";

interface FormValues {
  title: string;
  categoryId?: number;
  summary?: string;
  content: string;
  isPublished: boolean;
  showOnMain: boolean;
  priority: PostPriority;
}

const EMPTY: FormValues = {
  title: "",
  categoryId: undefined,
  summary: "",
  content: "",
  isPublished: true,
  showOnMain: false,
  priority: 0,
};

interface Props {
  open: boolean;
  post: Post | null;
  categories: PostCategory[];
  onClose: () => void;
}

export default function PostEditorDrawer({ open, post, categories, onClose }: Props) {
  const { t } = useLocale();
  const { message, modal } = App.useApp();
  const queryClient = useQueryClient();
  const [form] = Form.useForm<FormValues>();
  const [dirty, setDirty] = useState(false);
  const [tab, setTab] = useState<"edit" | "preview">("edit");

  // Живое состояние формы — для предпросмотра и подсказок.
  const values = Form.useWatch([], form) as FormValues | undefined;
  const v = values ?? EMPTY;
  const priority = normalizePriority(v.priority);
  const categoryName = categories.find((c) => c.id === v.categoryId)?.name;

  useEffect(() => {
    if (!open) return;
    form.resetFields();
    form.setFieldsValue(
      post
        ? {
            title: post.title,
            categoryId: post.categoryId ?? post.category?.id,
            summary: post.summary ?? "",
            content: post.content,
            isPublished: post.isPublished,
            showOnMain: post.showOnMain,
            priority: normalizePriority(post.priority),
          }
        : EMPTY,
    );
  }, [open, post, form]);

  // Закрытие + сброс локального состояния (в обработчиках, не в эффекте).
  const finish = useCallback(() => {
    setDirty(false);
    setTab("edit");
    onClose();
  }, [onClose]);

  const mutation = useMutation({
    mutationFn: (payload: PostPayload) => (post ? updatePost(post.id, payload) : createPost(payload)),
    onSuccess: () => {
      message.success(post ? t("adminNewsUpdated") : t("adminNewsCreated"));
      queryClient.invalidateQueries({ queryKey: newsKeys.admin });
      queryClient.invalidateQueries({ queryKey: newsKeys.public });
      queryClient.invalidateQueries({ queryKey: newsKeys.featuredAll });
      if (post) queryClient.invalidateQueries({ queryKey: newsKeys.one(post.id) });
      finish();
    },
  });

  const submit = useCallback(async () => {
    try {
      const raw = await form.validateFields();
      mutation.mutate({
        title: raw.title.trim(),
        content: raw.content,
        summary: raw.summary?.trim() ? raw.summary.trim() : null,
        categoryId: raw.categoryId as number,
        isPublished: raw.isPublished,
        showOnMain: raw.showOnMain,
        priority: normalizePriority(raw.priority),
      });
    } catch {
      setTab("edit"); // ошибки валидации видны на вкладке редактора
    }
  }, [form, mutation]);

  const requestClose = useCallback(() => {
    if (!dirty) return finish();
    modal.confirm({
      title: t("edUnsavedTitle"),
      content: t("edUnsavedText"),
      okText: t("edDiscard"),
      cancelText: t("edKeepEditing"),
      okButtonProps: { danger: true },
      onOk: finish,
    });
  }, [dirty, modal, finish, t]);

  // Ctrl/Cmd+S
  useEffect(() => {
    if (!open) return;
    const handler = (e: KeyboardEvent) => {
      if ((e.ctrlKey || e.metaKey) && e.key.toLowerCase() === "s") {
        e.preventDefault();
        void submit();
      }
    };
    window.addEventListener("keydown", handler);
    return () => window.removeEventListener("keydown", handler);
  }, [open, submit]);

  const saveLabel = !v.isPublished ? t("edSaveDraft") : post ? t("edSave") : t("edSavePublish");
  const excerpt = getExcerpt({ summary: v.summary, content: v.content ?? "" }, 140);

  const preview = (
    <div className={styles.previewPane}>
      {v.title || v.content ? (
        <article>
          <div className={styles.articleHead} style={{ paddingBottom: 18, marginBottom: 20 }}>
            <div className={styles.newsCardTop}>
              {categoryName && <span className={styles.catTag}>{categoryName}</span>}
              <PriorityBadge priority={priority} hideNormal />
            </div>
            <h1 className={styles.articleTitle}>{v.title || "—"}</h1>
            {v.summary?.trim() && <p className={styles.articleLead}>{v.summary}</p>}
            <div className={styles.metaRow}>
              <span>{formatNewsDate(new Date().toISOString())}</span>
              <span className={styles.metaDot}>
                {readingMinutes(v.content)} {t("newsMinRead")}
              </span>
            </div>
          </div>
          <MarkdownLite source={v.content ?? ""} />
        </article>
      ) : (
        <div className={styles.previewEmpty}>{t("edPreviewEmpty")}</div>
      )}
    </div>
  );

  const editorTab = (
    <>
      <Form.Item name="title" rules={[{ required: true, whitespace: true, message: t("edTitleRequired") }]} style={{ marginBottom: 0 }}>
        <input className={styles.titleInput} placeholder={t("edTitlePlaceholder")} maxLength={200} autoFocus />
      </Form.Item>

      <div className={styles.fieldRow}>
        <div>
          <label className={styles.fieldLabel}>{t("fieldCategory")}</label>
          <Form.Item name="categoryId" rules={[{ required: true, message: t("edCategoryRequired") }]} style={{ marginBottom: 0 }}>
            <Select
              placeholder={t("fieldCategoryPlaceholder")}
              options={categories.map((c) => ({ value: c.id, label: c.name }))}
              style={{ width: "100%" }}
            />
          </Form.Item>
        </div>
        <div>
          <label className={styles.fieldLabel}>{t("edSummary")}</label>
          <Form.Item name="summary" style={{ marginBottom: 0 }}>
            <Input.TextArea
              autoSize={{ minRows: 1, maxRows: 3 }}
              maxLength={500}
              showCount
              placeholder={t("edSummaryPlaceholder")}
            />
          </Form.Item>
        </div>
      </div>

      <div style={{ marginTop: 18 }}>
        <label className={styles.fieldLabel}>{t("fieldContent")}</label>
        <Form.Item name="content" rules={[{ required: true, whitespace: true, message: t("edContentRequired") }]} style={{ marginBottom: 0 }}>
          <MarkdownEditor placeholder={t("edContentPlaceholder")} />
        </Form.Item>
      </div>
    </>
  );

  return (
    <Drawer
      open={open}
      onClose={requestClose}
      size={1120}
      forceRender
      maskClosable={false}
      rootClassName={styles.drawerRoot}
      title={post ? t("edEditTitle") : t("edNewTitle")}
      footer={
        <div className={styles.drawerFooter}>
          <span className={styles.shortcut}>{t("edShortcut")}</span>
          <div style={{ display: "flex", gap: 8 }}>
            <Button onClick={requestClose}>{t("edCancel")}</Button>
            <Button type="primary" loading={mutation.isPending} onClick={() => void submit()}>
              {saveLabel}
            </Button>
          </div>
        </div>
      }
    >
      <Form
        form={form}
        layout="vertical"
        initialValues={EMPTY}
        onValuesChange={() => setDirty(true)}
        requiredMark={false}
      >
        <div className={styles.editorLayout}>
          <div className={styles.editorMain}>
            {/* Оба таба смонтированы, чтобы поля формы не терялись при переключении */}
            <Tabs
              activeKey={tab}
              onChange={(k) => setTab(k as "edit" | "preview")}
              items={[
                { key: "edit", label: t("edTabEditor"), children: editorTab, forceRender: true },
                { key: "preview", label: t("edTabPreview"), children: preview },
              ]}
            />
          </div>

          <aside className={styles.editorSide}>
            <div className={styles.sideCard}>
              <h4 className={styles.sideTitle}>{t("edSettingsPublish")}</h4>
              <div className={styles.sideRow}>
                <div>
                  <div className={styles.sideRowTitle}>{t("edPublish")}</div>
                  <div className={styles.sideRowHint}>
                    {v.isPublished ? t("edPublishOnHint") : t("edPublishOffHint")}
                  </div>
                </div>
                <Form.Item name="isPublished" valuePropName="checked" noStyle>
                  <Switch />
                </Form.Item>
              </div>
            </div>

            <div className={styles.sideCard}>
              <h4 className={styles.sideTitle}>{t("edSettingsMain")}</h4>
              <div className={styles.sideRow}>
                <div>
                  <div className={styles.sideRowTitle}>{t("edShowOnMain")}</div>
                  <div className={styles.sideRowHint}>
                    {v.isPublished ? t("edShowOnMainHint") : t("edShowOnMainDraftHint")}
                  </div>
                </div>
                <Form.Item name="showOnMain" valuePropName="checked" noStyle>
                  <Switch />
                </Form.Item>
              </div>

              <div className={styles.sideRow} style={{ display: "block" }}>
                <div className={styles.sideRowTitle}>{t("edPriority")}</div>
                <div className={styles.sideRowHint}>{t("edPriorityHint")}</div>
                <Form.Item name="priority" noStyle>
                  <PriorityPicker disabled={!v.showOnMain} />
                </Form.Item>
              </div>
            </div>

            {v.showOnMain && (
              <div className={styles.sideCard}>
                <h4 className={styles.sideTitle}>{t("edMainPreview")}</h4>
                <div className={styles.miniPreview} style={toneStyle(priority)}>
                  <div className={styles.newsCardTop}>
                    {categoryName && <span className={styles.catTag}>{categoryName}</span>}
                    <PriorityBadge priority={priority} hideNormal />
                  </div>
                  <h5 className={styles.miniPreviewTitle}>{v.title || t("edTitlePlaceholder")}</h5>
                  {excerpt && <p className={styles.miniPreviewText}>{excerpt}</p>}
                </div>
              </div>
            )}
          </aside>
        </div>
      </Form>
    </Drawer>
  );
}

/** Контрол приоритета для Form.Item: value/onChange. */
function PriorityPicker({
  value,
  onChange,
  disabled,
}: {
  value?: PostPriority;
  onChange?: (v: PostPriority) => void;
  disabled?: boolean;
}) {
  const { t } = useLocale();
  const current = normalizePriority(value);

  return (
    <div className={styles.prioGroup}>
      {PRIORITIES.map((p) => (
        <button
          key={p}
          type="button"
          disabled={disabled}
          className={`${styles.prioBtn} ${current === p ? styles.prioBtnActive : ""}`}
          style={toneStyle(p)}
          onClick={() => onChange?.(p)}
        >
          <span className={styles.prioBtnDot} />
          {t(PRIORITY_META[p].labelKey)}
        </button>
      ))}
    </div>
  );
}
