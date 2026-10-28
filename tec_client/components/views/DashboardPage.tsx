"use client";

import Link from "next/link";
import { Row, Col } from "antd";
import { useQuery } from "@tanstack/react-query";
import {
  GiftOutlined,
  ReadOutlined,
  FireOutlined,
  TeamOutlined,
  ThunderboltOutlined,
  CalendarOutlined,
  ArrowRightOutlined,
} from "@ant-design/icons";
import { BirthdayTable } from "@/components/main/birthdayTable";
import { ActivityFeed } from "@/components/main/activityFeed";
import { BirthdayChart } from "@/components/main/birthdayChart";
import FeaturedNews from "@/components/main/featuredNews";
import { useQuickLinks } from "@/components/main/quickLinks";
import FAQ_ITEMS from "@/components/main/faq";
import { useBirthday } from "@/hooks/useBirthday";
import { useAuth } from "@/hooks/useAuth";
import { useLocale } from "@/context/LocaleContext";
import { fetchFeaturedPosts, fetchPublicPosts, newsKeys } from "@/services/newsService";
import { isWithinDays } from "@/utils/news";
import styles from "@/components/styles/Dashboard.module.css";

function greetingKey(hour: number) {
  if (hour >= 5 && hour < 12) return "dashGreetMorning" as const;
  if (hour >= 12 && hour < 18) return "dashGreetDay" as const;
  if (hour >= 18 && hour < 23) return "dashGreetEvening" as const;
  return "dashGreetNight" as const;
}

export default function HomePage() {
  const { upcomingBirthdays, allWorkers, loading } = useBirthday();
  const { t } = useLocale();
  const { auth } = useAuth();
  const quickLinks = useQuickLinks();

  // Те же ключи, что и в FeaturedNews / странице новостей — запросы дедуплицируются.
  const { data: publicPosts = [] } = useQuery({
    queryKey: newsKeys.public,
    queryFn: fetchPublicPosts,
    staleTime: 60_000,
  });
  const { data: featured = [] } = useQuery({
    queryKey: newsKeys.featured(5),
    queryFn: () => fetchFeaturedPosts(5),
    staleTime: 60_000,
  });

  const newsThisWeek = publicPosts.filter((p) => isWithinDays(p.createdAt, 7)).length;
  const importantOnMain = featured.filter((p) => p.priority >= 1).length;

  const now = new Date();
  const today = now.toLocaleDateString("ru-RU", {
    weekday: "long",
    day: "numeric",
    month: "long",
  });
  const greeting = t(greetingKey(now.getHours()));
  const name = auth.loginName;

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
      icon: <ReadOutlined />,
      value: newsThisWeek,
      label: t("statNewsLabel"),
      hint: t("statNewsHint"),
      accent: "var(--success)",
      iconBg: "var(--success-soft)",
      iconColor: "var(--success-dark)",
    },
    {
      icon: <FireOutlined />,
      value: importantOnMain,
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
      <section className={styles.heroBanner}>
        <div className={styles.heroBannerMain}>
          <span className={styles.heroEyebrow}>
            <ThunderboltOutlined />
            МП Бишкек ТЭЦ · {t("dashTitle")}
          </span>
          <h1 className={styles.heroBannerTitle}>
            {greeting}
            {name ? `, ${name}` : ""}
          </h1>
          <p className={styles.heroBannerSub}>{t("dashSubtitle")}</p>

          <div className={styles.heroLinks}>
            {quickLinks.map((link) => (
              <Link key={link.href} href={link.href} className={styles.heroLink}>
                <span className={styles.heroLinkIcon}>{link.icon}</span>
                {link.title}
                <ArrowRightOutlined className={styles.heroLinkArrow} />
              </Link>
            ))}
          </div>
        </div>

        <div className={styles.heroBannerSide}>
          <div className={styles.heroDate}>
            <CalendarOutlined />
            <span>{today}</span>
          </div>
        </div>
      </section>

      {/* ── Stats ── */}
      <Row gutter={[16, 16]} className={styles.statsRow}>
        {STATS.map((s, i) => (
          <Col key={i} xs={12} sm={12} md={6}>
            <div className={styles.statCard} style={{ "--accent": s.accent } as React.CSSProperties}>
              <div className={styles.statIcon} style={{ background: s.iconBg, color: s.iconColor }}>
                {s.icon}
              </div>
              <div className={styles.statValue}>{s.value}</div>
              <div className={styles.statLabel}>{s.label}</div>
              <div className={styles.statHint}>{s.hint}</div>
            </div>
          </Col>
        ))}
      </Row>

      {/* ── Главные новости (ShowOnMain + приоритет) ── */}
      <FeaturedNews />

      {/* ── Именинники + события ── */}
      <Row gutter={[16, 16]} style={{ marginBottom: 16 }}>
        <Col xs={24} xl={16}>
          <div className={styles.sectionCard} style={{ height: "100%" }}>
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
          <ActivityFeed />
        </Col>
      </Row>

      {/* ── График + FAQ ── */}
      <Row gutter={[16, 16]}>
        <Col xs={24} md={12}>
          <BirthdayChart workers={allWorkers ?? []} />
        </Col>
        <Col xs={24} md={12}>
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
