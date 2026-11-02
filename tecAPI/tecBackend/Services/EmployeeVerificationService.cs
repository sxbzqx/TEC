using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Services;

public enum EmployeeCheckStatus
{
    Ok,
    BadRequest,
    NotFound,
    Conflict,
}

public record EmployeeCheckResult(EmployeeCheckStatus Status, string? Message = null, Worker? Worker = null)
{
    public bool IsOk => Status == EmployeeCheckStatus.Ok;
}

public interface IEmployeeVerificationService
{
    /// <summary>Найти сотрудника по табельному номеру, который ещё не привязан к аккаунту.</summary>
    Task<EmployeeCheckResult> FindAvailableWorkerAsync(string? tabel);

    /// <summary>То же + сверка ФИО и даты рождения.</summary>
    Task<EmployeeCheckResult> VerifyIdentityAsync(string? tabel, string? fio, DateTime birthDate);

    /// <summary>Id отдела из справочника otdels по записи сотрудника (полное название, затем короткое).</summary>
    Task<int?> ResolveOtdelIdAsync(Worker worker);
}

public class EmployeeVerificationService(SiteContext context) : IEmployeeVerificationService
{
    public async Task<EmployeeCheckResult> FindAvailableWorkerAsync(string? tabel)
    {
        tabel = tabel?.Trim();
        if (string.IsNullOrEmpty(tabel))
            return new(EmployeeCheckStatus.BadRequest, "Укажите табельный номер");

        var worker = await context.Workers.FirstOrDefaultAsync(w => w.Tabel == tabel);
        if (worker == null)
            return new(EmployeeCheckStatus.NotFound, "Сотрудник с таким табельным номером не найден");

        var alreadyRegistered = await context.Users.AnyAsync(u => u.Tabel == worker.Tabel);
        if (alreadyRegistered)
            return new(
                EmployeeCheckStatus.Conflict,
                "Для этого табельного номера уже создан аккаунт. Обратитесь к администратору, если это не вы.");

        return new(EmployeeCheckStatus.Ok, Worker: worker);
    }

    public async Task<EmployeeCheckResult> VerifyIdentityAsync(string? tabel, string? fio, DateTime birthDate)
    {
        if (string.IsNullOrWhiteSpace(fio))
            return new(EmployeeCheckStatus.BadRequest, "Укажите ФИО");

        var found = await FindAvailableWorkerAsync(tabel);
        if (!found.IsOk)
            return found;

        var worker = found.Worker!;
        if (!FioMatches(fio, worker.Fio) || birthDate.Date != worker.Dr.Date)
            return new(EmployeeCheckStatus.BadRequest, "ФИО или дата рождения не совпадают с данными в системе");

        return found;
    }

    public async Task<int?> ResolveOtdelIdAsync(Worker worker)
    {
        var full = worker.Otdel?.Trim().ToLower();
        if (!string.IsNullOrEmpty(full))
        {
            var byFull = await context.Otdels.FirstOrDefaultAsync(o => o.NameOtd.Trim().ToLower() == full);
            if (byFull != null)
                return byFull.Id;
        }

        var shortName = worker.OtdelRusS?.Trim().ToLower();
        if (!string.IsNullOrEmpty(shortName))
        {
            var byShort = await context.Otdels.FirstOrDefaultAsync(o => o.NameOtd.Trim().ToLower() == shortName);
            if (byShort != null)
                return byShort.Id;
        }

        return null;
    }

    private static bool FioMatches(string input, string actual)
    {
        static string Normalize(string s) =>
            string.Join(' ', s.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Replace('ё', 'е')
                .Replace('Ё', 'Е');

        return string.Equals(Normalize(input), Normalize(actual), StringComparison.OrdinalIgnoreCase);
    }
}