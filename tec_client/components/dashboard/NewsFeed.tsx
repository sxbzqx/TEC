"use client";

import { useMemo, useRef, useState } from "react";
import Link from "next/link";
import { useQuery } from "@tanstack/react-query";
import { ArrowRight, ChevronLeft, ChevronRight, Newspaper, Pin, Plus } from "lucide-react";
import { fetchPublicPosts, newsKeys } from "@/services/newsService";
import { useAuth } from "@/hooks/useAuth";
import { useLocale } from "@/context/LocaleContext";
import type { Post } from "@/types/post";
import {
  PRIORITY_META,
  formatNewsDate,
  getExcerpt,
  initialOf,
  normalizePriority,
  readingMinutes,
} from "@/utils/news";
import { cn } from "@/lib/utils";
import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Skeleton } from "@/components/ui/skeleton";

const PAGE_SIZE = 20;

/** Закреплённые на главной — выше (внутри — по важности), остальные — свежие сверху. */
function compareNews(a: Post, b: Post) {
  const pin = Number(b.showOnMain) - Number(a.showOnMain);
  if (pin !== 0) return pin;
  if (a.showOnMain && b.showOnMain) {
    const prio = normalizePriority(b.priority) - normalizePriority(a.priority);
    if (prio !== 0) return prio;
  }
  return new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime();
}

/** 1 … 4 5 [6] 7 8 … 20 */
function getPageItems(current: number, total: number): (number | "gap")[] {
  if (total <= 7) return Array.from({ length: total }, (_, i) => i + 1);
  const items: (number | "gap")[] = [1];
  const from = Math.max(2, current - 1);
  const to = Math.min(total - 1, current + 1);
  if (from > 2) items.push("gap");
  for (let p = from; p <= to; p++) items.push(p);
  if (to < total - 1) items.push("gap");
  items.push(total);
  return items;
}

function NewsRow({ post }: { post: Post }) {
  const { t } = useLocale();
  const priority = normalizePriority(post.priority);
  const meta = PRIORITY_META[priority];

  return (
    <li className="border-b border-border/60 last:border-b-0">
      <Link
        href={`/news/${post.id}`}
        className="group relative flex items-start gap-4 px-5 py-4 transition-colors hover:bg-accent/40"
      >
        <span
          aria-hidden
          className="absolute top-3 bottom-3 left-0 w-[3px] rounded-r-full"
          style={{ background: priority > 0 ? meta.color : "transparent" }}
        />

        <div className="flex min-w-0 flex-1 flex-col gap-1.5">
          <div className="flex flex-wrap items-center gap-1.5">
            {post.showOnMain && (
              <Badge variant="soft">
                <Pin />
                {t("newsFeaturedLabel")}
              </Badge>
            )}
            {priority === 1 && <Badge variant="warning">{t(meta.labelKey)}</Badge>}
            {priority === 2 && <Badge variant="destructive">{t(meta.labelKey)}</Badge>}
            {post.category?.name && <Badge variant="outline">{post.category.name}</Badge>}
          </div>

          <h3 className="text-[15px] leading-snug font-semibold text-foreground transition-colors group-hover:text-primary">
            {post.title}
          </h3>

          <p className="line-clamp-2 text-[13px] leading-relaxed text-muted-foreground">
            {getExcerpt(post, 200)}
          </p>

          <div className="mt-0.5 flex flex-wrap items-center gap-x-2 gap-y-1 text-xs text-muted-foreground">
            <span className="flex size-5 items-center justify-center rounded-full bg-accent text-[10px] font-semibold text-accent-foreground">
              {initialOf(post.creatorName)}
            </span>
            <span>{post.creatorName}</span>
            <span aria-hidden>·</span>
            <span>{formatNewsDate(post.createdAt, false)}</span>
            <span aria-hidden>·</span>
            <span>
              {readingMinutes(post.content)} {t("newsMinRead")}
            </span>
          </div>
        </div>

        <ArrowRight className="mt-1 size-4 shrink-0 text-muted-foreground opacity-0 transition-all group-hover:translate-x-0.5 group-hover:text-primary group-hover:opacity-100" />
      </Link>
    </li>
  );
}

function Pagination({
  page,
  totalPages,
  onChange,
}: {
  page: number;
  totalPages: number;
  onChange: (page: number) => void;
}) {
  const { t } = useLocale();

  return (
    <nav
      aria-label="pagination"
      className="flex flex-wrap items-center justify-between gap-3 border-t border-border px-5 pt-4"
    >
      <span className="text-xs text-muted-foreground">
        {t("dashPageLabel")} {page} {t("dashPageOf")} {totalPages}
      </span>

      <div className="flex items-center gap-1">
        <Button
          variant="outline"
          size="sm"
          disabled={page <= 1}
          onClick={() => onChange(page - 1)}
        >
          <ChevronLeft />
          <span className="hidden sm:inline">{t("dashPrev")}</span>
        </Button>

        {getPageItems(page, totalPages).map((item, i) =>
          item === "gap" ? (
            <span key={`gap-${i}`} className="px-1 text-sm text-muted-foreground select-none">
              …
            </span>
          ) : (
            <Button
              key={item}
              variant={item === page ? "default" : "ghost"}
              size="icon-sm"
              aria-current={item === page ? "page" : undefined}
              className={cn("text-[13px]", item !== page && "text-muted-foreground")}
              onClick={() => onChange(item)}
            >
              {item}
            </Button>
          ),
        )}

        <Button
          variant="outline"
          size="sm"
          disabled={page >= totalPages}
          onClick={() => onChange(page + 1)}
        >
          <span className="hidden sm:inline">{t("dashNext")}</span>
          <ChevronRight />
        </Button>
      </div>
    </nav>
  );
}

export default function NewsFeed() {
  const { t } = useLocale();
  const { auth } = useAuth();
  const isAdmin = auth.role === "Admin" || auth.role === "SuperAdmin";

  const [page, setPage] = useState(1);
  const topRef = useRef<HTMLDivElement>(null);

  const { data = [], isLoading, isError } = useQuery({
    queryKey: newsKeys.public,
    queryFn: fetchPublicPosts,
    staleTime: 60_000,
  });

  const sorted = useMemo(() => [...data].sort(compareNews), [data]);
  const totalPages = Math.max(1, Math.ceil(sorted.length / PAGE_SIZE));
  const currentPage = Math.min(page, totalPages);
  const pageItems = sorted.slice((currentPage - 1) * PAGE_SIZE, currentPage * PAGE_SIZE);

  const changePage = (next: number) => {
    setPage(next);
    topRef.current?.scrollIntoView({ behavior: "smooth", block: "start" });
  };

  return (
    <Card ref={topRef} className="scroll-mt-4 gap-0 overflow-hidden pb-5">
      <CardHeader className="pb-4">
        <CardTitle className="text-lg">
          <Newspaper className="size-5 text-primary" />
          {t("dashFeedTitle")}
          {sorted.length > 0 && <Badge variant="soft">{sorted.length}</Badge>}
        </CardTitle>
        <Button asChild variant="link" size="sm">
          <Link href="/news">
            {t("dashNewsAll")}
            <ArrowRight />
          </Link>
        </Button>
      </CardHeader>

      <CardContent className="border-t border-border px-0">
        {isLoading && (
          <div className="flex flex-col gap-5 px-5 py-5">
            {Array.from({ length: 4 }, (_, i) => (
              <div key={i} className="flex flex-col gap-2">
                <Skeleton className="h-4 w-24" />
                <Skeleton className="h-5 w-3/4" />
                <Skeleton className="h-4 w-full" />
              </div>
            ))}
          </div>
        )}

        {isError && (
          <p className="px-5 py-8 text-center text-sm text-muted-foreground">{t("newsLoadError")}</p>
        )}

        {!isLoading && !isError && sorted.length === 0 && (
          <div className="flex flex-col items-center gap-3 px-5 py-10 text-sm text-muted-foreground">
            <span>{t("dashNewsEmpty")}</span>
            {isAdmin && (
              <Button asChild variant="outline" size="sm">
                <Link href="/admin/news">
                  <Plus />
                  {t("dashNewsAdd")}
                </Link>
              </Button>
            )}
          </div>
        )}

        {pageItems.length > 0 && (
          <ul>
            {pageItems.map((post) => (
              <NewsRow key={post.id} post={post} />
            ))}
          </ul>
        )}
      </CardContent>

      {totalPages > 1 && (
        <Pagination page={currentPage} totalPages={totalPages} onChange={changePage} />
      )}
    </Card>
  );
}