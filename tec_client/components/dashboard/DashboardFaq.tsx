"use client";

import Link from "next/link";
import { ArrowRight, CircleHelp } from "lucide-react";
import { useLocale } from "@/context/LocaleContext";
import type { TranslationKey } from "@/locales/ru";
import { Accordion, AccordionContent, AccordionItem, AccordionTrigger } from "@/components/ui/accordion";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";

const FAQ: {
  id: string;
  q: TranslationKey;
  a: TranslationKey;
  link: TranslationKey;
  href: string;
}[] = [
  { id: "news", q: "dashFaqQ1", a: "dashFaqA1", link: "dashFaqLink1", href: "/news" },
  { id: "bids", q: "dashFaqQ2", a: "dashFaqA2", link: "dashFaqLink2", href: "/bids/create" },
  { id: "suggestions", q: "dashFaqQ3", a: "dashFaqA3", link: "dashFaqLink3", href: "/suggestions" },
  { id: "profile", q: "dashFaqQ4", a: "dashFaqA4", link: "dashFaqLink4", href: "/profile" },
];

export default function DashboardFaq() {
  const { t } = useLocale();

  return (
    <Card className="gap-2">
      <CardHeader>
        <CardTitle>
          <CircleHelp className="size-4 text-primary" />
          {t("sectionFAQ")}
        </CardTitle>
      </CardHeader>
      <CardContent>
        <Accordion type="single" collapsible>
          {FAQ.map((item) => (
            <AccordionItem key={item.id} value={item.id}>
              <AccordionTrigger>{t(item.q)}</AccordionTrigger>
              <AccordionContent>
                <p className="leading-relaxed">{t(item.a)}</p>
                <Button asChild variant="link" size="sm" className="mt-1 h-auto px-0">
                  <Link href={item.href}>
                    {t(item.link)}
                    <ArrowRight />
                  </Link>
                </Button>
              </AccordionContent>
            </AccordionItem>
          ))}
        </Accordion>
      </CardContent>
    </Card>
  );
}