FROM node:22-alpine AS base
WORKDIR /app

# Включаем pnpm через corepack
ENV PNPM_HOME="/pnpm"
ENV PATH="$PNPM_HOME:$PATH"
RUN corepack enable

# 1. Зависимости (убрали тяжелые пакеты python, make, g++, vips-dev)
FROM base AS deps
RUN apk add --no-cache libc6-compat

# Копируем конфиги зависимостей
COPY package.json pnpm-lock.yaml* ./

# Игнорируем запуск скриптов, чтобы обойти блокировку pnpm. 
# Готовые бинарники sharp скачиваются автоматически.
RUN pnpm install --frozen-lockfile --ignore-scripts

# 2. Сборка приложения
FROM base AS builder
COPY --from=deps /app/node_modules ./node_modules
COPY . .

ENV NEXT_TELEMETRY_DISABLED=1

# Передаем переменные для сборки: NEXT_PUBLIC_API_URL — в клиентский бандл,
# API_URL — читается в next.config.ts на этапе next build (rewrites()).
ARG NEXT_PUBLIC_API_URL
ENV NEXT_PUBLIC_API_URL=$NEXT_PUBLIC_API_URL

ARG API_URL
ENV API_URL=$API_URL

RUN pnpm run build

# 3. Прод образ (Runner)
FROM base AS runner
WORKDIR /app

ENV NODE_ENV=production
ENV NEXT_TELEMETRY_DISABLED=1

RUN addgroup --system --gid 1001 nodejs
RUN adduser --system --uid 1001 nextjs

# Копируем статику и standalone сборку Next.js
COPY --from=builder /app/public ./public
COPY --from=builder --chown=nextjs:nodejs /app/.next/standalone ./
COPY --from=builder --chown=nextjs:nodejs /app/.next/static ./.next/static

USER nextjs

EXPOSE 3000

ENV PORT=3000
ENV HOSTNAME="0.0.0.0"

CMD ["node", "server.js"]