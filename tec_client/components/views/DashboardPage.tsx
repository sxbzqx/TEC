"use client";

import BirthdaysCompact from "@/components/dashboard/BirthdaysCompact";
import DashboardFaq from "@/components/dashboard/DashboardFaq";
import GreetingCard from "@/components/dashboard/GreetingCard";
import NewsFeed from "@/components/dashboard/NewsFeed";

export default function DashboardPage() {
  return (
    <div className="tw-root mx-auto flex w-full max-w-[1320px] flex-col gap-4 px-4 pt-6 pb-16 sm:px-6 lg:px-10">
      {/* 1. Приветствие */}
      <GreetingCard />

      <div className="grid items-start gap-4 lg:grid-cols-[minmax(0,1fr)_340px]">
        {/* 4. Новости — на всю вертикаль, по 20 на страницу */}
        <NewsFeed />

        {/* 3. Компактные именинники + 7. FAQ для дашборда */}
        <aside className="flex flex-col gap-4 lg:sticky lg:top-4">
          <BirthdaysCompact />
          <DashboardFaq />
        </aside>
      </div>
    </div>
  );
}