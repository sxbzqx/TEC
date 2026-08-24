import { $api } from "@/app/api/api";

interface CurrentUser {
  role: string;
  loginName: string;
  department: string;
}

export interface EmployeeLookupResult {
  otdel: string;
  doljnost: string;
}

interface ApiErrorPayload {
  message?: string;
  Message?: string;
  errors?: Record<string, string[]>;
}

function throwAsResponseError(data: ApiErrorPayload | null, status: number, fallback: string): never {
  throw Object.assign(new Error(data?.message || data?.Message || fallback), {
    response: { data: data ?? { message: fallback }, status },
  });
}

export const authService = {
  async login(loginStr: string, passwordStr: string): Promise<void> {
    const response = await fetch("/api/auth/login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ login: loginStr, password: passwordStr }),
    });

    const data = await response.json().catch(() => null);

    if (!response.ok) {
      throwAsResponseError(data, response.status, "Неверный логин или пароль");
    }
  },

  /** Регистрация обычного пользователя — без привязки к отделу. */
  async register(loginStr: string, passwordStr: string, mailStr: string): Promise<void> {
    const response = await fetch("/api/auth/register", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        login: loginStr,
        password: passwordStr,
        mail: mailStr,
      }),
    });

    const data = await response.json().catch(() => null);

    if (!response.ok) {
      throwAsResponseError(data, response.status, "Произошла ошибка при регистрации");
    }

    await this.login(loginStr, passwordStr);
  },

  /** Шаг 1 регистрации сотрудника: поиск по табельному номеру. */
  async employeeLookup(tabel: string): Promise<EmployeeLookupResult> {
    const response = await fetch("/api/auth/employee/lookup", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ tabel }),
    });

    const data = await response.json().catch(() => null);

    if (!response.ok) {
      throwAsResponseError(data, response.status, "Сотрудник не найден");
    }

    return {
      otdel: data.otdel,
      doljnost: data.doljnost,
    };
  },

  /**
   * Промежуточный шаг: проверка ФИО + даты рождения перед вводом
   * логина/пароля. Ничего не создаёт — окончательная проверка всё равно
   * происходит в employeeRegister.
   */
  async employeeVerify(tabel: string, fio: string, birthDate: string): Promise<void> {
    const response = await fetch("/api/auth/employee/verify", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ tabel, fio, birthDate }),
    });

    const data = await response.json().catch(() => null);

    if (!response.ok) {
      throwAsResponseError(data, response.status, "ФИО или дата рождения не совпадают");
    }
  },

  /**
   * Шаг 2 регистрации сотрудника: подтверждение личности (ФИО + дата рождения,
   * сверяются на бэке с кадровой записью) и установка логина/пароля/почты.
   */
  async employeeRegister(
    tabel: string,
    fio: string,
    birthDate: string,
    loginStr: string,
    passwordStr: string,
    mailStr: string,
  ): Promise<void> {
    const response = await fetch("/api/auth/employee/register", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        tabel,
        fio,
        birthDate,
        login: loginStr,
        password: passwordStr,
        mail: mailStr,
      }),
    });

    const data = await response.json().catch(() => null);

    if (!response.ok) {
      throwAsResponseError(data, response.status, "Произошла ошибка при регистрации");
    }

    await this.login(loginStr, passwordStr);
  },

  async logout(): Promise<void> {
    try {
      await fetch("/api/auth/logout", { method: "POST" });
    } catch (err) {
      console.error("Ошибка при логауте:", err);
    } finally {
      if (typeof window !== "undefined") window.location.href = "/";
    }
  },

  async getCurrentUser(): Promise<CurrentUser | null> {
    try {
      const { data } = await $api.get("/auth/me");
      return {
        role: data.role || data.Role || "Worker",
        loginName: data.loginName || data.LoginName || "Сотрудник",
        department: data.department || data.Department || "Не указан",
      };
    } catch {
      return null;
    }
  },

  async changePassword(currentPassword: string, newPassword: string): Promise<void> {
    const response = await fetch("/api/auth/change-password", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ currentPassword, newPassword }),
    });

    const data = await response.json().catch(() => null);

    if (!response.ok) {
      throwAsResponseError(data, response.status, "Не удалось изменить пароль");
    }
  },

  async changeLogin(newLogin: string, currentPassword: string): Promise<void> {
    const response = await fetch("/api/auth/change-login", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ newLogin, currentPassword }),
    });

    const data = await response.json().catch(() => null);

    if (!response.ok) {
      throwAsResponseError(data, response.status, "Не удалось изменить логин");
    }
  },
};