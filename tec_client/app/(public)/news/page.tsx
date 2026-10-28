"use client";

import React, { useMemo, useState } from "react";
import Link from "next/link";
import { useQuery } from "@tanstack/react-query";
import { Alert, Empty, Input, Spin } from "antd";
import { ArrowRightOutlined } from "@ant-design/icons";
import { useLocale } from "@/context/LocaleContext";
import { fetchPublicPosts, newsKeys } from "@/services/newsService";
import type { Post } from "@/types/post";
import {
  formatNewsDate,
  getExcerpt,
  initialOf,
  readingMinutes,
  toneStyle,
} from "@/utils/news";
import PriorityBadge from "@/components/news/PriorityBadge";
import styles from "@/components/styles/News.module.css";

function NewsCard({ post, lead = false }: { post: Post; lead?: boolean }) {
  const { t } = useLocale();

  return (
    <Link
      href={`/news/${post.id}`}
      className={`${styles.newsCard} ${lead ? styles.newsCardLead : ""}`}
      style={toneStyle(post.priority)}
    >
      <div className={styles.newsCardTop}>
        {post.category?.name && <span className={styles.catTag}>{post.category.name}</span>}
        <PriorityBadge priority={post.priority} hideNormal />
      </div>
      <h2 className={styles.newsCardTitle}>{post.title}</h2>
      <p className={styles.newsCardExcerpt}>{getExcerpt(post, lead ? 260 : 170)}</p>
      <div className={styles.newsCardFoot}>
        <div className={styles.metaRow}>
          <span className={styles.avatar}>{initialOf(post.creatorName)}</span>
          <span>{formatNewsDate(post.createdAt, false)}</span>
          <span className={styles.metaDot}>
            {readingMinutes(post.content)} {t("newsMinRead")}
          </span>
        </div>
        <span className={styles.arrowBtn} style={{ width: 30, height: 30, fontSize: 12 }}>
          <ArrowRightOutlined />
        </span>
      </div>
    </Link>
  );
}

export default function NewsPage() {
  const { t } = useLocale();
  const [search, setSearch] = useState("");
  const [categoryId, setCategoryId] = useState<number | null>(null);

  const { data: posts = [], isLoading, isError } = useQuery({
    queryKey: newsKeys.public,
    queryFn: fetchPublicPosts,
  });

  const categories = useMemo(() => {
    const map = new Map<number, string>();
    posts.forEach((p) => p.category && map.set(p.category.id, p.category.name));
    return Array.from(map, ([id, name]) => ({ id, name }));
  }, [posts]);

  const list = useMemo(() => {
    const q = search.trim().toLowerCase();
    const filtered = posts.filter((p) => {
      if (categoryId && p.categoryId !== categoryId) return false;
      if (!q) return true;
      return p.title?.toLowerCase().includes(q) || p.content?.toLowerCase().includes(q);
    });
    // Приоритетные новости, закреплённые для главной, идут первыми; дальше — по дате.
    return [...filtered].sort(
      (a, b) =>
        Number(b.showOnMain) * 10 + b.priority - (Number(a.showOnMain) * 10 + a.priority) ||
        new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime(),
    );
  }, [posts, search, categoryId]);

  const isFiltering = !!search.trim() || categoryId !== null;

  return (
    <div className={styles.page}>
      <div className={styles.pageHead}>
        <div>
          <h1 className={styles.pageTitle}>{t("newsTitle")}</h1>
          <p className={styles.pageSub}>{t("newsSubtitle")}</p>
        </div>
        <Input.Search
          allowClear
          className={styles.searchBox}
          placeholder={t("newsSearchPlaceholder")}
          value={search}
          onChange={(e) => setSearch(e.target.value)}
        />
      </div>

      {categories.length > 1 && (
        <div className={styles.filters}>
          <button
            type="button"
            className={`${styles.chip} ${categoryId === null ? styles.chipActive : ""}`}
            onClick={() => setCategoryId(null)}
          >
            {t("newsAllCategories")}
          </button>
          {categories.map((c) => (
            <button
              key={c.id}
              type="button"
              className={`${styles.chip} ${categoryId === c.id ? styles.chipActive : ""}`}
              onClick={() => setCategoryId(c.id)}
            >
              {c.name}
            </button>
          ))}
        </div>
      )}

      {isLoading && (
        <div className={styles.centerBox}>
          <Spin size="large" />
        </div>
      )}

      {isError && <Alert type="error" showIcon message={t("newsLoadError")} />}

      {!isLoading && !isError && list.length === 0 && (
        <Empty description={t("newsEmpty")} style={{ padding: "60px 0" }} />
      )}

      {list.length > 0 && (
        <div className={styles.newsGrid}>
          {list.map((post, i) => (
            <NewsCard key={post.id} post={post} lead={i === 0 && !isFiltering && list.length > 2} />
          ))}
        </div>
      )}
    </div>
  );
}
