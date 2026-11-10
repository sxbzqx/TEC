"use client";

import Link from "next/link";
import { ArrowRight, CalendarDays, Zap } from "lucide-react";
import { useAuth } from "@/hooks/useAuth";
import { useLocale } from "@/context/LocaleContext";
import { useQuickLinks } from "@/components/main/quickLinks";
import { Card } from "@/components/ui/card";

function greetingKey(hour: number) {
  if (hour >= 5 && hour < 12) return "dashGreetMorning" as const;
  if (hour >= 12 && hour < 18) return "dashGreetDay" as const;
  if (hour >= 18 && hour < 23) return "dashGreetEvening" as const;
  return "dashGreetNight" as const;
}

export default function GreetingCard() {
  const { t, locale } = useLocale();
  const { auth } = useAuth();
  const quickLinks = useQuickLinks();

  const now = new Date();
  const today = now.toLocaleDateString(locale === "kg" ? "ky-KG" : "ru-RU", {
    weekday: "long",
    day: "numeric",
    month: "long",
  });
  // ФИО из кадровой записи; если пользователь не привязан к сотруднику — логин.
  const name = auth.fio?.trim() || auth.loginName;

  return (
    <Card className="relative gap-5 overflow-hidden border-0 bg-linear-to-br from-header to-primary px-6 py-6 text-white shadow-md sm:px-8 sm:py-7">
      <div className="flex flex-wrap items-start justify-between gap-3">
        <span className="inline-flex items-center gap-1.5 rounded-full bg-white/15 px-3 py-1 text-[11px] font-semibold tracking-wider text-white uppercase">
          <Zap className="size-3" />
          МП Бишкек ТЭЦ
        </span>
        <span className="inline-flex items-center gap-1.5 text-[13px] font-medium text-white/80 capitalize">
          <CalendarDays className="size-4" />
          {today}
        </span>
      </div>

      <div className="flex flex-col gap-1.5">
        <h1 className="text-2xl leading-tight font-bold tracking-tight text-white sm:text-3xl">
          {t(greetingKey(now.getHours()))}
          {name ? `, ${name}` : ""}
        </h1>
        <p className="text-sm text-white/70">{t("dashGreetingSub")}</p>
      </div>

      <div className="flex flex-wrap gap-2">
        {quickLinks.map((link) => (
          <Link
            key={link.href}
            href={link.href}
            className="group inline-flex items-center gap-2 rounded-lg bg-white/10 px-3 py-1.5 text-[13px] font-medium transition-colors hover:bg-white/20"
          >
            <span className="inline-flex text-white [&_svg]:size-3.5">{link.icon}</span>
            <span className="text-white">{link.title}</span>
            <ArrowRight className="size-3.5 text-white/60 transition-transform group-hover:translate-x-0.5" />
          </Link>
        ))}
      </div>
    </Card>
  );
}