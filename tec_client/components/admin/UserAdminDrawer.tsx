"use client";

import React, { useEffect, useState } from "react";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import {
  Alert,
  Avatar,
  Badge,
  Button,
  Descriptions,
  Divider,
  Drawer,
  Empty,
  Form,
  Input,
  Popconfirm,
  Select,
  Skeleton,
  Space,
  Tabs,
  Tag,
  Typography,
  message,
} from "antd";
import { adminUserKeys, adminUserService } from "@/services/adminUserService";
import { useDepartments } from "@/hooks/useDepartments";
import { useAuth } from "@/hooks/useAuth";
import { useLocale } from "@/context/LocaleContext";
import { getApiErrorMessage } from "@/utils/apiError";
import { canManageRole, getAssignableRoles, getRoleTagColor } from "@/utils/roles";
import type { AdminUserDetail } from "@/types/adminUser";

const { Text } = Typography;

interface ProfileFormValues {
  login: string;
  mail?: string;
  otdelId?: number;
}

const formatDateTime = (iso: string | null | undefined, withYear = false): string => {
  if (!iso) return "—";
  const date = new Date(iso);
  if (Number.isNaN(date.getTime())) return "—";
  return date.toLocaleString("ru-RU", {
    day: "numeric",
    month: "short",
    ...(withYear ? { year: "numeric" } : {}),
    hour: "2-digit",
    minute: "2-digit",
  });
};

interface Props {
  userId: number | null;
  onClose: () => void;
}

export default function UserAdminDrawer({ userId, onClose }: Props) {
  const { t } = useLocale();
  const { auth } = useAuth();
  const queryClient = useQueryClient();
  const [profileForm] = Form.useForm<ProfileFormValues>();

  const [roleDraft, setRoleDraft] = useState<string>("");
  const [banReason, setBanReason] = useState("");
  const [newPassword, setNewPassword] = useState("");

  const open = userId !== null;

  const {
    data: user,
    isLoading,
    isError,
  } = useQuery<AdminUserDetail>({
    queryKey: adminUserKeys.one(userId ?? 0),
    queryFn: () => adminUserService.getOne(userId as number),
    enabled: open,
  });

  const { data: departments = [] } = useDepartments();

  // Поля формы подтягиваем из данных при открытии и при изменении записи (в т.ч. другим админом),
  // но не затираем то, что админ набирает прямо сейчас — для этого зависимости только от значений полей.
  const { id: loadedId, role, username, email, otdelId } = user ?? {};

  useEffect(() => {
    if (role) setRoleDraft(role);
  }, [loadedId, role]);

  useEffect(() => {
    if (loadedId === undefined) return;
    profileForm.setFieldsValue({
      login: username,
      mail: email ?? "",
      otdelId: otdelId ?? undefined,
    });
  }, [loadedId, username, email, otdelId, profileForm]);

  useEffect(() => {
    setBanReason("");
    setNewPassword("");
  }, [userId]);

  const invalidate = () => {
    queryClient.invalidateQueries({ queryKey: adminUserKeys.list });
    if (userId !== null) {
      queryClient.invalidateQueries({ queryKey: adminUserKeys.one(userId) });
    }
  };

  const onError = (err: unknown) => message.error(getApiErrorMessage(err, t("auActionError")));

  const roleMutation = useMutation({
    mutationFn: (value: string) => adminUserService.updateRole(userId as number, value),
    onSuccess: () => {
      message.success(t("adminUsersRoleUpdated"));
      invalidate();
    },
    onError,
  });

  const profileMutation = useMutation({
    mutationFn: (values: ProfileFormValues) =>
      adminUserService.updateProfile(userId as number, {
        login: values.login,
        mail: values.mail?.trim() ? values.mail.trim() : null,
        otdelId: values.otdelId ?? null,
      }),
    onSuccess: () => {
      message.success(t("auProfileSaved"));
      invalidate();
    },
    onError,
  });

  const banMutation = useMutation({
    mutationFn: () => adminUserService.ban(userId as number, banReason.trim()),
    onSuccess: () => {
      message.success(t("auBanOk"));
      setBanReason("");
      invalidate();
    },
    onError,
  });

  const unbanMutation = useMutation({
    mutationFn: () => adminUserService.unban(userId as number),
    onSuccess: () => {
      message.success(t("auUnbanOk"));
      invalidate();
    },
    onError,
  });

  const revokeMutation = useMutation({
    mutationFn: () => adminUserService.revokeSessions(userId as number),
    onSuccess: () => {
      message.success(t("auSessionsOk"));
      invalidate();
    },
    onError,
  });

  const passwordMutation = useMutation({
    mutationFn: () => adminUserService.resetPassword(userId as number, newPassword),
    onSuccess: () => {
      message.success(t("auPasswordOk"));
      setNewPassword("");
      invalidate();
    },
    onError,
  });

  const isSelf = !!user && user.username === auth.loginName;
  const canManage = !!user && canManageRole(auth.role, user.role);
  const canEditProfile = isSelf || canManage;

  const roleOptions = (() => {
    const assignable = getAssignableRoles(auth.role);
    const list = user && !assignable.includes(user.role) ? [user.role, ...assignable] : assignable;
    return list.map((r) => ({ value: r, label: r }));
  })();

  const renderOverview = (u: AdminUserDetail) => (
    <Descriptions
      column={1}
      size="small"
      items={[
        { key: "fio", label: t("auFio"), children: u.fio ?? "—" },
        { key: "pos", label: t("auPosition"), children: u.doljnost ?? "—" },
        { key: "tabel", label: t("auTabel"), children: u.tabel ?? "—" },
        { key: "otdel", label: t("auDepartment"), children: u.otdel ?? "—" },
        { key: "mail", label: t("auEmail"), children: u.email ?? "—" },
        { key: "come", label: t("auRegistered"), children: formatDateTime(u.comeDate, true) },
        { key: "sess", label: t("auSessions"), children: u.activeSessions },
        {
          key: "status",
          label: t("auStatus"),
          children: u.isBanned ? (
            <Tag color="red">{t("auStatusBanned")}</Tag>
          ) : (
            <Tag color="green">{t("auStatusActive")}</Tag>
          ),
        },
      ]}
    />
  );

  const renderAccess = (u: AdminUserDetail) => (
    <Space direction="vertical" size={12} style={{ width: "100%" }}>
      {(isSelf || !canManage) && (
        <Alert type="info" showIcon message={isSelf ? t("auSelfNotice") : t("auNoRights")} />
      )}

      <div>
        <Text strong style={{ display: "block", marginBottom: 6 }}>
          {t("auRoleLabel")}
        </Text>
        <Space.Compact style={{ width: "100%" }}>
          <Select
            value={roleDraft || u.role}
            options={roleOptions}
            onChange={setRoleDraft}
            disabled={!canManage || isSelf}
            style={{ flex: 1 }}
          />
          <Button
            type="primary"
            loading={roleMutation.isPending}
            disabled={!canManage || isSelf || !roleDraft || roleDraft === u.role}
            onClick={() => roleMutation.mutate(roleDraft)}
          >
            {t("auRoleApply")}
          </Button>
        </Space.Compact>
        <Text type="secondary" style={{ display: "block", marginTop: 8, fontSize: 12 }}>
          {t("auRoleHint")}
        </Text>
      </div>
    </Space>
  );

  const renderProfile = () => (
    <Form
      form={profileForm}
      layout="vertical"
      disabled={!canEditProfile}
      onFinish={(values) => profileMutation.mutate(values)}
    >
      <Form.Item
        name="login"
        label={t("auLogin")}
        rules={[{ required: true, whitespace: true }]}
      >
        <Input />
      </Form.Item>
      <Form.Item name="mail" label={t("auEmail")} rules={[{ type: "email" }]}>
        <Input />
      </Form.Item>
      <Form.Item name="otdelId" label={t("auDepartment")}>
        <Select
          allowClear
          showSearch
          optionFilterProp="label"
          options={departments.map((d) => ({ value: d.id, label: d.nameOtd }))}
        />
      </Form.Item>
      <Button type="primary" htmlType="submit" loading={profileMutation.isPending}>
        {t("auSave")}
      </Button>
    </Form>
  );

  const renderSecurity = (u: AdminUserDetail) => {
    const disabled = !canManage || isSelf;

    return (
      <Space direction="vertical" size={4} style={{ width: "100%" }}>
        {disabled && (
          <Alert
            type="info"
            showIcon
            message={isSelf ? t("auSelfNotice") : t("auNoRights")}
            style={{ marginBottom: 8 }}
          />
        )}

        <Text strong>{t("auBanTitle")}</Text>
        {u.isBanned ? (
          <Space direction="vertical" size={8} style={{ width: "100%" }}>
            <Alert
              type="error"
              showIcon
              message={t("auStatusBanned")}
              description={
                <>
                  {t("auBanReasonLabel")} {u.banComment || "—"}
                  <br />
                  {formatDateTime(u.banDate, true)}
                </>
              }
            />
            <Popconfirm
              title={t("auUnbanAction")}
              okText={t("auUnbanAction")}
              cancelText={t("edCancel")}
              onConfirm={() => unbanMutation.mutate()}
              disabled={disabled}
            >
              <Button disabled={disabled} loading={unbanMutation.isPending}>
                {t("auUnbanAction")}
              </Button>
            </Popconfirm>
          </Space>
        ) : (
          <Space direction="vertical" size={8} style={{ width: "100%" }}>
            <Input.TextArea
              rows={2}
              maxLength={500}
              value={banReason}
              onChange={(e) => setBanReason(e.target.value)}
              placeholder={t("auBanReasonPh")}
              disabled={disabled}
            />
            <Popconfirm
              title={t("auBanConfirm")}
              okText={t("auBanAction")}
              okButtonProps={{ danger: true }}
              cancelText={t("edCancel")}
              onConfirm={() => banMutation.mutate()}
              disabled={disabled || !banReason.trim()}
            >
              <Button danger disabled={disabled || !banReason.trim()} loading={banMutation.isPending}>
                {t("auBanAction")}
              </Button>
            </Popconfirm>
          </Space>
        )}

        <Divider style={{ margin: "16px 0" }} />

        <Text strong>{t("auSessionsTitle")}</Text>
        <Text type="secondary" style={{ fontSize: 12 }}>
          {t("auSessions")}: {u.activeSessions}
        </Text>
        <Popconfirm
          title={t("auSessionsConfirm")}
          okText={t("auSessionsRevoke")}
          cancelText={t("edCancel")}
          onConfirm={() => revokeMutation.mutate()}
          disabled={disabled}
        >
          <Button disabled={disabled} loading={revokeMutation.isPending} style={{ width: "fit-content" }}>
            {t("auSessionsRevoke")}
          </Button>
        </Popconfirm>

        <Divider style={{ margin: "16px 0" }} />

        <Text strong>{t("auPasswordTitle")}</Text>
        <Input.Password
          value={newPassword}
          onChange={(e) => setNewPassword(e.target.value)}
          placeholder={t("auPasswordNew")}
          autoComplete="new-password"
          disabled={disabled}
        />
        <Popconfirm
          title={t("auPasswordConfirm")}
          okText={t("auPasswordReset")}
          cancelText={t("edCancel")}
          onConfirm={() => passwordMutation.mutate()}
          disabled={disabled || newPassword.length < 6}
        >
          <Button
            disabled={disabled || newPassword.length < 6}
            loading={passwordMutation.isPending}
            style={{ width: "fit-content", marginTop: 8 }}
          >
            {t("auPasswordReset")}
          </Button>
        </Popconfirm>
      </Space>
    );
  };

  const renderLog = (u: AdminUserDetail) =>
    u.recentActivity.length === 0 ? (
      <Empty description={t("auLogEmpty")} />
    ) : (
      <Space direction="vertical" size={12} style={{ width: "100%" }}>
        {u.recentActivity.map((a) => (
          <div key={a.id}>
            <Text strong style={{ display: "block" }}>
              {a.title}
            </Text>
            {a.subtitle && (
              <Text type="secondary" style={{ display: "block", fontSize: 12 }}>
                {a.subtitle}
              </Text>
            )}
            <Text type="secondary" style={{ fontSize: 12 }}>
              {formatDateTime(a.createdAt)}
            </Text>
          </div>
        ))}
      </Space>
    );

  return (
    <Drawer
      open={open}
      onClose={onClose}
      size={460}
      destroyOnHidden
      title={
        user ? (
          <Space size={12}>
            <Avatar style={{ background: "var(--brand)" }}>
              {user.username.charAt(0).toUpperCase()}
            </Avatar>
            <div style={{ lineHeight: 1.3 }}>
              <div>{user.username}</div>
              <Space size={6}>
                <Tag color={getRoleTagColor(user.role)} style={{ marginInlineEnd: 0 }}>
                  {user.role.toUpperCase()}
                </Tag>
                <Badge
                  status={user.isOnline ? "success" : "default"}
                  text={
                    <Text type="secondary" style={{ fontSize: 12 }}>
                      {user.isOnline ? t("auOnline") : t("auOffline")}
                    </Text>
                  }
                />
              </Space>
            </div>
          </Space>
        ) : (
          t("adminUsersTitle")
        )
      }
    >
      {isLoading && <Skeleton active paragraph={{ rows: 8 }} />}

      {isError && <Alert type="error" showIcon message={t("auLoadError")} />}

      {user && (
        <Tabs
          items={[
            { key: "overview", label: t("auTabOverview"), children: renderOverview(user) },
            { key: "access", label: t("auTabAccess"), children: renderAccess(user) },
            {
              key: "profile",
              label: t("auTabProfile"),
              children: renderProfile(),
              forceRender: true,
            },
            { key: "security", label: t("auTabSecurity"), children: renderSecurity(user) },
            { key: "log", label: t("auTabLog"), children: renderLog(user) },
          ]}
        />
      )}
    </Drawer>
  );
}
