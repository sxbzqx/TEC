"use client";

import { Spin, Empty } from "antd";
import { useQuery } from "@tanstack/react-query";
import styles from "../styles/Dashboard.module.css";
import { fetchRecentActivity } from "@/services/activityService";
import { ActivityAction } from "@/types/activity";
import { useLocale } from "@/context/LocaleContext";
import type { TranslationKey } from "@/locales/ru";

type Color = "purple" | "green" | "amber" | "blue";

const ACTION_PRESENTATION: Record<string, { icon: string; color: Color }> = {
  post_created: { icon: "📝", color: "green" },
  post_updated: { icon: "✏️", color: "purple" },
  post_deleted: { icon: "🗑️", color: "amber" },
  role_changed: { icon: "👤", color: "blue" },
};

const DEFAULT_PRESENTATION = { icon: "🔔", color: "purple" as Color };

const COLOR_MAP: Record<Color, { bg: string; color: string }> = {
  purple: { bg: "var(--brand-soft)", color: "var(--brand-dark)" },
  green: { bg: "var(--success-soft)", color: "var(--success-dark)" },
  amber: { bg: "var(--warning-soft)", color: "var(--warning-dark)" },
  blue: { bg: "var(--info-soft)", color: "var(--info-dark)" },
};

function presentationFor(action: ActivityAction) {
  return ACTION_PRESENTATION[action] ?? DEFAULT_PRESENTATION;
}

function formatRelativeTime(iso: string, t: (key: TranslationKey) => string): string {
  const date = new Date(iso);
  const now = Date.now();
  const diffMs = now - date.getTime();
  const diffMin = Math.floor(diffMs / 60000);

  if (diffMin < 1) return t("activityJustNow");
  if (diffMin < 60) return `${diffMin} ${t("activityMinutesShort")}`;

  const diffHours = Math.floor(diffMin / 60);
  if (diffHours < 24) return `${diffHours} ${t("activityHoursShort")}`;

  const diffDays = Math.floor(diffHours / 24);
  if (diffDays === 1) return t("activityYesterday");
  if (diffDays < 7) return `${diffDays} ${t("activityDaysShort")}`;

  return date.toLocaleDateString("ru-RU", { day: "numeric", month: "short" });
}

export const ActivityFeed = () => {
  const { t } = useLocale();
  const {
    data: items,
    isLoading,
    isError,
  } = useQuery({
    queryKey: ["recent-activity"],
    queryFn: () => fetchRecentActivity(10),
  });

  return (
    <div className={styles.sectionCard}>
      <div className={styles.sectionHeader}>
        <div className={styles.sectionTitleGroup}>
          <span className={styles.sectionIconActivity}>⚡</span>
          <h2 className={styles.sectionTitle}>{t("sectionActivity")}</h2>
        </div>
      </div>

      {isLoading && (
        <div style={{ textAlign: "center", padding: 24 }}>
          <Spin size="small" />
        </div>
      )}

      {!isLoading && (isError || !items?.length) && (
        <Empty description={t("activityEmpty")} style={{ padding: 24 }} />
      )}

      {!isLoading &&
        !isError &&
        items?.map((item) => {
          const presentation = presentationFor(item.action);
          const c = COLOR_MAP[presentation.color];
          return (
            <div key={item.id} className={styles.activityRow}>
              <div
                className={styles.activityIcon}
                style={{ background: c.bg, color: c.color }}
              >
                {presentation.icon}
              </div>
              <div className={styles.activityBody}>
                <p className={styles.activityTitle}>{item.title}</p>
                {item.subtitle && (
                  <p className={styles.activitySub}>{item.subtitle}</p>
                )}
              </div>
              <span className={styles.activityTime}>
                {formatRelativeTime(item.createdAt, t)}
              </span>
            </div>
          );
        })}
    </div>
  );
};
