"use client";

import Link from "next/link";
import {
  Button,
  Row,
  Col,
  Card,
  Typography,
  Divider,
  Tag,
} from "antd";
import { ThunderboltOutlined, ArrowRightOutlined } from "@ant-design/icons";
import styles from "@/components/styles/Main.module.css";
import FAQ_ITEMS from "@/components/main/faq";
import { useFeatures } from "@/components/main/features";
import { useQuickLinks } from "@/components/main/quickLinks";
import Image from "next/image";
import tecMain from "@/public/landingTEC.jpg";
import { useLocale } from "@/context/LocaleContext";

const { Title, Paragraph, Text } = Typography;

export default function HomePage() {
  const { t } = useLocale();
  const FEATURES = useFeatures();
  const QUICK_LINKS = useQuickLinks();

  return (
    <div className={styles.landingPage}>
      {/* ── Hero ── */}
      <section className={styles.hero}>
        <div className={styles.bgOverlay}>
          <Image
            src={tecMain}
            alt="ТЭЦ"
            fill
            priority
            quality={100}
            placeholder="empty"
            unoptimized
          />
        </div>

        <div className={styles.heroContent}>
          <Tag icon={<ThunderboltOutlined />} className={styles.heroBadge}>
            {t("landHeroBadge")}
          </Tag>

          <Title className={styles.heroTitle}>
            {t("landHeroWelcome")}&nbsp;
            <span className={styles.heroAccent}>МП Бишкек ТЭЦ</span>
          </Title>

          <Paragraph className={styles.heroSub}>
            {t("landHeroSub")}
          </Paragraph>

          <div className={styles.heroBtns}>
            <Link href="/news">
              <Button
                type="primary"
                size="large"
                icon={<ArrowRightOutlined />}
                className={styles.btnPrimary}
              >
                {t("landHeroGoSection")}
              </Button>
            </Link>
            <Link href="/navigation">
              <Button size="large" className={styles.btnGhost}>
                {t("landHeroLearnMore")}
              </Button>
            </Link>
          </div>

          <div className={styles.heroStats}>
            <div className={styles.heroStatItem}>
              <span className={styles.heroStatVal}>1700+</span>
              <span className={styles.heroStatLbl}>{t("landStatWorkers")}</span>
            </div>
            <div className={styles.heroStatDivider} />
            <div className={styles.heroStatItem}>
              <span className={styles.heroStatVal}>30+</span>
              <span className={styles.heroStatLbl}>{t("landStatDepartments")}</span>
            </div>
            <div className={styles.heroStatDivider} />
            <div className={styles.heroStatItem}>
              <span className={styles.heroStatVal}>
                {new Date().getFullYear() - 60}
              </span>
              <span className={styles.heroStatLbl}>{t("landStatFounded")}</span>
            </div>
            <div className={styles.heroStatDivider} />
            <div className={styles.heroStatItem}>
              <span className={styles.heroStatVal}>24/7</span>
              <span className={styles.heroStatLbl}>{t("landStatUptime")}</span>
            </div>
          </div>
        </div>
      </section>

      <div className={styles.landingContent}>
        {/* ── Features ── */}
        <section className={styles.section}>
          <Text className={styles.sectionLabel}>{t("landFeaturesLabel")}</Text>
          <Title level={2} className={styles.sectionTitle}>
            {t("landFeaturesTitle")}
          </Title>
          <Paragraph className={styles.sectionSub}>
            {t("landFeaturesSub")}
          </Paragraph>

          <Row gutter={[16, 16]} style={{ marginTop: 32 }}>
            {FEATURES.map((f) => (
              <Col key={f.title} xs={12} md={6}>
                <Card className={styles.featureCard} variant="borderless">
                  <div
                    className={styles.featureIcon}
                    style={{ background: f.iconBg, color: f.iconColor }}
                  >
                    {f.icon}
                  </div>
                  <Title level={5} className={styles.featureTitle}>
                    {f.title}
                  </Title>
                  <Paragraph className={styles.featureDesc}>{f.desc}</Paragraph>
                </Card>
              </Col>
            ))}
          </Row>
        </section>

        <Divider className={styles.divider} />

        {/* ── Quick links ── */}
        <section className={styles.section}>
          <Text className={styles.sectionLabel}>{t("landNavLabel")}</Text>
          <Title level={2} className={styles.sectionTitle}>
            {t("landNavTitle")}
          </Title>
          <Paragraph className={styles.sectionSub}>
            {t("landNavSub")}
          </Paragraph>

          <Row gutter={[12, 12]} style={{ marginTop: 28 }}>
            {QUICK_LINKS.map((l) => (
              <Col key={l.title} xs={12} md={6}>
                <Link href={l.href}>
                  <Card className={styles.linkCard} variant="borderless">
                    <div className={styles.linkCardInner}>
                      <div
                        className={styles.linkIcon}
                        style={{ background: l.iconBg, color: l.iconColor }}
                      >
                        {l.icon}
                      </div>
                      <div className={styles.linkText}>
                        <span className={styles.linkTitle}>{l.title}</span>
                        <span className={styles.linkSub}>{l.sub}</span>
                      </div>
                      <ArrowRightOutlined className={styles.linkArrow} />
                    </div>
                  </Card>
                </Link>
              </Col>
            ))}
          </Row>
        </section>

        {/* ── CTA Banner ── */}
        <Card className={styles.ctaBanner} variant="borderless">
          <div className={styles.ctaInner}>
            <div>
              <Title level={4} className={styles.ctaTitle}>
                {t("landCtaTitle")}
              </Title>
              <Paragraph className={styles.ctaSub}>
                {t("landCtaSub")}
              </Paragraph>
            </div>
            <Link href="/suggestions">
              <Button type="primary" size="large" className={styles.btnPrimary}>
                {t("landCtaButton")}
              </Button>
            </Link>
          </div>
        </Card>

        {/* ── FAQ ── */}
        <section className={styles.section}>
          <Text className={styles.sectionLabel}>{t("landFaqLabel")}</Text>
          <Title level={2} className={styles.sectionTitle}>
            {t("landFaqTitle")}
          </Title>

          <FAQ_ITEMS />
        </section>
      </div>
    </div>
  );
}
