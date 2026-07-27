# Changelog

Все заметные изменения в этом проекте документируются в этом файле.

![C#](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![EF](https://img.shields.io/badge/Entity_Framework-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
<a href="http://localhost:5281/swagger/index.html"> ![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=Swagger&logoColor=white) </a>

## [1.0.0] - 2026-05-20

### Added

- **База данных:** Настроено подключение к СУБД MySQL (v5.7), создана строка подключения и инициализирован контекст данных (`SiteContext`).
- **Контроллеры:** Реализованы базовые эндпоинты:
  - `WorkersController` (Сотрудники)
  - `OtdelsController` (Отделы)
  - `StatisticController` (Статистика)
- **Документация:** Добавлены XML-комментарии к методам контроллеров для автоматической генерации Swagger-документации.

### Security

- **Авторизация:** Реализована полноценная система аутентификации (выдача токенов по адресу `api/auth`).
- **Защита API:** Настроено ограничение доступа к методам `tecBackend` с помощью атрибута `[Authorize]`.

## [1.0.1] - 2026-05-28

### Added

- **Контроллеры:** Реализован функционал чата (`Chat` с интеграцией в БД):
  - Добавлены методы `GET` (чтение) и `POST` (отправка сообщений).

### Fixed

- **Auth:** Исправлена строка подключения (Connection String) к базе данных в сервисе авторизации.

## [1.0.2] - 2026-05-29

### Added

- **Контроллеры:**
  - `BiznesplanController` — реализация бизнес-планов (Основной вариант и Вариант Оксаны).
  - `DocumentController` — работа с документами заявок за период `2017 – 2026` гг.

## [1.0.3] - 2026-06-01

### Fixed

- **База данных:** Миграция СУБД с виртуальной машины (VMware) на основной хост. Строка подключения (`ConnectionString`) переведена на локальный адрес (`127.0.0.1`).

### Deleted

- Устаревший сервис авторизации (Auth-сервис).

### Planned : completed

- Разработка и интеграция новой системы авторизации.

## [1.0.4] - 2026-06-03

### Added

- **Новый Auth-сервис**:
  - **DTOs**:
    - `LoginRequest` - Вход
    - `RegisterRequest` - Регистрация
    - `RefreshRequest` - Рефреш JWT access-токена
    - `LogOutRequest` - Инвалидация access-токена
    - `TokenRequest` - Токен JWT
    - `TokenResponse` - Запрос Токена

  - **Controllers**:
    - `AuthController`:
      - `api/auth/register` - Регистрация (email, login, password)
      - `api/auth/login` - Вход (login, password)
      - `api/auth/refresh` - Рефреш JWT
      - `api/auth/logout` - Выход
      - `api/auth/me` - Информация о пользователе (Логин, Роль)

## [1.1.0] - 2026-06-10

### Added

- **Роли**:
  - `Guest` - Гость (Не зарегистрированный пользователь)
  - `Worker` - Работник (Зарегистрированный пользователь)
  - `Admin` - Администратор
  - `SuperAdmin`

- **Admin-панель**:
  - **DTOs**:
    - `PostRequest` - Посты (Новости)
    - `UpdateRoleRequest` - Обновление роли

  - **Controllers**:
    - `AdminController`:
      - `api/admin/users` - [GET] Получение всех пользователей
      - `api/admin/users/{id}/role` - [PUT] Изменение роли Пользователя
      - `api/admin/posts` - [GET] - Просмотр всех постов (Новостей)
      - `api/admin/posts` - [POST] - Создание постов (Новостей)
      - `api/admin/posts/{id}` - [GET] - Просмотр определенного поста
      - `api/admin/posts/{id}` - [PUT] - Изменение определенного поста
      - `api/admin/posts/{id}` - [DELETE] - Удаление определенного поста
      - `api/admin/posts/public` - [GET] - Просмотр всех постов (Для Гостя(Guest) и Работника(Worker))

## [1.1.1] - 2026-06-15

### Added

- **Разделение по категориям новостей**:
  - `api/categories` - Получение всех категорий
  


### Planned : completed

- **Улучшить/Автоматизировать регистрацию пользователей**:
  - Добавить: 
    - Выбор отдела в котором работает сотрудник
    - Должность

## [1.1.2] - 2026-06-17

### Planned

- Возможность редактирование профиля:
  - Логин, пароль
  - Выборка Отдела и Должности
  - ФИО

- Предложения по улучшению сайта 

- Заявки
  - Создание
  - Просмотр всех
  - Просмотр одного
  - Редактирование
  - Удаление
  - Мониторинг (Админам)
  

