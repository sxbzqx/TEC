"use client";

import { Button, Input } from "antd";
import { useLocale } from "@/context/LocaleContext";

export default function SuggestionsPage() {
  const { t } = useLocale();
  return (
    <>
      <h1>{t("suggestionsTitle")}</h1>
      <div>
        <Input style={{ width: "320px" }} />
        <Button color="cyan">{t("suggestionsSend")}</Button>
      </div>
    </>
  );
}
