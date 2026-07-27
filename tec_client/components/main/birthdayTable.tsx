"use client";

import { Table } from "antd";
import { getBirthdayColumns } from "./birthdayColumns";
import { Worker as IWorker } from "@/types/worker";
import { useLocale } from "@/context/LocaleContext";

export const BirthdayTable = ({ data, loading }: { data: IWorker[], loading: boolean }) => {
  const { t } = useLocale();

  return (
    <Table
      columns={getBirthdayColumns(t)}
      dataSource={data}
      rowKey="id"
      loading={loading}
      pagination={false}
      size="middle"
      locale={{ emptyText: t("birthdayTableEmpty") }}
    />
  );
};
