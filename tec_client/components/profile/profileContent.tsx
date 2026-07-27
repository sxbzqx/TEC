"use client";

import React, { useEffect, useState } from "react";
import {
  Avatar,
  App,
  Card,
  Tag,
  Typography,
  Skeleton,
  Row,
  Col,
  Divider,
  Result,
  Button,
  Form,
  Input,
  Space,
} from "antd";
import {
  UserOutlined,
  ApartmentOutlined,
  ReloadOutlined,
  EditOutlined,
  LockOutlined,
  LogoutOutlined,
} from "@ant-design/icons";
import { authService } from "@/services/authService";
import { UserProfile } from "@/types/userProfile";
import { useLocale } from "@/context/LocaleContext";
import type { TranslationKey } from "@/locales/ru";
import "@/app/globals.css"

const { Title, Text } = Typography;

function useRoleMeta(t: (key: TranslationKey) => string) {
  const ROLE_META: Record<string, { label: string; tagColor: string; ring: string }> = {
    worker: { label: t("profileRoleWorker"), tagColor: "blue", ring: "var(--brand)" },
    admin: { label: t("profileRoleAdmin"), tagColor: "gold", ring: "var(--warning)" },
    superadmin: { label: t("profileRoleSuperAdmin"), tagColor: "red", ring: "var(--danger)" },
  };

  return (role?: string) => {
    const key = role?.toLowerCase() ?? "";
    return ROLE_META[key] ?? { label: role ?? "—", tagColor: "default", ring: "var(--brand)" };
  };
}

function getInitials(name?: string) {
  if (!name) return "?";
  return name.slice(0, 2).toUpperCase();
}

type Panel = "login" | "password" | null;

export default function ProfileContent() {
  const { modal, message } = App.useApp();
  const { t } = useLocale();
  const getRoleMeta = useRoleMeta(t);
  const [user, setUser] = useState<UserProfile | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(false);

  const [activePanel, setActivePanel] = useState<Panel>(null);
  const [loginSubmitting, setLoginSubmitting] = useState(false);
  const [passwordSubmitting, setPasswordSubmitting] = useState(false);

  const [loginForm] = Form.useForm();
  const [passwordForm] = Form.useForm();

  const fetchUser = async () => {
    setLoading(true);
    setError(false);
    const data = await authService.getCurrentUser();
    if (data) {
      setUser(data);
    } else {
      setError(true);
      message.error(t("profileLoadError"));
    }
    setLoading(false);
  };

  useEffect(() => {
    fetchUser();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const closePanel = () => {
    setActivePanel(null);
    loginForm.resetFields();
    passwordForm.resetFields();
  };

  const handleChangeLogin = async (values: {
    newLogin: string;
    currentPassword: string;
  }) => {
    setLoginSubmitting(true);
    try {
      await authService.changeLogin(values.newLogin, values.currentPassword);
      setUser((prev) =>
        prev ? { ...prev, loginName: values.newLogin } : prev,
      );
      message.success(t("profileLoginChanged"));
      closePanel();
    } catch (err: any) {
      message.error(
        err?.response?.data?.message ?? t("profileLoginChangeError"),
      );
    } finally {
      setLoginSubmitting(false);
    }
  };

  const handleChangePassword = async (values: {
    currentPassword: string;
    newPassword: string;
    confirmPassword: string;
  }) => {
    setPasswordSubmitting(true);
    try {
      await authService.changePassword(
        values.currentPassword,
        values.newPassword,
      );
      message.success(t("profilePasswordChanged"));
      closePanel();
    } catch (err: any) {
      message.error(
        err?.response?.data?.message ?? t("profilePasswordChangeError"),
      );
    } finally {
      setPasswordSubmitting(false);
    }
  };

  const handleLogoutClick = () => {
    modal.confirm({
      title: t("profileLogoutConfirmTitle"),
      content: t("profileLogoutConfirmContent"),
      okText: t("profileLogoutConfirmOk"),
      cancelText: t("profileLogoutConfirmCancel"),
      okButtonProps: { danger: true },
      centered: true,
      onOk: () => authService.logout(),
    });
  };

  const roleMeta = getRoleMeta(user?.role);

  return (
    <div style={{ padding: "40px 20px", maxWidth: 640, margin: "0 auto" }}>
      <style>{`
        @keyframes profileFadeIn {
          from { opacity: 0; transform: translateY(4px); }
          to { opacity: 1; transform: translateY(0); }
        }
      `}</style>

      <Card
        style={{
          padding: 0,
          borderRadius: 16,
          overflow: "hidden",
          boxShadow: "0 8px 24px rgba(15, 23, 42, 0.08)",
        }}
      >
        <div
          style={{
            height: 120,
            backgroundImage:
              "radial-gradient(circle at 85% 20%, rgba(255,255,255,0.16) 0%, transparent 45%), linear-gradient(135deg, #1B1633 0%, #534AB7 55%, #8B82E0 100%)",
          }}
        />

        <div style={{ padding: "0 32px 32px", textAlign: "center" }}>
          {loading ? (
            <div
              style={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
              }}
            >
              <Skeleton.Avatar active size={96} style={{ marginTop: -48 }} />
              <Skeleton
                active
                style={{ marginTop: 20, width: 160 }}
                paragraph={{ rows: 1, width: 100 }}
                title={{ width: 140 }}
              />
            </div>
          ) : error ? (
            <Result
              status="warning"
              title={t("profileLoadFailedTitle")}
              subTitle={t("profileLoadFailedSub")}
              extra={
                <Button icon={<ReloadOutlined />} onClick={fetchUser}>
                  {t("profileRetry")}
                </Button>
              }
            />
          ) : (
            <div style={{ animation: "profileFadeIn .35s ease" }}>
              <Avatar
                size={96}
                style={{
                  marginTop: -48,
                  background: "var(--brand)",
                  fontSize: 32,
                  fontWeight: 600,
                  boxShadow: `0 0 0 4px var(--surface), 0 0 0 7px ${roleMeta.ring}`,
                }}
              >
                {getInitials(user?.loginName)}
              </Avatar>

              <Title level={3} style={{ marginTop: 20, marginBottom: 8 }}>
                {user?.loginName}
              </Title>
              <Tag color={roleMeta.tagColor}>{roleMeta.label}</Tag>

              <Divider style={{ margin: "24px 0" }} />

              <Row gutter={16}>
                <Col span={12}>
                  <InfoBlock
                    icon={<UserOutlined />}
                    label={t("profileLoginLabel")}
                    value={user?.loginName}
                  />
                </Col>
                <Col span={12}>
                  <InfoBlock
                    icon={<ApartmentOutlined />}
                    label={t("profileDeptLabel")}
                    value={user?.department}
                  />
                </Col>
                
              </Row>

              <Divider style={{ margin: "24px 0 16px" }} />

              {activePanel === null && (
                <Space size={12}>
                  <Button
                    icon={<EditOutlined />}
                    onClick={() => setActivePanel("login")}
                  >
                    {t("profileChangeLogin")}
                  </Button>
                  <Button
                    icon={<LockOutlined />}
                    onClick={() => setActivePanel("password")}
                  >
                    {t("profileChangePassword")}
                  </Button>
                </Space>
              )}

              {activePanel === "login" && (
                <div
                  style={{
                    textAlign: "left",
                    background: "var(--surface-soft)",
                    borderRadius: 12,
                    padding: 20,
                    animation: "profileFadeIn .25s ease",
                  }}
                >
                  <Form
                    form={loginForm}
                    layout="vertical"
                    onFinish={handleChangeLogin}
                    requiredMark={false}
                  >
                    <Form.Item
                      name="newLogin"
                      label={t("profileNewLogin")}
                      rules={[
                        { required: true, message: t("profileNewLoginRequired") },
                        { min: 3, message: t("profileNewLoginMin") },
                      ]}
                    >
                      <Input placeholder={t("profileNewLoginPlaceholder")} autoFocus />
                    </Form.Item>
                    <Form.Item
                      name="currentPassword"
                      label={t("profileCurrentPassword")}
                      rules={[
                        {
                          required: true,
                          message: t("profileCurrentPasswordRequired"),
                        },
                      ]}
                    >
                      <Input.Password placeholder="••••••••" />
                    </Form.Item>
                    <Form.Item style={{ marginBottom: 0, textAlign: "right" }}>
                      <Button onClick={closePanel} style={{ marginRight: 8 }}>
                        {t("profileCancel")}
                      </Button>
                      <Button
                        type="primary"
                        htmlType="submit"
                        loading={loginSubmitting}
                      >
                        {t("profileSave")}
                      </Button>
                    </Form.Item>
                  </Form>
                </div>
              )}

              {activePanel === "password" && (
                <div
                  style={{
                    textAlign: "left",
                    background: "var(--surface-soft)",
                    borderRadius: 12,
                    padding: 20,
                    animation: "profileFadeIn .25s ease",
                  }}
                >
                  <Form
                    form={passwordForm}
                    layout="vertical"
                    onFinish={handleChangePassword}
                    requiredMark={false}
                  >
                    <Form.Item
                      name="currentPassword"
                      label={t("profileCurrentPassword")}
                      rules={[
                        { required: true, message: t("profileCurrentPasswordRequiredShort") },
                      ]}
                    >
                      <Input.Password placeholder="••••••••" autoFocus />
                    </Form.Item>
                    <Form.Item
                      name="newPassword"
                      label={t("profileNewPassword")}
                      rules={[
                        { required: true, message: t("profileNewPasswordRequired") },
                        { min: 6, message: t("profileNewPasswordMin") },
                      ]}
                    >
                      <Input.Password placeholder="••••••••" />
                    </Form.Item>
                    <Form.Item
                      name="confirmPassword"
                      label={t("profileConfirmPassword")}
                      dependencies={["newPassword"]}
                      rules={[
                        { required: true, message: t("profileConfirmPasswordRequired") },
                        ({ getFieldValue }) => ({
                          validator(_, value) {
                            if (
                              !value ||
                              getFieldValue("newPassword") === value
                            )
                              return Promise.resolve();
                            return Promise.reject(
                              new Error(t("profilePasswordsMismatch")),
                            );
                          },
                        }),
                      ]}
                    >
                      <Input.Password placeholder="••••••••" />
                    </Form.Item>
                    <Form.Item style={{ marginBottom: 0, textAlign: "right" }}>
                      <Button onClick={closePanel} style={{ marginRight: 8 }}>
                        {t("profileCancel")}
                      </Button>
                      <Button
                        type="primary"
                        htmlType="submit"
                        loading={passwordSubmitting}
                      >
                        {t("profileSave")}
                      </Button>
                    </Form.Item>
                  </Form>
                </div>
              )}
            </div>
          )}
        </div>
        <div style={{ textAlign: "center", marginTop: 24 }}>
          <Button
            type="primary"
            danger
            icon={<LogoutOutlined />}
            onClick={handleLogoutClick}
          >
            {t("profileLogout")}
          </Button>
        </div>
      </Card>
    </div>
  );
}

function InfoBlock({
  icon,
  label,
  value,
}: {
  icon: React.ReactNode;
  label: string;
  value?: string;
}) {
  return (
    <div>
      <div style={{ fontSize: 18, color: "var(--brand)", marginBottom: 6 }}>{icon}</div>
      <Text type="secondary" style={{ fontSize: 12, display: "block" }}>
        {label}
      </Text>
      <Text strong>{value ?? "—"}</Text>
    </div>
  );
}
