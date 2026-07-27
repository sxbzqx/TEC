import React from "react";
import { Tag } from "antd";
import { GiftOutlined } from "@ant-design/icons";
import type { ColumnsType } from "antd/es/table";
import { Worker as IWorker } from "@/types/worker";
import type { TranslationKey } from "@/locales/ru";

export const getBirthdayColumns = (
  t: (key: TranslationKey) => string,
): ColumnsType<IWorker> => [
  {
    title: t("colFio"),
    dataIndex: "fio",
    key: "fio",
    render: (text) => <span style={{ fontWeight: 600, color: "var(--ink)" }}>{text}</span>,
  },
  {
    title: t("colPosition"),
    dataIndex: "doljnost",
    key: "doljnost",
    render: (text) => <span style={{ color: "var(--ink-soft)" }}>{text}</span>,
  },
  {
    title: t("colBirthday"),
    dataIndex: "dr",
    key: "dr",
    render: (dr) => (
      <span style={{ fontWeight: 500, color: "var(--ink)" }}>
        {new Date(dr).toLocaleDateString("ru-RU", { day: "numeric", month: "long" })}
      </span>
    ),
  },
  {
    title: t("colStatus"),
    key: "when",
    render: (_, record) => {
      const isToday = new Date().getDate() === new Date(record.dr).getDate();
      return isToday ? (
        <Tag color="gold" icon={<GiftOutlined />}>{t("tagToday")}</Tag>
      ) : (
        <Tag color="warning">{t("tagTomorrow")}</Tag>
      );
    },
  },
];
