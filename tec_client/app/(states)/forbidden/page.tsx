"use client";

import React from "react";
import { Result, Button } from "antd";
import { useRouter } from "next/navigation";
import { useLocale } from "@/context/LocaleContext";

export default function ForbiddenPage() {
  const router = useRouter();
  const { t } = useLocale();

  return (
    <div style={{ display: "flex", justifyContent: "center", alignItems: "center", backgroundColor: "var(--surface-soft)" }}>
      <Result
        status="403"
        title={t("forbiddenTitle")}
        subTitle={t("forbiddenSub")}
        extra={
          <Button type="primary" size="large" onClick={() => router.push("/")} style={{ backgroundColor: "var(--brand)" }}>
            {t("forbiddenHome")}
          </Button>
        }
      />
    </div>
  );
}
