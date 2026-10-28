"use client";

import Link from "next/link";
import { Button, Skeleton } from "antd";
import { ArrowRightOutlined, FireOutlined, PlusOutlined } from "@ant-design/icons";
import { useQuery } from "@tanstack/react-query";
import { fetchFeaturedPosts, newsKeys } from "@/services/newsService";
import { useLocale } from "@/context/LocaleContext";
import { useAuth } from "@/hooks/useAuth";
import PriorityBadge from "@/components/news/PriorityBadge";
import { formatNewsDate, getExcerpt, initialOf, readingMinutes, toneStyle } from "@/utils/news";
import dash from "@/components/styles/Dashboard.module.css";
import styles from "@/components/styles/News.module.css";

const TAKE = 5;

export default function FeaturedNews() {
  const { t } = useLocale();
  const { auth } = useAuth();
  const isAdmin = auth.role === "Admin" || auth.role === "SuperAdmin";

  const { data: posts = [], isLoading } = useQuery({
    queryKey: newsKeys.featured(TAKE),
    queryFn: () => fetchFeaturedPosts(TAKE),
    staleTime: 60_000,
  });

  const [lead, ...rest] = posts;

  return (
    <div className={dash.sectionCard} style={{ marginBottom: 16 }}>
      <div className={dash.sectionHeader}>
        <div className={dash.sectionTitleGroup}>
          <FireOutlined className={dash.sectionIcon} />
          <h2 className={dash.sectionTitle}>{t("dashNewsTitle")}</h2>
          {posts.length > 0 && <span className={dash.countBadge}>{posts.length}</span>}
        </div>
        <Link href="/news">
          <Button type="link" size="small" style={{ color: "var(--brand)", fontWeight: 500 }}>
            {t("dashNewsAll")} <ArrowRightOutlined />
          </Button>
        </Link>
      </div>

      {isLoading && (
        <div className={styles.featSkeleton}>
          <Skeleton active paragraph={{ rows: 3 }} />
        </div>
      )}

      {!isLoading && !lead && (
        <div className={styles.featEmpty}>
          <span>{t("dashNewsEmpty")}</span>
          {isAdmin && (
            <Link href="/admin/news">
              <Button size="small" icon={<PlusOutlined />}>
                {t("dashNewsAdd")}
              </Button>
            </Link>
          )}
        </div>
      )}

      {lead && (
        <div className={`${styles.featGrid} ${rest.length === 0 ? styles.featGridSingle : ""}`}>
          <Link href={`/news/${lead.id}`} className={styles.featLead} style={toneStyle(lead.priority)}>
            <div className={styles.featLeadTop}>
              {lead.category?.name && <span className={styles.catTag}>{lead.category.name}</span>}
              <PriorityBadge priority={lead.priority} hideNormal />
            </div>
            <h3 className={styles.featTitle}>{lead.title}</h3>
            <p className={styles.featExcerpt}>{getExcerpt(lead, 220)}</p>
            <div className={styles.featLeadFoot}>
              <div className={styles.metaRow}>
                <span className={styles.avatar}>{initialOf(lead.creatorName)}</span>
                <span>{lead.creatorName}</span>
                <span className={styles.metaDot}>{formatNewsDate(lead.createdAt, false)}</span>
                <span className={styles.metaDot}>
                  {readingMinutes(lead.content)} {t("newsMinRead")}
                </span>
              </div>
              <span className={styles.arrowBtn}>
                <ArrowRightOutlined />
              </span>
            </div>
          </Link>

          {rest.length > 0 && (
            <div className={styles.featList}>
              {rest.map((post) => (
                <Link
                  key={post.id}
                  href={`/news/${post.id}`}
                  className={styles.featItem}
                  style={toneStyle(post.priority)}
                >
                  <div className={styles.featItemBody}>
                    <h4 className={styles.featItemTitle}>{post.title}</h4>
                    <div className={styles.metaRow}>
                      {post.category?.name && <span>{post.category.name}</span>}
                      <span className={post.category?.name ? styles.metaDot : undefined}>
                        {formatNewsDate(post.createdAt, false)}
                      </span>
                      <PriorityBadge priority={post.priority} hideNormal />
                    </div>
                  </div>
                  <span className={styles.arrowBtn} style={{ width: 28, height: 28, fontSize: 12 }}>
                    <ArrowRightOutlined />
                  </span>
                </Link>
              ))}
            </div>
          )}
        </div>
      )}
    </div>
  );
}
