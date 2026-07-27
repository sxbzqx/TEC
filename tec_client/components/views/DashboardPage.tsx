"use client";

import { Row, Col } from "antd";
import {
  GiftOutlined,
  CheckCircleOutlined,
  BellOutlined,
  TeamOutlined,
  ThunderboltOutlined,
  CalendarOutlined,
} from "@ant-design/icons";
import { BirthdayTable } from "@/components/main/birthdayTable";
import { Notifications } from "@/components/main/notifications";
import { ActivityFeed } from "@/components/main/activityFeed";
import { BirthdayChart } from "@/components/main/birthdayChart";
import { useBirthday } from "@/hooks/useBirthday";
import styles from "@/components/styles/Dashboard.module.css";
import FAQ_ITEMS from "@/components/main/faq";
import { useLocale } from "@/context/LocaleContext";

export default function HomePage() {
  const { upcomingBirthdays, allWorkers, loading } = useBirthday();
  const { t, locale } = useLocale();

  const today = new Date().toLocaleDateString(locale === "kg" ? "ru-RU" : "ru-RU", {
    weekday: "long",
    day: "numeric",
    month: "long",
  });

  const STATS = [
    {
      icon: <GiftOutlined />,
      value: upcomingBirthdays.length,
      label: t("statBirthdaysLabel"),
      hint: t("statBirthdaysHint"),
      accent: "var(--brand)",
      iconBg: "var(--brand-soft)",
      iconColor: "var(--brand-dark)",
    },
    {
      icon: <CheckCircleOutlined />,
      value: "2",
      label: t("statNewsLabel"),
      hint: t("statNewsHint"),
      accent: "var(--success)",
      iconBg: "var(--success-soft)",
      iconColor: "var(--success-dark)",
    },
    {
      icon: <BellOutlined />,
      value: 2,
      label: t("statNotificationsLabel"),
      hint: t("statNotificationsHint"),
      accent: "var(--warning)",
      iconBg: "var(--warning-soft)",
      iconColor: "var(--warning-dark)",
    },
    {
      icon: <TeamOutlined />,
      value: allWorkers?.length ?? "—",
      label: t("statWorkersLabel"),
      hint: t("statWorkersHint"),
      accent: "var(--info)",
      iconBg: "var(--info-soft)",
      iconColor: "var(--info-dark)",
    },
  ];

  return (
    <div className={styles.container}>

      {/* ── Hero ── */}
      <div className={styles.hero}>
        <div className={styles.heroLeft}>
          <span className={styles.eyebrow}>
            <ThunderboltOutlined />
            МП Бишкек ТЭЦ
          </span>
          <h1 className={styles.heroTitle}>{t("dashTitle")}</h1>
          <p className={styles.heroSub}>{t("dashSubtitle")}</p>
        </div>
        <div className={styles.heroRight}>
          <div className={styles.dateChip}>
            <CalendarOutlined className={styles.dateIcon} />
            <span>{today}</span>
          </div>
        </div>
      </div>

      {/* ── Stats ── */}
      <Row gutter={[16, 16]} className={styles.statsRow}>
        {STATS.map((s, i) => (
          <Col key={i} xs={12} sm={12} md={6}>
            <div
              className={styles.statCard}
              style={{ "--accent": s.accent } as React.CSSProperties}
            >
              <div
                className={styles.statIcon}
                style={{ background: s.iconBg, color: s.iconColor }}
              >
                {s.icon}
              </div>
              <div className={styles.statValue}>{s.value}</div>
              <div className={styles.statLabel}>{s.label}</div>
              <div className={styles.statHint}>{s.hint}</div>
            </div>
          </Col>
        ))}
      </Row>

      {/* ── Main grid: table + notifications ── */}
      <Row gutter={[16, 16]} style={{ marginBottom: 16 }}>
        <Col xs={24} xl={16}>
          <div className={styles.sectionCard}>
            <div className={styles.sectionHeader}>
              <div className={styles.sectionTitleGroup}>
                <GiftOutlined className={styles.sectionIcon} />
                <h2 className={styles.sectionTitle}>{t("sectionUpcomingBirthdays")}</h2>
              </div>
              <span className={styles.countBadge}>{upcomingBirthdays.length}</span>
            </div>
            <BirthdayTable data={upcomingBirthdays} loading={loading} />
          </div>
        </Col>
        <Col xs={24} xl={8}>
          <div className={styles.sectionCard} style={{ height: "100%" }}>
            <Notifications />
          </div>
        </Col>
      </Row>

      {/* ── Bottom grid: activity + chart + faq ── */}
      <Row gutter={[16, 16]}>
        <Col xs={24} md={8}>
          <ActivityFeed />
        </Col>
        <Col xs={24} md={8}>
          <BirthdayChart workers={allWorkers ?? []} />
        </Col>
        <Col xs={24} md={8}>
          <div className={styles.sectionCard}>
            <div className={styles.sectionHeader}>
              <div className={styles.sectionTitleGroup}>
                <h2 className={styles.sectionTitle}>{t("sectionFAQ")}</h2>
              </div>
            </div>
            <div className={styles.faqInner}>
              <FAQ_ITEMS />
            </div>
          </div>
        </Col>
      </Row>

    </div>
  );
}
