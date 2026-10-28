"use client";

import React from "react";
import Link from "next/link";
import { useParams } from "next/navigation";
import { useQuery } from "@tanstack/react-query";
import { Button, Result, Spin } from "antd";
import { ArrowLeftOutlined } from "@ant-design/icons";
import { useLocale } from "@/context/LocaleContext";
import { fetchPostById, fetchPublicPosts, newsKeys } from "@/services/newsService";
import {
  formatNewsDate,
  getExcerpt,
  initialOf,
  readingMinutes,
  toneStyle,
} from "@/utils/news";
import MarkdownLite from "@/components/news/MarkdownLite";
import PriorityBadge from "@/components/news/PriorityBadge";
import styles from "@/components/styles/News.module.css";

export default function PostPage() {
  const { id } = useParams<{ id: string }>();
  const { t } = useLocale();

  const { data: post, isLoading, error } = useQuery({
    queryKey: newsKeys.one(id),
    queryFn: () => fetchPostById(id),
    enabled: !!id,
    retry: false,
  });

  const { data: allPosts = [] } = useQuery({
    queryKey: newsKeys.public,
    queryFn: fetchPublicPosts,
    enabled: !!post,
  });

  if (isLoading) {
    return (
      <div className={styles.centerBox}>
        <Spin size="large" />
      </div>
    );
  }

  if (error || !post) {
    return (
      <div className={styles.article}>
        <Result
          status="404"
          title={t("newsPostNotFound")}
          extra={
            <Link href="/news">
              <Button type="primary">{t("newsBack")}</Button>
            </Link>
          }
        />
      </div>
    );
  }

  const related = allPosts
    .filter((p) => p.id !== post.id && p.categoryId === post.categoryId)
    .slice(0, 3);
  const wasUpdated =
    post.updatedAt && new Date(post.updatedAt).getTime() - new Date(post.createdAt).getTime() > 60_000;

  return (
    <div className={styles.article} style={toneStyle(post.priority)}>
      <Link href="/news" className={styles.backLink}>
        <ArrowLeftOutlined /> {t("newsBack")}
      </Link>

      <header className={styles.articleHead}>
        <div className={styles.newsCardTop}>
          {post.category?.name && <span className={styles.catTag}>{post.category.name}</span>}
          <PriorityBadge priority={post.priority} hideNormal />
          {!post.isPublished && <span className={styles.draftTag}>{t("newsDraftBadge")}</span>}
        </div>

        <h1 className={styles.articleTitle}>{post.title}</h1>
        {post.summary?.trim() && <p className={styles.articleLead}>{post.summary}</p>}

        <div className={styles.authorRow}>
          <span className={styles.avatar}>{initialOf(post.creatorName)}</span>
          <div>
            <div className={styles.authorName}>
              {post.creatorName}
              {post.creatorDepartment ? ` · ${post.creatorDepartment}` : ""}
            </div>
            <div className={styles.metaRow}>
              <span>{formatNewsDate(post.createdAt)}</span>
              <span className={styles.metaDot}>
                {readingMinutes(post.content)} {t("newsMinRead")}
              </span>
              {wasUpdated && (
                <span className={styles.metaDot}>
                  {t("newsUpdatedLabel")} {formatNewsDate(post.updatedAt, false)}
                </span>
              )}
            </div>
          </div>
        </div>
      </header>

      <MarkdownLite source={post.content} />

      {related.length > 0 && (
        <section className={styles.related}>
          <h3 className={styles.relatedTitle}>{t("newsRelated")}</h3>
          <div className={styles.relatedGrid}>
            {related.map((p) => (
              <Link
                key={p.id}
                href={`/news/${p.id}`}
                className={styles.newsCard}
                style={toneStyle(p.priority)}
              >
                <h4 className={styles.newsCardTitle}>{p.title}</h4>
                <p className={styles.newsCardExcerpt} style={{ WebkitLineClamp: 2 }}>
                  {getExcerpt(p, 110)}
                </p>
                <div className={styles.metaRow}>{formatNewsDate(p.createdAt, false)}</div>
              </Link>
            ))}
          </div>
        </section>
      )}
    </div>
  );
}
