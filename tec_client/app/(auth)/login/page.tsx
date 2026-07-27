"use client";

import React, { useState } from "react";
import { useRouter } from "next/navigation";
import { Input, Button, Alert, Form } from "antd";
import { UserOutlined, LockOutlined } from "@ant-design/icons";
import { authService } from "@/services/authService";
import { useAuth } from "@/hooks/useAuth";
import { getApiErrorMessage } from "@/utils/apiError";
import AuthShell from "@/components/auth/AuthShell";
import { useLocale } from "@/context/LocaleContext";

interface LoginFormValues {
  login: string;
  password: string;
}

export default function LoginPage() {
  const { t } = useLocale();
  const [form] = Form.useForm<LoginFormValues>();
  const router = useRouter();
  const { refreshAuth } = useAuth();
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  const onFinish = async ({ login, password }: LoginFormValues) => {
    setError(null);
    setLoading(true);
    try {
      await authService.login(login.trim(), password);
      await refreshAuth();
      router.push("/");
    } catch (err) {
      console.error("Ошибка авторизации:", err);
      setError(getApiErrorMessage(err, t("authLoginError")));
      setLoading(false);
    }
  };

  return (
    <AuthShell
      title={t("authLoginTitle")}
      subtitleText={t("authLoginNoAccount")}
      subtitleLinkHref="/register"
      subtitleLinkText={t("authLoginRegisterLink")}
    >
      <Form form={form} layout="vertical" onFinish={onFinish} requiredMark={false} size="large">
        {error && (
          <Form.Item style={{ marginBottom: 20 }}>
            <Alert message={error} type="error" showIcon closable onClose={() => setError(null)} />
          </Form.Item>
        )}

        <Form.Item name="login" label={t("authLoginFieldLogin")} rules={[{ required: true, message: t("authLoginFieldLoginRequired") }]}>
          <Input
            prefix={<UserOutlined style={{ color: "var(--ink-faint)" }} />}
            placeholder={t("authLoginPlaceholderLogin")}
            disabled={loading}
            autoComplete="username"
          />
        </Form.Item>

        <Form.Item name="password" label={t("authLoginFieldPassword")} rules={[{ required: true, message: t("authLoginFieldPasswordRequired") }]}>
          <Input.Password
            prefix={<LockOutlined style={{ color: "var(--ink-faint)" }} />}
            placeholder="••••••••"
            disabled={loading}
            autoComplete="current-password"
          />
        </Form.Item>

        <Form.Item style={{ marginBottom: 0, marginTop: 8 }}>
          <Button
            type="primary"
            htmlType="submit"
            block
            loading={loading}
            style={{ borderRadius: 8, fontWeight: 500, background: "var(--brand)", borderColor: "var(--brand)", height: 44 }}
          >
            {loading ? t("authLoginSubmitting") : t("authLoginSubmit")}
          </Button>
        </Form.Item>
      </Form>
    </AuthShell>
  );
}