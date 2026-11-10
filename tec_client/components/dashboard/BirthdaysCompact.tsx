"use client";

import { useQuery } from "@tanstack/react-query";
import { Cake } from "lucide-react";
import { fetchUpcomingBirthdays } from "@/services/workerService";
import { useLocale } from "@/context/LocaleContext";
import type { Worker } from "@/types/worker";
import { Badge } from "@/components/ui/badge";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Skeleton } from "@/components/ui/skeleton";

function isSameDayMonth(a: Date, b: Date) {
  return a.getDate() === b.getDate() && a.getMonth() === b.getMonth();
}

function initialOf(fio: string | null | undefined) {
  return (fio?.trim()?.[0] ?? "•").toUpperCase();
}

export default function BirthdaysCompact() {
  const { t, locale } = useLocale();

  const { data = [], isLoading } = useQuery({
    queryKey: ["birthdays", "upcoming"],
    queryFn: fetchUpcomingBirthdays,
    staleTime: 5 * 60_000,
  });

  const now = new Date();
  const rows = data
    .map((w: Worker) => {
      const dr = new Date(w.dr);
      return { worker: w, dr, isToday: isSameDayMonth(dr, now) };
    })
    // Сегодняшние — первыми, дальше по алфавиту
    .sort((a, b) => Number(b.isToday) - Number(a.isToday) || a.worker.fio.localeCompare(b.worker.fio, "ru"));

  const dateFmt = new Intl.DateTimeFormat(locale === "kg" ? "ky-KG" : "ru-RU", {
    day: "numeric",
    month: "long",
  });

  return (
    <Card className="gap-3">
      <CardHeader>
        <div className="flex flex-col gap-1.5">
          <CardTitle>
            <Cake className="size-4 text-primary" />
            {t("dashBirthdaysTitle")}
          </CardTitle>
          <CardDescription className="text-xs">{t("dashBirthdaysSub")}</CardDescription>
        </div>
        {!isLoading && rows.length > 0 && <Badge variant="soft">{rows.length}</Badge>}
      </CardHeader>

      <CardContent>
        {isLoading ? (
          <div className="flex flex-col gap-2">
            <Skeleton className="h-9 w-full" />
            <Skeleton className="h-9 w-full" />
          </div>
        ) : rows.length === 0 ? (
          <p className="py-2 text-sm text-muted-foreground">{t("birthdayTableEmpty")}</p>
        ) : (
          <ul className="flex max-h-64 flex-col overflow-y-auto">
            {rows.map(({ worker, dr, isToday }) => (
              <li
                key={worker.id}
                className="flex items-center gap-3 border-b border-border/60 py-2 last:border-b-0"
              >
                <span
                  className={
                    "flex size-8 shrink-0 items-center justify-center rounded-full text-xs font-semibold " +
                    (isToday ? "bg-warning-soft text-warning-dark" : "bg-accent text-accent-foreground")
                  }
                >
                  {initialOf(worker.fio)}
                </span>
                <div className="min-w-0 flex-1">
                  <div className="truncate text-[13px] leading-tight font-semibold text-foreground" title={worker.fio}>
                    {worker.fio}
                  </div>
                  <div className="truncate text-xs text-muted-foreground" title={worker.doljnost}>
                    {worker.doljnost}
                  </div>
                </div>
                <div className="flex shrink-0 flex-col items-end gap-0.5">
                  <Badge variant={isToday ? "warning" : "secondary"} className="px-1.5 text-[10px]">
                    {isToday ? t("tagToday") : t("tagTomorrow")}
                  </Badge>
                  <span className="text-[11px] text-muted-foreground">{dateFmt.format(dr)}</span>
                </div>
              </li>
            ))}
          </ul>
        )}
      </CardContent>
    </Card>
  );
}