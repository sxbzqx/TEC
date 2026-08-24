"use client";

import React, { useState } from "react";
import { useRouter } from "next/navigation";
import { Input, Button, Alert, Form, Segmented, Descriptions, Space, Typography } from "antd";
import {
  UserOutlined,
  MailOutlined,
  LockOutlined,
  IdcardOutlined,
  SolutionOutlined,
  CalendarOutlined,
} from "@ant-design/icons";
import { authService, EmployeeLookupResult } from "@/services/authService";
import { useAuth } from "@/hooks/useAuth";
import { getApiErrorMessage } from "@/utils/apiError";
import AuthShell from "@/components/auth/AuthShell";
import { useLocale } from "@/context/LocaleContext";

const { Text } = Typography;

type Mode = "plain" | "employee";
type EmployeeStep = "tabel" | "identity" | "credentials";

interface PlainFormValues {
  login: string;
  mail: string;
  password: string;
  confirmPassword: string;
}

interface TabelFormValues {
  tabel: string;
}

interface IdentityFormValues {
  fio: string;
  birthDate: string;
}

/** "ДД.ММ.ГГГГ" -> "ГГГГ-ММ-ДД" (ISO), либо null если формат не совпал. */
function parseBirthDate(value: string): string | null {
  const match = value.trim().match(/^(\d{2})\.(\d{2})\.(\d{4})$/);
  if (!match) return null;
  const [, day, month, year] = match;
  return `${year}-${month}-${day}`;
}

interface CredentialsFormValues {
  login: string;
  mail: string;
  password: string;
  confirmPassword: string;
}

export default function RegisterPage() {
  const { t } = useLocale();
  const router = useRouter();
  const { refreshAuth } = useAuth();

  const [mode, setMode] = useState<Mode>("plain");
  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  // --- обычный пользователь ---
  const [plainForm] = Form.useForm<PlainFormValues>();

  const submitPlain = async ({ login, mail, password }: PlainFormValues) => {
    setError(null);
    setLoading(true);
    try {
      await authService.register(login.trim(), password, mail.trim());
      await refreshAuth();
      router.push("/");
    } catch (err) {
      setError(getApiErrorMessage(err, t("authRegisterError")));
    } finally {
      setLoading(false);
    }
  };

  // --- сотрудник: 3 шага ---
  const [employeeStep, setEmployeeStep] = useState<EmployeeStep>("tabel");
  const [tabel, setTabel] = useState("");
  const [lookupResult, setLookupResult] = useState<EmployeeLookupResult | null>(null);
  const [identity, setIdentity] = useState<{ fio: string; birthDate: string } | null>(null);
  const [tabelForm] = Form.useForm<TabelFormValues>();
  const [identityForm] = Form.useForm<IdentityFormValues>();
  const [credentialsForm] = Form.useForm<CredentialsFormValues>();

  const submitTabel = async ({ tabel: tabelValue }: TabelFormValues) => {
    setError(null);
    setLoading(true);
    try {
      const result = await authService.employeeLookup(tabelValue.trim());
      setTabel(tabelValue.trim());
      setLookupResult(result);
      setEmployeeStep("identity");
    } catch (err) {
      setError(getApiErrorMessage(err, t("authEmployeeLookupError")));
    } finally {
      setLoading(false);
    }
  };

  const resetEmployeeFlow = () => {
    setEmployeeStep("tabel");
    setLookupResult(null);
    setIdentity(null);
    setTabel("");
    tabelForm.resetFields();
    identityForm.resetFields();
    setError(null);
  };

  const submitIdentity = async ({ fio, birthDate }: IdentityFormValues) => {
    setError(null);

    const isoBirthDate = parseBirthDate(birthDate);
    if (!isoBirthDate) {
      setError(t("authEmployeeBirthDateFormatError"));
      return;
    }

    setLoading(true);
    try {
      await authService.employeeVerify(tabel, fio.trim(), isoBirthDate);
      setIdentity({ fio: fio.trim(), birthDate: isoBirthDate });
      setEmployeeStep("credentials");
    } catch (err) {
      setError(getApiErrorMessage(err, t("authEmployeeIdentityError")));
    } finally {
      setLoading(false);
    }
  };

  const submitCredentials = async ({ login, mail, password }: CredentialsFormValues) => {
    if (!identity) {
      setEmployeeStep("identity");
      return;
    }

    setError(null);
    setLoading(true);
    try {
      await authService.employeeRegister(
        tabel,
        identity.fio,
        identity.birthDate,
        login.trim(),
        password,
        mail.trim(),
      );
      await refreshAuth();
      router.push("/");
    } catch (err) {
      setError(getApiErrorMessage(err, t("authEmployeeRegisterError")));
    } finally {
      setLoading(false);
    }
  };

  return (
    <AuthShell
      title={t("authRegisterTitle")}
      subtitleText={t("authRegisterHaveAccount")}
      subtitleLinkHref="/login"
      subtitleLinkText={t("authRegisterLoginLink")}
    >
      <Segmented
        block
        value={mode}
        onChange={(value) => {
          setMode(value as Mode);
          setError(null);
        }}
        options={[
          { label: t("authRegisterModePlain"), value: "plain" },
          { label: t("authRegisterModeEmployee"), value: "employee" },
        ]}
        style={{ marginBottom: 24 }}
        disabled={loading}
      />

      {error && (
        <Alert
          message={error}
          type="error"
          showIcon
          closable
          onClose={() => setError(null)}
          style={{ marginBottom: 20 }}
        />
      )}

      {mode === "plain" && (
        <Form form={plainForm} layout="vertical" onFinish={submitPlain} requiredMark={false} size="large">
          <Form.Item name="login" label={t("authLoginFieldLogin")} rules={[{ required: true, message: t("authLoginFieldLoginRequired") }]}>
            <Input
              prefix={<UserOutlined style={{ color: "var(--ink-faint)" }} />}
              placeholder={t("authRegisterPlaceholderLogin")}
              disabled={loading}
              autoComplete="username"
            />
          </Form.Item>

          <Form.Item
            name="mail"
            label={t("authRegisterFieldEmail")}
            rules={[
              { required: true, message: t("authRegisterFieldEmailRequired") },
              { type: "email", message: t("authRegisterFieldEmailInvalid") },
            ]}
          >
            <Input
              prefix={<MailOutlined style={{ color: "var(--ink-faint)" }} />}
              placeholder="name@example.com"
              disabled={loading}
              autoComplete="email"
            />
          </Form.Item>

          <Form.Item
            name="password"
            label={t("authLoginFieldPassword")}
            rules={[
              { required: true, message: t("authRegisterFieldPasswordRequired") },
              { min: 6, message: t("authRegisterFieldPasswordMin") },
            ]}
          >
            <Input.Password
              prefix={<LockOutlined style={{ color: "var(--ink-faint)" }} />}
              placeholder="••••••••"
              disabled={loading}
              autoComplete="new-password"
            />
          </Form.Item>

          <Form.Item
            name="confirmPassword"
            label={t("authRegisterFieldConfirm")}
            dependencies={["password"]}
            rules={[
              { required: true, message: t("authRegisterFieldConfirmRequired") },
              ({ getFieldValue }) => ({
                validator(_, value) {
                  if (!value || getFieldValue("password") === value) return Promise.resolve();
                  return Promise.reject(new Error(t("authRegisterPasswordsMismatch")));
                },
              }),
            ]}
          >
            <Input.Password
              prefix={<LockOutlined style={{ color: "var(--ink-faint)" }} />}
              placeholder="••••••••"
              disabled={loading}
              autoComplete="new-password"
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
              {loading ? t("authRegisterSubmitting") : t("authRegisterSubmit")}
            </Button>
          </Form.Item>
        </Form>
      )}

      {mode === "employee" && employeeStep === "tabel" && (
        <Form form={tabelForm} layout="vertical" onFinish={submitTabel} requiredMark={false} size="large">
          <Form.Item
            name="tabel"
            label={t("authEmployeeTabelLabel")}
            rules={[{ required: true, message: t("authEmployeeTabelRequired") }]}
          >
            <Input
              prefix={<IdcardOutlined style={{ color: "var(--ink-faint)" }} />}
              placeholder={t("authEmployeeTabelPlaceholder")}
              disabled={loading}
              autoComplete="off"
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
              {t("authEmployeeFindButton")}
            </Button>
          </Form.Item>
        </Form>
      )}

      {mode === "employee" && employeeStep === "identity" && lookupResult && (
        <Space direction="vertical" size="middle" style={{ width: "100%" }}>
          <Descriptions bordered column={1} size="small">
            <Descriptions.Item label={t("authEmployeeConfirmOtdel")}>{lookupResult.otdel}</Descriptions.Item>
            <Descriptions.Item label={t("authEmployeeConfirmDoljnost")}>{lookupResult.doljnost}</Descriptions.Item>
          </Descriptions>

          <Text type="secondary">{t("authEmployeeIdentityHint")}</Text>

          <Form form={identityForm} layout="vertical" onFinish={submitIdentity} requiredMark={false} size="large">
            <Form.Item
              name="fio"
              label={t("authEmployeeConfirmFio")}
              rules={[{ required: true, message: t("authEmployeeFioRequired") }]}
            >
              <Input
                prefix={<SolutionOutlined style={{ color: "var(--ink-faint)" }} />}
                placeholder={t("authEmployeeFioPlaceholder")}
                disabled={loading}
                autoComplete="off"
              />
            </Form.Item>

            <Form.Item
              name="birthDate"
              label={t("authEmployeeConfirmBirthDate")}
              rules={[
                { required: true, message: t("authEmployeeBirthDateRequired") },
                {
                  pattern: /^\d{2}\.\d{2}\.\d{4}$/,
                  message: t("authEmployeeBirthDateFormatError"),
                },
              ]}
            >
              <Input
                prefix={<CalendarOutlined style={{ color: "var(--ink-faint)" }} />}
                placeholder="ДД.ММ.ГГГГ"
                disabled={loading}
                autoComplete="off"
              />
            </Form.Item>

            <Form.Item style={{ marginBottom: 0, marginTop: 8 }}>
              <Space direction="vertical" style={{ width: "100%" }}>
                <Button
                  type="primary"
                  htmlType="submit"
                  block
                  loading={loading}
                  style={{ borderRadius: 8, fontWeight: 500, background: "var(--brand)", borderColor: "var(--brand)", height: 44 }}
                >
                  {t("authEmployeeIdentityContinue")}
                </Button>
                <Button block disabled={loading} onClick={resetEmployeeFlow}>
                  {t("authEmployeeBackToTabel")}
                </Button>
              </Space>
            </Form.Item>
          </Form>
        </Space>
      )}

      {mode === "employee" && employeeStep === "credentials" && (
        <Form form={credentialsForm} layout="vertical" onFinish={submitCredentials} requiredMark={false} size="large">
          <Form.Item name="login" label={t("authLoginFieldLogin")} rules={[{ required: true, message: t("authLoginFieldLoginRequired") }]}>
            <Input
              prefix={<UserOutlined style={{ color: "var(--ink-faint)" }} />}
              placeholder={t("authRegisterPlaceholderLogin")}
              disabled={loading}
              autoComplete="username"
            />
          </Form.Item>

          <Form.Item
            name="mail"
            label={t("authRegisterFieldEmail")}
            rules={[
              { required: true, message: t("authRegisterFieldEmailRequired") },
              { type: "email", message: t("authRegisterFieldEmailInvalid") },
            ]}
          >
            <Input
              prefix={<MailOutlined style={{ color: "var(--ink-faint)" }} />}
              placeholder="name@example.com"
              disabled={loading}
              autoComplete="email"
            />
          </Form.Item>

          <Form.Item
            name="password"
            label={t("authLoginFieldPassword")}
            rules={[
              { required: true, message: t("authRegisterFieldPasswordRequired") },
              { min: 6, message: t("authRegisterFieldPasswordMin") },
            ]}
          >
            <Input.Password
              prefix={<LockOutlined style={{ color: "var(--ink-faint)" }} />}
              placeholder="••••••••"
              disabled={loading}
              autoComplete="new-password"
            />
          </Form.Item>

          <Form.Item
            name="confirmPassword"
            label={t("authRegisterFieldConfirm")}
            dependencies={["password"]}
            rules={[
              { required: true, message: t("authRegisterFieldConfirmRequired") },
              ({ getFieldValue }) => ({
                validator(_, value) {
                  if (!value || getFieldValue("password") === value) return Promise.resolve();
                  return Promise.reject(new Error(t("authRegisterPasswordsMismatch")));
                },
              }),
            ]}
          >
            <Input.Password
              prefix={<LockOutlined style={{ color: "var(--ink-faint)" }} />}
              placeholder="••••••••"
              disabled={loading}
              autoComplete="new-password"
            />
          </Form.Item>

          <Form.Item style={{ marginBottom: 0, marginTop: 8 }}>
            <Space direction="vertical" style={{ width: "100%" }}>
              <Button
                type="primary"
                htmlType="submit"
                block
                loading={loading}
                style={{ borderRadius: 8, fontWeight: 500, background: "var(--brand)", borderColor: "var(--brand)", height: 44 }}
              >
                {loading ? t("authRegisterSubmitting") : t("authEmployeeSubmit")}
              </Button>
              <Button block disabled={loading} onClick={resetEmployeeFlow}>
                {t("authEmployeeBackToTabel")}
              </Button>
            </Space>
          </Form.Item>
        </Form>
      )}
    </AuthShell>
  );
}