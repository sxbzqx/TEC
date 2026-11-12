import type { TranslationKey } from "@/locales/ru";
import type { BidIncoming } from "@/types/bid";

export type BidStatusKey = "pending" | "approved" | "done" | "rejected" | "postponed";

/** Единый статус заявки: решение (action) + признак выполнения (made). */
export function getBidStatus(
  bid: Pick<BidIncoming, "action" | "made">,
  t: (key: TranslationKey) => string,
): { key: BidStatusKey; label: string; color: string } {
  if (bid.action === 0) return { key: "pending", label: t("bidStatusPending"), color: "gold" };
  if (bid.action === 2) return { key: "rejected", label: t("bidStatusRejected"), color: "red" };
  if (bid.action === 3) return { key: "postponed", label: t("bidStatusPostponed"), color: "default" };
  return bid.made === 1
    ? { key: "done", label: t("bidStatusDone"), color: "green" }
    : { key: "approved", label: t("bidStatusApproved"), color: "blue" };
}
