"use client";

import { FileTextOutlined, LockOutlined, ReadOutlined, TeamOutlined } from "@ant-design/icons";
import { useLocale } from "@/context/LocaleContext";

export function useFeatures() {
  const { t } = useLocale();

  return [
    {
      icon: <ReadOutlined />,
      iconBg: "var(--brand-soft)",
      iconColor: "var(--brand-dark)",
      title: t("featNewsTitle"),
      desc: t("featNewsDesc"),
    },
    {
      icon: <TeamOutlined />,
      iconBg: "var(--success-soft)",
      iconColor: "var(--success-dark)",
      title: t("featWorkersTitle"),
      desc: t("featWorkersDesc"),
    },
    {
      icon: <FileTextOutlined />,
      iconBg: "var(--warning-soft)",
      iconColor: "var(--warning-dark)",
      title: t("featDocsTitle"),
      desc: t("featDocsDesc"),
    },
    {
      icon: <LockOutlined />,
      iconBg: "var(--info-soft)",
      iconColor: "var(--info-dark)",
      title: t("featProfileTitle"),
      desc: t("featProfileDesc"),
    },
  ];
}
