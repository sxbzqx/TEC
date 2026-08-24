# tecFrontend

Внутренний корпоративный портал МП «Бишкек ТЭЦ» — фронтенд-часть.

<p>
  <img src="https://img.shields.io/badge/TypeScript-3178C6?style=for-the-badge&logo=typescript&logoColor=white" alt="TypeScript" />
  <img src="https://img.shields.io/badge/Next.js-000000?style=for-the-badge&logo=next.js&logoColor=white" alt="Next.js" />
  <img src="https://img.shields.io/badge/-AntDesign-%230170FE.svg?style=for-the-badge&logo=ant-design&logoColor=white" />
  <img src="https://img.shields.io/badge/TanStack%20Query-FF4154?style=for-the-badge&logo=reactquery&logoColor=white" alt="TanStack Query" />
  <img src="https://img.shields.io/badge/axios-671ddf?style=for-the-badge&logo=axios&logoColor=white" alt="Axios" />
  <img src="https://img.shields.io/badge/pnpm-F69220?style=for-the-badge&logo=pnpm&logoColor=white" alt="pnpm" />
  <img src="https://img.shields.io/badge/ESLint-4B32C3?style=for-the-badge&logo=eslint&logoColor=white" alt="ESLint" />
</p>

## Стек

- **Next.js 16** (App Router) + **React 19** + **TypeScript**
- **Ant Design v6** — UI-кит, `ConfigProvider` с фирменным цветом `#534AB7`
- **TanStack Query** — серверный стейт, кэш, инвалидация
- **Axios** — HTTP-клиент с interceptor'ом автообновления JWT по httpOnly refresh-токену
<<<<<<< ours
=======
- **Tailwind CSS** — точечные утилиты поверх antd
>>>>>>> theirs
- **js-cookie**, **Leaflet / react-leaflet** — карта на `/map`

## Возможности

- Аутентификация: httpOnly access/refresh cookies, Route Handlers (`/api/auth/*`), ролевой middleware (`Admin`, `SuperAdmin`, `Worker`)
- Тёмная/светлая тема и переключение локали RU/KG (`ThemeContext`, `LocaleContext`), сохранение в cookie
- Дашборд с виджетами: дни рождения, активность, уведомления, FAQ
- Раздел «Заявки» (`/bids`): создание, входящие с постраничным решением (разрешить / отклонить / отложить / выполнено), архив по месяцам
- Профиль пользователя, смена логина/пароля
- Разделы «Отделы», «Бизнес-план», «Предложения», «Сотрудники», карта, новости

## Быстрый старт

```bash
pnpm install
pnpm dev
```

Приложение поднимется на [localhost:3000](http://localhost:3000).

### Переменные окружения

Создай `.env.local` в корне:

```env
NEXT_PUBLIC_API_URL=http://localhost:5000/api
```

### Скрипты

<<<<<<< ours
| Команда      | Описание                   |
| ------------ | -------------------------- |
| `pnpm dev`   | Запуск в режиме разработки |
| `pnpm build` | Продакшн-сборка            |
| `pnpm start` | Запуск продакшн-сборки     |
| `pnpm lint`  | Проверка ESLint            |

## Структура

```
app/
  (auth)/        — логин, регистрация, профиль
  (dashboard)/   — заявки, отделы, бизнес-план, сотрудники, предложения
  (admin)/       — админ-панель
  (public)/      — карта, новости, навигация
  api/           — Route Handlers (auth)
components/      — переиспользуемые UI-компоненты
context/         — ThemeContext, LocaleContext, AuthContext
hooks/           — React Query хуки
services/        — HTTP-сервисы ($api-обёртки)
types/           — TypeScript-типы
locales/         — ru.ts / kg.ts словари переводов
utils/           — apiError, jwt, config и др.
=======
| Команда       | Описание                                  |
| ------------- | ------------------------------------------ |
| `pnpm dev`    | Запуск в режиме разработки                |
| `pnpm build`  | Продакшн-сборка                           |
| `pnpm start`  | Запуск продакшн-сборки                    |
| `pnpm lint`   | Проверка ESLint                           |

## Структура

>>>>>>> theirs
```
app/
  (auth)/        — логин, регистрация, профиль
  (dashboard)/   — заявки, отделы, бизнес-план, сотрудники, предложения
  (admin)/       — админ-панель
  (public)/      — карта, новости, навигация
  api/           — Route Handlers (auth)
components/      — переиспользуемые UI-компоненты
context/         — ThemeContext, LocaleContext, AuthContext
hooks/           — React Query хуки
services/        — HTTP-сервисы ($api-обёртки)
types/           — TypeScript-типы
locales/         — ru.ts / kg.ts словари переводов
utils/           — apiError, jwt, config и др.
```

## Бэкенд

<<<<<<< ours
=======
API: [tecAPI](https://github.com/sxbzqx/tecAPI) — ASP.NET Core / .NET 10.
>>>>>>> theirs
