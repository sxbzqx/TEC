"use client";

import React, { useState } from "react";
import { App, Form, Select, InputNumber, Input, Button, Card, Typography, Result } from "antd";
import { SendOutlined } from "@ant-design/icons";
import { useLocale } from "@/context/LocaleContext";
import { useResources } from "@/hooks/useResources";
import { documentService } from "@/services/documentService";
import { getApiErrorMessage } from "@/utils/apiError";

const { Title, Text } = Typography;

interface CreateBidFormValues {
  idResource: number;
  amount?: number;
  comment?: string;
}

export default function CreateBidsPage() {
  const { t } = useLocale();
  const { message } = App.useApp();
  const [form] = Form.useForm<CreateBidFormValues>();

  const { data: resources, isLoading: resourcesLoading, isError: resourcesError } = useResources();

  const [submitting, setSubmitting] = useState(false);
  const [submitted, setSubmitted] = useState(false);

  const handleSubmit = async (values: CreateBidFormValues) => {
    setSubmitting(true);
    try {
      await documentService.create({
        idResource: values.idResource,
        amount: values.amount ?? null,
        comment: values.comment ?? null,
      });
      message.success(t("bidsCreateSuccess"));
      setSubmitted(true);
    } catch (err) {
      message.error(getApiErrorMessage(err, t("bidsCreateError")));
    } finally {
      setSubmitting(false);
    }
  };

  const handleCreateAnother = () => {
    form.resetFields();
    setSubmitted(false);
  };

  if (submitted) {
    return (
      <div style={{ padding: 24, maxWidth: 560, margin: "0 auto" }}>
        <Result
          status="success"
          title={t("bidsCreateSuccess")}
          extra={
            <Button type="primary" onClick={handleCreateAnother}>
              {t("bidsCreateAnother")}
            </Button>
          }
        />
      </div>
    );
  }

  return (
    <div style={{ padding: 24, maxWidth: 560, margin: "0 auto" }}>
      <Title level={2}>{t("bidsCreateTitle")}</Title>
      <Text type="secondary">{t("bidsCreateSubtitle")}</Text>

      <Card style={{ marginTop: 24 }}>
        <Form<CreateBidFormValues>
          form={form}
          layout="vertical"
          onFinish={handleSubmit}
          disabled={submitting}
        >
          <Form.Item
            name="idResource"
            label={t("bidsFieldResource")}
            rules={[{ required: true, message: t("bidsFieldResourceRequired") }]}
          >
            <Select
              placeholder={t("bidsFieldResourcePlaceholder")}
              loading={resourcesLoading}
              showSearch
              optionFilterProp="label"
              status={resourcesError ? "error" : undefined}
              options={resources?.map((r) => ({ value: r.id, label: r.name }))}
              notFoundContent={resourcesError ? t("bidsResourcesLoadError") : undefined}
            />
          </Form.Item>

          <Form.Item name="amount" label={t("bidsFieldAmount")}>
            <InputNumber
              min={1}
              style={{ width: "100%" }}
              placeholder={t("bidsFieldAmountPlaceholder")}
            />
          </Form.Item>

          <Form.Item name="comment" label={t("bidsFieldComment")}>
            <Input.TextArea
              rows={4}
              maxLength={1000}
              showCount
              placeholder={t("bidsFieldCommentPlaceholder")}
            />
          </Form.Item>

          <Form.Item style={{ marginBottom: 0 }}>
            <Button
              type="primary"
              htmlType="submit"
              icon={<SendOutlined />}
              loading={submitting}
              block
            >
              {t("bidsSubmit")}
            </Button>
          </Form.Item>
        </Form>
      </Card>
    </div>
  );
}
