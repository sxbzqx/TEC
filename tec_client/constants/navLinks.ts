import { DOC_FILES } from "./documents";

export const NAV_LINKS = [
  {
    key: "/",
    label: "Главная",
    labelKg: "Башкы бет",
    roles: ["Guest", "Worker", "Admin", "SuperAdmin", "User"],
  },
  {
    key: "/news",
    label: "Новости",
    labelKg: "Жаңылыктар",
    roles: ["Guest", "Worker", "Admin", "SuperAdmin", "User"],
  },
  {
    key: "/navigation",
    label: "Навигация",
    labelKg: "Багыттоо",
    roles: ["Guest", "Worker", "Admin", "SuperAdmin"],
  },
  {
    key: "admin-sub",
    label: "Администрирование",
    labelKg: "Башкаруу",
    roles: ["SuperAdmin", "Admin"],
    children: [
      {
        key: "/admin/users",
        label: "Управление ролями",
        labelKg: "Ролдорду башкаруу",
        roles: ["SuperAdmin"],
      },
      {
        key: "/admin/news",
        label: "Управление новостями",
        labelKg: "Жаңылыктарды башкаруу",
        roles: ["SuperAdmin", "Admin"],
      },
      {
        key: "/admin/activity-log",
        label: "Журнал действий",
        labelKg: "Аракеттер журналы",
        roles: ["SuperAdmin"],
      },
    ],
  },
  {
    key: "workers",
    label: "Сотрудники",
    labelKg: "Кызматкерлер",
    roles: ["SuperAdmin", "Admin", "Worker"],
    children: [
      {
        key: "/otdels",
        label: "Отделы",
        labelKg: "Бөлүмдөр",
        roles: ["SuperAdmin", "Admin", "Worker"],
      },
      {
        key: "/workers",
        label: "Список сотрудников",
        labelKg: "Кызматкерлер тизмеси",
        roles: ["SuperAdmin", "Admin"],
      },
    ],
  },
  {
    key: "docs-sub",
    label: "Бланки",
    labelKg: "Бланктар",
    roles: ["Admin", "SuperAdmin", "Worker"],
    children: DOC_FILES.map((file) => ({
      ...file,
      isDownload: true,
    })),
  },
  {
    key: "bids-sub",
    label: "Заявки",
    labelKg: "Өтүнмөлөр",
    roles: ["Admin", "SuperAdmin", "Worker"],
    children: [
      {
        key: "/bids/create",
        label: "Создать заявку",
        labelKg: "Өтүнмө түзүү",
        roles: ["Admin", "SuperAdmin", "Worker"],
      },
      {
        key: "/bids/incoming", 
        label: "Входящие Заявки",
        labelKg: "Келген өтүнмөлөр",
        roles: ["Admin", "SuperAdmin", "Worker"]
      },
    ],
  },
];