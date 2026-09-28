"use client";

import React, { useEffect, useMemo, useState } from "react";
import { useRouter, usePathname } from "next/navigation";
import { Layout, Menu, Button, Tooltip } from "antd";
import {
  BulbOutlined,
  BulbFilled,
  HomeOutlined,
  ReadOutlined,
  CompassOutlined,
  SettingOutlined,
  TeamOutlined,
  FileTextOutlined,
  FormOutlined,
  UserOutlined,
  LoginOutlined,
  MenuFoldOutlined,
  MenuUnfoldOutlined,
} from "@ant-design/icons";
import { useAuth } from "@/hooks/useAuth";
import { useThemeMode } from "@/context/ThemeContext";
import { useLocale } from "@/context/LocaleContext";
import { NAV_LINKS } from "@/constants/navLinks";
import type { MenuProps } from "antd";
import styles from "@/components/styles/Sidebar.module.css";

const { Sider } = Layout;

const SIDEBAR_WIDTH = 260;
const SIDEBAR_COLLAPSED_WIDTH = 68;
const STORAGE_KEY = "sidebar-collapsed";

// Иконки нужны для свёрнутого состояния (там видны только они).
const ICONS: Record<string, React.ReactNode> = {
  "/": <HomeOutlined />,
  "/news": <ReadOutlined />,
  "/navigation": <CompassOutlined />,
  "admin-sub": <SettingOutlined />,
  workers: <TeamOutlined />,
  "docs-sub": <FileTextOutlined />,
  "bids-sub": <FormOutlined />,
};

const findItemByKey = (items: any[], key: string): any => {
  for (const item of items) {
    if (item.key === key) return item;
    if (item.children) {
      const found = findItemByKey(item.children, key);
      if (found) return found;
    }
  }
  return null;
};

const prepareMenuItems = (links: any[], userRole: string, locale: string, top = true): any[] =>
  links
    .filter((link) => !link.roles || link.roles.includes(userRole))
    .map(({ isDownload, roles, children, label, labelKg, ...rest }) => ({
      ...rest,
      icon: top ? ICONS[rest.key] : undefined,
      label: locale === "kg" && labelKg ? labelKg : label,
      children: children ? prepareMenuItems(children, userRole, locale, false) : undefined,
    }));

// Ключ родительской группы для текущего пути — чтобы она была раскрыта при загрузке.
const findParentKey = (items: any[], path: string): string | null => {
  for (const item of items) {
    if (item.children?.some((c: any) => c.key === path)) return item.key;
  }
  return null;
};

export default function Sidebar() {
  const { auth } = useAuth();
  const router = useRouter();
  const pathname = usePathname();
  const { mode, toggleTheme } = useThemeMode();
  const { locale, setLocale, t } = useLocale();

  const [collapsed, setCollapsed] = useState(false);
  const [openKeys, setOpenKeys] = useState<string[]>(() => {
    const parent = findParentKey(NAV_LINKS, pathname);
    return parent ? [parent] : [];
  });

  useEffect(() => {
    try {
      setCollapsed(localStorage.getItem(STORAGE_KEY) === "1");
    } catch {}
  }, []);

  // При переходе на страницу из другой группы — раскрываем её.
  useEffect(() => {
    const parent = findParentKey(NAV_LINKS, pathname);
    if (parent) setOpenKeys((prev) => (prev.includes(parent) ? prev : [...prev, parent]));
  }, [pathname]);

  const toggleCollapsed = () => {
    setCollapsed((prev) => {
      const next = !prev;
      try {
        localStorage.setItem(STORAGE_KEY, next ? "1" : "0");
      } catch {}
      return next;
    });
  };

  const menuItems = useMemo(
    () => prepareMenuItems(NAV_LINKS, auth.role, locale),
    [auth.role, locale],
  );

  const handleMenuClick: MenuProps["onClick"] = (e) => {
    const item = findItemByKey(NAV_LINKS, e.key);

    if (item?.isDownload) {
      const link = document.createElement("a");
      link.href = e.key;
      link.download = item.label || "download";
      link.target = "_blank";
      document.body.appendChild(link);
      link.click();
      document.body.removeChild(link);
    } else if (e.key.startsWith("/")) {
      router.push(e.key);
    }
  };

  const isAuthed = auth.role !== "Guest";
  const onProfile = pathname === "/profile";
  const themeTitle = mode === "dark" ? t("themeToggleToLight") : t("themeToggleToDark");
  const profileLabel = onProfile ? t("navBackHome") : t("navProfile");
  const profileIcon = onProfile ? <HomeOutlined /> : <UserOutlined />;
  const goProfile = () => router.push(onProfile ? "/" : "/profile");
  const nextLocale = locale === "ru" ? "kg" : "ru";
  const initial = (auth.loginName || "?").charAt(0);

  const themeButton = (
    <Tooltip title={themeTitle} placement="right">
      <button type="button" className={styles.iconBtn} onClick={toggleTheme} aria-label={themeTitle}>
        {mode === "dark" ? <BulbFilled className={styles.bulbOn} /> : <BulbOutlined />}
      </button>
    </Tooltip>
  );

  return (
    <Sider
      width={SIDEBAR_WIDTH}
      collapsedWidth={SIDEBAR_COLLAPSED_WIDTH}
      collapsed={collapsed}
      trigger={null}
      theme={mode}
      className={styles.sider}
      style={{
        position: "sticky",
        top: 0,
        height: "100vh",
        overflow: "hidden",
        flexShrink: 0,
        zIndex: 1000,
      }}
    >
      <div className={styles.inner}>
        {/* Бренд + сворачивание */}
        <div
          className={styles.top}
          style={{
            justifyContent: collapsed ? "center" : "space-between",
            padding: collapsed ? 0 : "0 12px 0 16px",
          }}
        >
          {!collapsed && (
            <button type="button" className={styles.brand} onClick={() => router.push("/")}>
              <span className={styles.brandMark}>ТЭЦ</span>
              <span className={styles.brandText}>МП Бишкек ТЭЦ</span>
            </button>
          )}
          <Button
            type="text"
            onClick={toggleCollapsed}
            icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
            aria-label={collapsed ? "Развернуть меню" : "Свернуть меню"}
          />
        </div>

        {/* Навигация */}
        <div className={styles.nav}>
          <Menu
            theme={mode}
            mode="inline"
            inlineCollapsed={collapsed}
            selectedKeys={[pathname]}
            openKeys={collapsed ? undefined : openKeys}
            onOpenChange={setOpenKeys}
            items={menuItems}
            onClick={handleMenuClick}
          />
        </div>

        {/* Язык, тема, пользователь */}
        <div className={`${styles.bottom} ${collapsed ? styles.bottomCollapsed : ""}`}>
          <div className={`${styles.controls} ${collapsed ? styles.controlsCollapsed : ""}`}>
            {collapsed ? (
              <Tooltip title={t("langSwitchLabel")} placement="right">
                <button
                  type="button"
                  className={styles.iconBtn}
                  onClick={() => setLocale(nextLocale)}
                  aria-label={t("langSwitchLabel")}
                >
                  {locale.toUpperCase()}
                </button>
              </Tooltip>
            ) : (
              <div className={styles.locale} role="group" aria-label={t("langSwitchLabel")}>
                {(["ru", "kg"] as const).map((l) => (
                  <button
                    key={l}
                    type="button"
                    aria-pressed={locale === l}
                    className={`${styles.localeOpt} ${locale === l ? styles.localeOptActive : ""}`}
                    onClick={() => setLocale(l)}
                  >
                    {l.toUpperCase()}
                  </button>
                ))}
              </div>
            )}
            {themeButton}
          </div>

          {isAuthed && !collapsed && (
            <div className={styles.user}>
              <div className={styles.avatar}>{initial}</div>
              <div className={styles.userInfo}>
                <span className={styles.userName}>{auth.loginName}</span>
                <span
                  className={`${styles.userRole} ${
                    auth.role === "SuperAdmin" ? styles.userRoleSuper : ""
                  }`}
                >
                  {auth.role}
                </span>
              </div>
            </div>
          )}

          {isAuthed ? (
            collapsed ? (
              <Tooltip title={`${auth.loginName} · ${profileLabel}`} placement="right">
                <Button type="primary" icon={profileIcon} onClick={goProfile} aria-label={profileLabel} />
              </Tooltip>
            ) : (
              <Button type="primary" block icon={profileIcon} onClick={goProfile}>
                {profileLabel}
              </Button>
            )
          ) : collapsed ? (
            <Tooltip title={t("navLogin")} placement="right">
              <Button type="primary" icon={<LoginOutlined />} onClick={() => router.push("/login")} />
            </Tooltip>
          ) : (
            <Button type="primary" block icon={<LoginOutlined />} onClick={() => router.push("/login")}>
              {t("navLogin")}
            </Button>
          )}
        </div>
      </div>
    </Sider>
  );
}