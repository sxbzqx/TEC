import type { CSSProperties } from "react";
import type { Post, PostPriority } from "@/types/post";
import type { TranslationKey } from "@/locales/ru";

export const PRIORITIES: PostPriority[] = [0, 1, 2];

export const PRIORITY_META: Record<
  PostPriority,
  { labelKey: TranslationKey; color: string; soft: string; dark: string }
> = {
  0: {
    labelKey: "newsPriorityNormal",
    color: "var(--brand)",
    soft: "var(--brand-soft)",
    dark: "var(--brand-dark)",
  },
  1: {
    labelKey: "newsPriorityImportant",
    color: "var(--warning)",
    soft: "var(--warning-soft)",
    dark: "var(--warning-dark)",
  },
  2: {
    labelKey: "newsPriorityUrgent",
    color: "var(--danger)",
    soft: "var(--danger-soft)",
    dark: "var(--danger-dark)",
  },
};

export function normalizePriority(value: unknown): PostPriority {
  return value === 1 || value === 2 ? value : 0;
}

/** Убирает markdown-разметку — для превью в карточках и таблице. */
export function stripMarkdown(text: string | null | undefined): string {
  return (text ?? "")
    .replace(/^\s{0,3}(#{1,6}|>|[-*]|\d+\.)\s+/gm, "")
    .replace(/\[([^\]]+)\]\([^)]+\)/g, "$1")
    .replace(/(\*\*|\*)/g, "")
    .replace(/\s+/g, " ")
    .trim();
}

export function getExcerpt(post: Pick<Post, "summary" | "content">, max = 160): string {
  const base = post.summary?.trim() ? post.summary.trim() : stripMarkdown(post.content);
  return base.length > max ? `${base.slice(0, max).trimEnd()}…` : base;
}

export function readingMinutes(content: string | null | undefined): number {
  const words = stripMarkdown(content).split(" ").filter(Boolean).length;
  return Math.max(1, Math.round(words / 200));
}

export function formatNewsDate(iso: string | null | undefined, withYear = true): string {
  if (!iso) return "";
  const d = new Date(iso);
  if (Number.isNaN(d.getTime())) return "";
  return d.toLocaleDateString("ru-RU", {
    day: "numeric",
    month: "long",
    ...(withYear ? { year: "numeric" } : {}),
  });
}

export function formatNewsDateShort(iso: string | null | undefined): string {
  if (!iso) return "";
  const d = new Date(iso);
  if (Number.isNaN(d.getTime())) return "";
  return d.toLocaleDateString("ru-RU", { day: "2-digit", month: "2-digit", year: "numeric" });
}

export function isWithinDays(iso: string | null | undefined, days: number): boolean {
  if (!iso) return false;
  const time = new Date(iso).getTime();
  return !Number.isNaN(time) && Date.now() - time <= days * 24 * 60 * 60 * 1000;
}

/** CSS-переменные тона (--tone*) по приоритету — для карточек и превью. */
export function toneStyle(priority: number | undefined): CSSProperties {
  const meta = PRIORITY_META[normalizePriority(priority)];
  return {
    "--tone": meta.color,
    "--tone-soft": meta.soft,
    "--tone-dark": meta.dark,
  } as CSSProperties;
}

export function initialOf(name: string | null | undefined): string {
  return (name?.trim()?.[0] ?? "•").toUpperCase();
}
