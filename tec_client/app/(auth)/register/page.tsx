"use client";

import React, { useState } from "react";
import { useRouter } from "next/navigation";
import { Input, Button, Alert, Form, Descriptions, Space, Typography } from "antd";
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

type EmployeeStep = "tabel" | "identity" | "credentials";

interface TabelFormValues {
  tabel: string;
}

interface IdentityFormValues {
  fio: string;
  birthDate: string;
}

interface CredentialsFormValues {
  login: string;
  password: string;
  confirmPassword: string;
}

/** "ДД.ММ.ГГГГ" -> "ГГГГ-ММ-ДД" (ISO), либо null если дата некорректна. */
function parseBirthDate(value: string): string | null {
  const match = value.trim().match(/^(\d{2})\.(\d{2})\.(\d{4})$/);
  if (!match) return null;

  const day = parseInt(match[1], 10);
  const month = parseInt(match[2], 10);
  const year = parseInt(match[3], 10);

  if (month < 1 || month > 12) return null;
  if (day < 1 || day > 31) return null;

  // Проверка количества дней в месяце с учетом високосного года
  const daysInMonth = new Date(year, month, 0).getDate();
  if (day > daysInMonth) return null;

  const currentYear = new Date().getFullYear();
  if (year < 1920 || year > currentYear) return null;

  const formattedDay = String(day).padStart(2, "0");
  const formattedMonth = String(month).padStart(2, "0");

  return `${year}-${formattedMonth}-${formattedDay}`;
}

/** Автоматическое форматирование даты ДД.ММ.ГГГГ при вводе */
function formatBirthDateInput(value: string): string {
  // Оставляем только цифры
  const digits = value.replace(/\D/g, "").slice(0, 8);

  let formatted = "";

  if (digits.length > 0) {
    let day = digits.slice(0, 2);
    // Ограничиваем первую цифру дня (не больше 3)
    if (parseInt(day[0], 10) > 3) day = "3" + (day[1] || "");
    // Ограничиваем день до 31
    if (day.length === 2 && parseInt(day, 10) > 31) day = "31";
    formatted += day;
  }

  if (digits.length >= 3) {
    let month = digits.slice(2, 4);
    // Ограничиваем первую цифру месяца (не больше 1)
    if (parseInt(month[0], 10) > 1) month = "1" + (month[1] || "");
    // Ограничиваем месяц до 12
    if (month.length === 2 && parseInt(month, 10) > 12) month = "12";
    if (month.length === 2 && month === "00") month = "01";
    formatted += "." + month;
  }

  if (digits.length >= 5) {
    const year = digits.slice(4, 8);
    formatted += "." + year;
  }

  return formatted;
}

export default function RegisterPage() {
  const { t } = useLocale();
  const router = useRouter();
  const { refreshAuth } = useAuth();

  const [error, setError] = useState<string | null>(null);
  const [loading, setLoading] = useState(false);

  // --- Сотрудник: 3 шага ---
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
    credentialsForm.resetFields();
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

  const submitCredentials = async ({ login, password }: CredentialsFormValues) => {
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
        "" 
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

      {/* ШАГ 1: Табельный номер */}
      {employeeStep === "tabel" && (
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

      {/* ШАГ 2: Подтверждение личности и Дата рождения */}
      {employeeStep === "identity" && lookupResult && (
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
                  validator(_, value) {
                    if (!value) return Promise.resolve();
                    if (!parseBirthDate(value)) {
                      return Promise.reject(new Error(t("authEmployeeBirthDateFormatError")));
                    }
                    return Promise.resolve();
                  },
                },
              ]}
            >
              <Input
                prefix={<CalendarOutlined style={{ color: "var(--ink-faint)" }} />}
                placeholder="ДД.ММ.ГГГГ"
                disabled={loading}
                autoComplete="off"
                maxLength={10}
                onChange={(e) => {
                  const formatted = formatBirthDateInput(e.target.value);
                  identityForm.setFieldsValue({ birthDate: formatted });
                }}
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

      {/* ШАГ 3: Учетные данные (Логин, Email, Пароль) */}
      {employeeStep === "credentials" && (
        <Form form={credentialsForm} layout="vertical" onFinish={submitCredentials} requiredMark={false} size="large">
          <Form.Item name="login" label={t("authLoginFieldLogin")} rules={[{ required: true, message: t("authLoginFieldLoginRequired") }]}>
            <Input
              prefix={<UserOutlined style={{ color: "var(--ink-faint)" }} />}
              placeholder={t("authRegisterPlaceholderLogin")}
              disabled={loading}
              autoComplete="username"
            />
          </Form.Item>

          {/* <Form.Item
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
          </Form.Item> */}

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