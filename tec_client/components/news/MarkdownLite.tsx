import React from "react";
import styles from "@/components/styles/News.module.css";

/**
 * Мини-рендер разметки для новостей: **жирный**, *курсив*, [ссылка](url),
 * списки (- / 1.), заголовки (#, ##, ###), цитаты (>).
 * Возвращает React-элементы (без dangerouslySetInnerHTML) — XSS исключён,
 * ссылки пропускаются только http(s) и внутренние (/...).
 */

const INLINE_RE = /(\*\*[^*\n]+\*\*|\*[^*\n]+\*|\[[^\]\n]+\]\([^)\s]+\))/g;
const LINK_RE = /^\[([^\]]+)\]\(([^)\s]+)\)$/;

function safeHref(href: string): string | null {
  if (/^https?:\/\//i.test(href) || (href.startsWith("/") && !href.startsWith("//"))) return href;
  return null;
}

function renderInline(text: string, keyPrefix: string): React.ReactNode[] {
  return text.split(INLINE_RE).map((part, i) => {
    const key = `${keyPrefix}-${i}`;
    if (!part) return null;

    if (part.startsWith("**") && part.endsWith("**") && part.length > 4) {
      return <strong key={key}>{part.slice(2, -2)}</strong>;
    }
    if (part.startsWith("*") && part.endsWith("*") && part.length > 2) {
      return <em key={key}>{part.slice(1, -1)}</em>;
    }
    const link = LINK_RE.exec(part);
    if (link) {
      const href = safeHref(link[2]);
      if (href) {
        const external = /^https?:\/\//i.test(href);
        return (
          <a
            key={key}
            href={href}
            {...(external ? { target: "_blank", rel: "noopener noreferrer" } : {})}
          >
            {link[1]}
          </a>
        );
      }
      return link[1];
    }
    return part;
  });
}

type Block =
  | { type: "p"; lines: string[] }
  | { type: "h"; level: 2 | 3 | 4; text: string }
  | { type: "ul" | "ol"; items: string[] }
  | { type: "quote"; lines: string[] };

function parseBlocks(source: string): Block[] {
  const blocks: Block[] = [];
  const lines = source.replace(/\r\n/g, "\n").split("\n");
  let para: string[] = [];
  let list: { type: "ul" | "ol"; items: string[] } | null = null;
  let quote: string[] = [];

  const flush = () => {
    if (para.length) blocks.push({ type: "p", lines: para });
    if (list) blocks.push(list);
    if (quote.length) blocks.push({ type: "quote", lines: quote });
    para = [];
    list = null;
    quote = [];
  };

  for (const raw of lines) {
    const line = raw.trimEnd();
    if (!line.trim()) {
      flush();
      continue;
    }

    const heading = /^(#{1,3})\s+(.+)$/.exec(line);
    if (heading) {
      flush();
      blocks.push({ type: "h", level: (heading[1].length + 1) as 2 | 3 | 4, text: heading[2] });
      continue;
    }

    const ul = /^\s*[-*]\s+(.+)$/.exec(line);
    const ol = /^\s*\d+\.\s+(.+)$/.exec(line);
    if (ul || ol) {
      const type = ul ? "ul" : "ol";
      if (list && list.type !== type) flush();
      if (para.length || quote.length) flush();
      if (!list) list = { type, items: [] };
      list.items.push((ul ?? ol)![1]);
      continue;
    }

    const q = /^>\s?(.*)$/.exec(line);
    if (q) {
      if (para.length || list) flush();
      quote.push(q[1]);
      continue;
    }

    if (list || quote.length) flush();
    para.push(line);
  }
  flush();
  return blocks;
}

export default function MarkdownLite({ source, className }: { source: string; className?: string }) {
  const blocks = React.useMemo(() => parseBlocks(source ?? ""), [source]);

  return (
    <div className={`${styles.prose} ${className ?? ""}`}>
      {blocks.map((b, i) => {
        const key = `b${i}`;
        switch (b.type) {
          case "h": {
            const Tag = `h${b.level}` as "h2" | "h3" | "h4";
            return <Tag key={key}>{renderInline(b.text, key)}</Tag>;
          }
          case "ul":
          case "ol": {
            const Tag = b.type;
            return (
              <Tag key={key}>
                {b.items.map((it, j) => (
                  <li key={j}>{renderInline(it, `${key}-${j}`)}</li>
                ))}
              </Tag>
            );
          }
          case "quote":
            return (
              <blockquote key={key}>
                {b.lines.map((l, j) => (
                  <React.Fragment key={j}>
                    {j > 0 && <br />}
                    {renderInline(l, `${key}-${j}`)}
                  </React.Fragment>
                ))}
              </blockquote>
            );
          default:
            return (
              <p key={key}>
                {b.lines.map((l, j) => (
                  <React.Fragment key={j}>
                    {j > 0 && <br />}
                    {renderInline(l, `${key}-${j}`)}
                  </React.Fragment>
                ))}
              </p>
            );
        }
      })}
    </div>
  );
}
