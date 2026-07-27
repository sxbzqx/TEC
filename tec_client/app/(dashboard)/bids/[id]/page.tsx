"use client";

import React, { useState } from "react";
import { useParams, useRouter } from "next/navigation";
import { App, Typography, Descriptions, Tag, Spin, Button, Space, Modal, Form, Input, Result } from "antd";
import {
  ArrowLeftOutlined,
  CheckOutlined,
  CloseOutlined,
  PauseOutlined,
  CheckCircleOutlined,
} from "@ant-design/icons";
import { useLocale } from "@/context/LocaleContext";
import { useBidDetail, useDecideBid, useCompleteBid } from "@/hooks/useIncomingBids";
import { DocumentIncoming } from "@/types/document";
import { getApiErrorMessage } from "@/utils/apiError";

const { Title } = Typography;

type DecisionAction = 1 | 2 | 3;

export default function BidDetailPage() {
  const { id } = useParams<{ id: string }>();
  const router = useRouter();
  const { t } = useLocale();
  const { message } = App.useApp();

  const { data: bid, isLoading, isError } = useBidDetail(id);
  const decideMutation = useDecideBid();
  const completeMutation = useCompleteBid();

  const [decisionAction, setDecisionAction] = useState<DecisionAction | null>(null);
  const [decisionForm] = Form.useForm<{ comment?: string }>();

  const statusMeta = (record: DocumentIncoming): { label: string; color: string } => {
    if (record.action === 0) return { label: t("bidStatusPending"), color: "gold" };
    if (record.action === 2) return { label: t("bidStatusRejected"), color: "red" };
    if (record.action === 3) return { label: t("bidStatusPostponed"), color: "default" };
    return record.made === 1
      ? { label: t("bidStatusDone"), color: "green" }
      : { label: t("bidStatusApproved"), color: "blue" };
  };

  const closeDecisionModal = () => setDecisionAction(null);

  const handleApprove = async () => {
    if (!bid) return;
    try {
      await decideMutation.mutateAsync({ id: bid.id, action: 1 });
      message.success(t("bidDecisionSuccess"));
    } catch (err) {
      message.error(getApiErrorMessage(err, t("bidDecisionError")));
    }
  };

  const handleDecisionSubmit = async (values: { comment?: string }) => {
    if (!bid || !decisionAction) return;
    try {
      await decideMutation.mutateAsync({ id: bid.id, action: decisionAction, comment: values.comment });
      message.success(t("bidDecisionSuccess"));
      closeDecisionModal();
    } catch (err) {
      message.error(getApiErrorMessage(err, t("bidDecisionError")));
    }
  };

  const handleComplete = async () => {
    if (!bid) return;
    try {
      await completeMutation.mutateAsync(bid.id);
      message.success(t("bidCompleteSuccess"));
    } catch (err) {
      message.error(getApiErrorMessage(err, t("bidCompleteError")));
    }
  };

  const backButton = (
    <Button icon={<ArrowLeftOutlined />} onClick={() => router.push("/bids/incoming")} style={{ marginBottom: 16 }}>
      {t("bidDetailBack")}
    </Button>
  );

  if (isLoading) {
    return (
      <div style={{ padding: 24, textAlign: "center" }}>
        <Spin size="large" />
      </div>
    );
  }

  if (isError || !bid) {
    return (
      <div style={{ padding: 24, maxWidth: 560, margin: "0 auto" }}>
        {backButton}
        <Result status="error" title={t("bidDetailLoadError")} subTitle={t("bidDetailNotFound")} />
      </div>
    );
  }

  const meta = statusMeta(bid);
  // Заявка ждёт решения впервые (0) или ранее была отложена (3) — из отложенного
  // можно снова выбрать любой статус.
  const isDecidable = bid.action === 0 || bid.action === 3;
  const isCompletable = bid.action === 1 && bid.made === 0;

  return (
    <div style={{ padding: 24, maxWidth: 720, margin: "0 auto" }}>
      {backButton}

      <Title level={2}>
        {t("bidDetailTitle")} №{bid.id}
      </Title>

      <Descriptions bordered column={1} size="middle" style={{ marginTop: 16 }}>
        <Descriptions.Item label={t("colMaterial")}>{bid.resourceName}</Descriptions.Item>
        <Descriptions.Item label={t("bidDetailCreator")}>
          {bid.creatorName}
          {bid.creatorDepartment ? ` (${bid.creatorDepartment})` : ""}
        </Descriptions.Item>
        <Descriptions.Item label={t("colAmount")}>{bid.amount ?? "—"}</Descriptions.Item>
        <Descriptions.Item label={t("colComment")}>{bid.comment || "—"}</Descriptions.Item>
        <Descriptions.Item label={t("colSubmitDate")}>
          {new Date(bid.dateFirst).toLocaleString()}
        </Descriptions.Item>
        <Descriptions.Item label={t("colStatus")}>
          <Tag color={meta.color}>{meta.label}</Tag>
        </Descriptions.Item>
        {bid.dateReshenie && (
          <Descriptions.Item label={t("bidDetailDecisionAt")}>
            {new Date(bid.dateReshenie).toLocaleString()}
          </Descriptions.Item>
        )}
        {bid.commentReshenie && (
          <Descriptions.Item label={t("bidDetailDecisionComment")}>{bid.commentReshenie}</Descriptions.Item>
        )}
        {bid.dateVyp && (
          <Descriptions.Item label={t("bidDetailCompletedAt")}>
            {new Date(bid.dateVyp).toLocaleString()}
          </Descriptions.Item>
        )}
      </Descriptions>

      {(isDecidable || isCompletable) && (
        <Space style={{ marginTop: 24 }}>
          {isDecidable && (
            <>
              <Button
                type="primary"
                icon={<CheckOutlined />}
                onClick={handleApprove}
                loading={decideMutation.isPending}
              >
                {t("bidActionApprove")}
              </Button>
              <Button danger icon={<CloseOutlined />} onClick={() => setDecisionAction(2)}>
                {t("bidActionReject")}
              </Button>
              <Button icon={<PauseOutlined />} onClick={() => setDecisionAction(3)}>
                {t("bidActionPostpone")}
              </Button>
            </>
          )}
          {isCompletable && (
            <Button
              type="primary"
              icon={<CheckCircleOutlined />}
              onClick={handleComplete}
              loading={completeMutation.isPending}
            >
              {t("bidActionComplete")}
            </Button>
          )}
        </Space>
      )}

      <Modal
        title={decisionAction === 2 ? t("bidActionReject") : t("bidActionPostpone")}
        open={decisionAction !== null}
        onCancel={closeDecisionModal}
        onOk={() => decisionForm.submit()}
        okText={t("bidDecisionConfirm")}
        cancelText={t("bidDecisionCancel")}
        confirmLoading={decideMutation.isPending}
        destroyOnHidden
      >
        <Form form={decisionForm} layout="vertical" onFinish={handleDecisionSubmit}>
          <Form.Item
            name="comment"
            label={t("bidDecisionCommentLabel")}
            rules={[{ required: true, message: t("bidDecisionCommentRequired") }]}
          >
            <Input.TextArea rows={3} maxLength={150} showCount />
          </Form.Item>
        </Form>
      </Modal>
    </div>
  );
}
