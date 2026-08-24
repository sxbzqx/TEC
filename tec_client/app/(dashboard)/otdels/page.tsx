"use client";
import { Table, Tag, Typography } from "antd";
import { useDepartments } from "@/hooks/useDepartments";
import { useLocale } from "@/context/LocaleContext";

const { Title } = Typography;

export default function DepartmentsList() {
  const { data, isLoading, error } = useDepartments();
  const { t } = useLocale();

  const columns = [
    { title: t("colId"), dataIndex: "id", key: "id", width: 80 },
    { title: t("colName"), dataIndex: "nameOtd", key: "nameOtd" },
    {
      title: t("colOtdelIdCsharp"),
      dataIndex: "idOtd",
      key: "idOtd",
      render: (val: number) => <Tag color="blue">{val}</Tag>
    },
    { title: t("colDepartmentId"), dataIndex: "idDep", key: "idDep" },
    {
      title: t("colAccountantId"),
      dataIndex: "idOtdBuhgalter",
      key: "idOtdBuhgalter",
      render: (val: any) => val || "—"
    },
  ];

  if (error) return <div>{t("otdelsLoadError")}</div>;

  return (
    <div style={{ padding: "24px" }}>
      <Title level={3}>{t("otdelsTitle")}</Title>
      <Table
        columns={columns}
        dataSource={data}
        loading={isLoading}
        rowKey="id"
        pagination={{ pageSize: 10 }}
        bordered
      />
    </div>
  );
}
