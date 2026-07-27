"use client";

import Link from "next/link";
import { Collapse } from "antd";
import styles from "@/components/styles/Main.module.css";
import Paragraph from "antd/es/typography/Paragraph";
import { useLocale } from "@/context/LocaleContext";

export default function FAQ() {
  const { t } = useLocale();

  const FAQ_ITEMS = [
    {
      key: "1",
      label: t("faqQ1"),
      children: (
        <Paragraph className={styles.faqAnswer}>
          {t("faqA1Pre")} <Link href="/login">{t("faqA1Login")}</Link> {t("faqA1Mid")}{" "}
          <Link href="/register">{t("faqA1Register")}</Link>. {t("faqA1Post")}
        </Paragraph>
      ),
    },
    {
      key: "2",
      label: t("faqQ2"),
      children: (
        <Paragraph className={styles.faqAnswer}>
          {t("faqA2Pre")} <Link href="/news">{t("faqA2News")}</Link> {t("faqA2Post")}
        </Paragraph>
      ),
    },
    {
      key: "3",
      label: t("faqQ3"),
      children: (
        <Paragraph className={styles.faqAnswer}>
          {t("faqA3Pre")} <Link href="/suggestions">{t("faqA3Suggestions")}</Link> {t("faqA3Post")}
        </Paragraph>
      ),
    },
    {
      key: "4",
      label: t("faqQ4"),
      children: (
        <Paragraph className={styles.faqAnswer}>
          {t("faqA4Pre")} <Link href="/profile">{t("faqA4Profile")}</Link> {t("faqA4Post")}
        </Paragraph>
      ),
    },
  ];

  return (
    <Collapse
      items={FAQ_ITEMS}
      accordion
      className={styles.faqCollapse}
    />
  );
}
