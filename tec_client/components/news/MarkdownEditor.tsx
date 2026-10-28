"use client";

import React, { useRef } from "react";
import { Tooltip } from "antd";
import {
  BoldOutlined,
  ItalicOutlined,
  LinkOutlined,
  UnorderedListOutlined,
  FontSizeOutlined,
  MessageOutlined,
} from "@ant-design/icons";
import { useLocale } from "@/context/LocaleContext";
import styles from "@/components/styles/News.module.css";

type Action = "bold" | "italic" | "heading" | "list" | "quote" | "link";

interface Props {
  value?: string;
  onChange?: (value: string) => void;
  placeholder?: string;
  minHeight?: number;
}

/** Форматирование выделенного текста / текущих строк. */
function transform(
  value: string,
  start: number,
  end: number,
  action: Action,
): { text: string; selStart: number; selEnd: number } {
  const selected = value.slice(start, end);

  const wrap = (mark: string, fallback: string) => {
    const inner = selected || fallback;
    const text = value.slice(0, start) + mark + inner + mark + value.slice(end);
    return { text, selStart: start + mark.length, selEnd: start + mark.length + inner.length };
  };

  if (action === "bold") return wrap("**", "жирный");
  if (action === "italic") return wrap("*", "курсив");

  if (action === "link") {
    const label = selected || "текст ссылки";
    const insert = `[${label}](https://)`;
    const text = value.slice(0, start) + insert + value.slice(end);
    const urlStart = start + label.length + 3;
    return { text, selStart: urlStart, selEnd: urlStart + "https://".length };
  }

  // построчные действия
  const lineStart = value.lastIndexOf("\n", start - 1) + 1;
  const nl = value.indexOf("\n", end);
  const lineEnd = nl === -1 ? value.length : nl;
  const block = value.slice(lineStart, lineEnd);
  const lines = block.split("\n");

  let out: string[];
  if (action === "heading") {
    out = lines.map((l) => (/^#{1,3}\s/.test(l) ? l.replace(/^#{1,3}\s/, "") : `## ${l}`));
  } else if (action === "quote") {
    out = lines.map((l) => (l.startsWith("> ") ? l.slice(2) : `> ${l}`));
  } else {
    out = lines.map((l) => (/^\s*[-*]\s/.test(l) ? l.replace(/^\s*[-*]\s/, "") : `- ${l}`));
  }
  const replaced = out.join("\n");
  return {
    text: value.slice(0, lineStart) + replaced + value.slice(lineEnd),
    selStart: lineStart,
    selEnd: lineStart + replaced.length,
  };
}

export default function MarkdownEditor({ value = "", onChange, placeholder, minHeight = 340 }: Props) {
  const { t } = useLocale();
  const ref = useRef<HTMLTextAreaElement>(null);

  const apply = (action: Action) => {
    const el = ref.current;
    if (!el) return;
    const { text, selStart, selEnd } = transform(value, el.selectionStart, el.selectionEnd, action);
    onChange?.(text);
    requestAnimationFrame(() => {
      el.focus();
      el.setSelectionRange(selStart, selEnd);
    });
  };

  const onKeyDown = (e: React.KeyboardEvent<HTMLTextAreaElement>) => {
    if ((e.ctrlKey || e.metaKey) && !e.shiftKey) {
      const k = e.key.toLowerCase();
      if (k === "b") {
        e.preventDefault();
        apply("bold");
      } else if (k === "i") {
        e.preventDefault();
        apply("italic");
      } else if (k === "k") {
        e.preventDefault();
        apply("link");
      }
    }
  };

  const tools: { action: Action; icon: React.ReactNode; label: string }[] = [
    { action: "bold", icon: <BoldOutlined />, label: `${t("edToolbarBold")} (Ctrl+B)` },
    { action: "italic", icon: <ItalicOutlined />, label: `${t("edToolbarItalic")} (Ctrl+I)` },
    { action: "heading", icon: <FontSizeOutlined />, label: t("edToolbarHeading") },
    { action: "list", icon: <UnorderedListOutlined />, label: t("edToolbarList") },
    { action: "quote", icon: <MessageOutlined />, label: t("edToolbarQuote") },
    { action: "link", icon: <LinkOutlined />, label: `${t("edToolbarLink")} (Ctrl+K)` },
  ];

  return (
    <div className={styles.editorBox}>
      <div className={styles.editorToolbar}>
        {tools.map((tool) => (
          <Tooltip key={tool.action} title={tool.label} mouseEnterDelay={0.4}>
            <button
              type="button"
              className={styles.toolBtn}
              onMouseDown={(e) => e.preventDefault()}
              onClick={() => apply(tool.action)}
              aria-label={tool.label}
            >
              {tool.icon}
            </button>
          </Tooltip>
        ))}
        <span className={styles.editorCounter}>
          {value.length} {t("edChars")}
        </span>
      </div>
      <textarea
        ref={ref}
        className={styles.editorTextarea}
        style={{ minHeight }}
        value={value}
        placeholder={placeholder}
        onChange={(e) => onChange?.(e.target.value)}
        onKeyDown={onKeyDown}
      />
    </div>
  );
}
