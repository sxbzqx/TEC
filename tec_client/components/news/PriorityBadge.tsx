"use client";

import { useLocale } from "@/context/LocaleContext";
import { PRIORITY_META, normalizePriority } from "@/utils/news";
import styles from "@/components/styles/News.module.css";

export default function PriorityBadge({
  priority,
  hideNormal = false,
}: {
  priority: number | undefined;
  hideNormal?: boolean;
}) {
  const { t } = useLocale();
  const p = normalizePriority(priority);
  if (hideNormal && p === 0) return null;
  const meta = PRIORITY_META[p];

  return (
    <span className={styles.priorityBadge} style={{ background: meta.soft, color: meta.dark }}>
      <span className={styles.priorityDot} style={{ background: meta.color }} />
      {t(meta.labelKey)}
    </span>
  );
}
