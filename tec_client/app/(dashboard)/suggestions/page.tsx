"use client";

import React, { useState } from "react";
import Link from "next/link";
import { App, Button, Card, Form, Input, Result, Typography } from "antd";
import { SendOutlined } from "@ant-design/icons";
import { useLocale } from "@/context/LocaleContext";
import { useCreateSuggestion } from "@/hooks/useSuggestions";
import { getApiErrorMessage } from "@/utils/apiError";

const { Title, Text } = Typography;

interface SuggestionFormValues {
  text: string;
  comment?: string;
}

export default function SuggestionsPage() {
  const { t } = useLocale();
  const { message } = App.useApp();
  const [form] = Form.useForm<SuggestionFormValues>();
  const createSuggestion = useCreateSuggestion();
  const [submitted, setSubmitted] = useState(false);

  const handleSubmit = async (values: SuggestionFormValues) => {
    try {
      await createSuggestion.mutateAsync({
        text: values.text.trim(),
        comment: values.comment?.trim() || null,
      });
      message.success(t("suggestionsSendSuccess"));
      setSubmitted(true);
    } catch (err) {
      message.error(getApiErrorMessage(err, t("suggestionsSendError")));
    }
  };

  const handleSendAnother = () => {
    form.resetFields();
    setSubmitted(false);
  };

  if (submitted) {
    return (
      <div style={{ padding: 24, maxWidth: 560, margin: "0 auto" }}>
        <Result
          status="success"
          title={t("suggestionsSendSuccess")}
          extra={[
            <Button key="another" type="primary" onClick={handleSendAnother}>
              {t("suggestionsSendAnother")}
            </Button>,
            <Link key="my" href="/suggestions/my">
              <Button>{t("suggestionsMyTitle")}</Button>
            </Link>,
          ]}
        />
      </div>
    );
  }

  return (
    <div style={{ padding: 24, maxWidth: 560, margin: "0 auto" }}>
      <Title level={2}>{t("suggestionsTitle")}</Title>
      <Text type="secondary">{t("suggestionsSubtitle")}</Text>

      <Card style={{ marginTop: 24 }}>
        <Form<SuggestionFormValues>
          form={form}
          layout="vertical"
          onFinish={handleSubmit}
          disabled={createSuggestion.isPending}
        >
          <Form.Item
            name="text"
            label={t("suggestionsFieldText")}
            rules={[
              { required: true, whitespace: true, message: t("suggestionsFieldTextRequired") },
            ]}
          >
            <Input.TextArea
              rows={5}
              maxLength={1000}
              showCount
              placeholder={t("suggestionsFieldTextPlaceholder")}
            />
          </Form.Item>

          <Form.Item name="comment" label={t("suggestionsFieldComment")}>
            <Input.TextArea
              rows={3}
              maxLength={500}
              showCount
              placeholder={t("suggestionsFieldCommentPlaceholder")}
            />
          </Form.Item>

          <Form.Item style={{ marginBottom: 0 }}>
            <Button
              type="primary"
              htmlType="submit"
              icon={<SendOutlined />}
              loading={createSuggestion.isPending}
              block
            >
              {t("suggestionsSend")}
            </Button>
          </Form.Item>
        </Form>
      </Card>

      <div style={{ marginTop: 16, textAlign: "center" }}>
        <Link href="/suggestions/my">{t("suggestionsMyTitle")}</Link>
      </div>
    </div>
  );
}
