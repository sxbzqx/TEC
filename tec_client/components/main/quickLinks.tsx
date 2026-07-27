"use client";

import { MessageOutlined, ReadOutlined, TeamOutlined, UserOutlined } from "@ant-design/icons";
import { useLocale } from "@/context/LocaleContext";

export function useQuickLinks() {
  const { t } = useLocale();

  return [
    { icon: <ReadOutlined />, iconBg: "var(--brand-soft)", iconColor: "var(--brand-dark)", title: t("qlNewsTitle"), sub: t("qlNewsSub"), href: "/news" },
    { icon: <TeamOutlined />, iconBg: "var(--success-soft)", iconColor: "var(--success-dark)", title: t("qlWorkersTitle"), sub: t("qlWorkersSub"), href: "/workers" },
    { icon: <MessageOutlined />, iconBg: "var(--warning-soft)", iconColor: "var(--warning-dark)", title: t("qlSuggestionsTitle"), sub: t("qlSuggestionsSub"), href: "/suggestions" },
    { icon: <UserOutlined />, iconBg: "var(--info-soft)", iconColor: "var(--info-dark)", title: t("qlProfileTitle"), sub: t("qlProfileSub"), href: "/profile" },
  ];
}
