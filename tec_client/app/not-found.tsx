"use client";

import { Button, Result } from "antd";
import { useRouter } from "next/navigation";
import { useLocale } from "@/context/LocaleContext";

export default function NotFoundPage() {
  const router = useRouter();
  const { t } = useLocale();

  return (
    <div style={{display: "flex", justifyContent: "center", alignItems: "center"}}>
      <Result
        status="404"
        title={t("notFoundTitle")}
        subTitle={t("notFoundSub")}
        extra={
          <Button type="primary" size="large" onClick={() => router.push("/")}>
            {t("notFoundHome")}
          </Button>
        }
      />
    </div>
  );
}
