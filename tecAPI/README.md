# tecAPI

Бэкенд внутреннего корпоративного портала МП «Бишкек ТЭЦ».

<p>
  <img src="https://img.shields.io/badge/.NET%2010-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt=".NET 10" />
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white" alt="C#" />
  <img src="https://img.shields.io/badge/Entity%20Framework%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" alt="EF Core" />
  <img src="https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white" alt="MySQL" />
  <img src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white" alt="JWT" />
  <img src="https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black" alt="Swagger" />
</p>

## Стек

- **.NET 10 / ASP.NET Core Web API**
- **Entity Framework Core** + **MySql.EntityFrameworkCore** (Pomelo-совместимый провайдер)
- **JWT Bearer** (`Microsoft.AspNetCore.Authentication.JwtBearer`) — access-токен с ролевыми claim'ами
- **BCrypt.Net-Next** — хэширование паролей (с фолбэком на старые plain-text записи на время миграции)
- **Swashbuckle / Swagger UI** — доступен в Development на `/swagger`
- **DotNetEnv** — конфигурация через `.env`

## Быстрый старт

1. Скопируй `.env.example` → `.env` и заполни:

   ```env
   ConnectionStrings__DefaultConnection=Server=localhost;Database=tec;User=root;Password=***;
   AppSettings__Token=<случайная строка длиной от 32 символов>
   ```

2. Накати миграции / убедись, что база `tec` создана и накатан дамп (`site.sql` в корне — легаси-структура).

3. Запусти:

   ```bash
   dotnet restore
   dotnet run --project tecBackend
   ```

API поднимется на порту из `Properties/launchSettings.json`, Swagger — на `/swagger`.

CORS разрешён для `http://localhost:3000` и `http://10.0.4.37:3000` (см. `Program.cs`, политика `AllowNextJS`).

## Аутентификация

- `POST /api/auth/register` — регистрация
- `POST /api/auth/login` — логин, access-токен в теле, refresh — в httpOnly cookie
- `POST /api/auth/refresh` — обновление access-токена по refresh-cookie
- `POST /api/auth/logout` — инвалидация сессии
- `POST /api/auth/change-password`, `POST /api/auth/change-login` — смена данных профиля
- `GET /api/auth/me` — текущий пользователь
- `GET /api/auth/otdels` — справочник отделов для формы регистрации

Роли (`ClaimTypes.Role`): `Worker`, `Admin`, `SuperAdmin`. Часть эндпоинтов защищена `[Authorize(Roles = "...")]`.

## Основные разделы API

| Контроллер | Назначение |
| --- | --- |
| `AuthController` | регистрация, логин, сессии, смена логина/пароля |
| `DocumentsController` | заявки: создание, входящие, решение (разрешить/отклонить/отложить), выполнение, архив по месяцам |
| `ResourcesController` | справочник ресурсов (видов заявок) |
| `OtdelsController` | справочник отделов |
| `WorkersController` | сотрудники, дни рождения |
| `AdminController` | управление пользователями/ролями, новости (посты) |
| `BiznesplanController` | бизнес-план / ОК |
| `CategoriesController` | категории |
| `ActivityController` | лента активности для дашборда |
| `StatisticController` | статистика |
| `ChatController` | чат |
| `TimeController` | текущее серверное время |

Полный список маршрутов и схем — в Swagger UI.

## Особенности легаси-схемы БД

- Архив заявок хранится помесячно в отдельных таблицах `documents{yyyyMM}` (см. `DocumentsController.GetDocumentByMonth`) — исторический артефакт, новые заявки пишутся в общую таблицу `documents`.
- `resources.id_otd` — код отдела-исполнителя как строка; сверяется с `otdel.id_otd`, а не с первичным ключом `otdel.id`. Не все исторические коды валидны — см. `fix_resources_id_otd.sql` в корне репозитория для примера миграции при обнаружении оторванных ссылок.
- Времена, показываемые пользователю (даты заявок, новостей, ленты активности), пишутся через `Utils/BishkekClock` — фиксированный UTC+6 (Кыргызстан не переходит на летнее время), а не `DateTime.UtcNow`, чтобы не путать сериализацию с реальным часовым поясом.
