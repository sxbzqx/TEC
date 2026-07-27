using Microsoft.EntityFrameworkCore;
using tecBackend.Models;

namespace tecBackend.Utils;

/// <summary>
/// Определяет отображаемое имя и отдел пользователя для полей вида
/// "кто создал / из какого отдела" (заявки, новости и т.п.).
/// Если у аккаунта есть табельный номер (это сотрудник, прошедший
/// employee-регистрацию) — берём настоящее ФИО из справочника workers,
/// иначе используем логин.
/// </summary>
public static class CreatorInfoResolver
{
    public record CreatorInfo(string Name, string? Department);

    public static async Task<CreatorInfo> ResolveAsync(SiteContext context, User? user)
    {
        if (user == null)
            return new CreatorInfo("Неизвестно", null);

        var name = user.Login;
        if (user.Tabel != null)
        {
            var worker = await context.Workers.FirstOrDefaultAsync(w => w.Tabel == user.Tabel);
            if (worker != null)
                name = worker.Fio;
        }

        return new CreatorInfo(name, user.Otdel?.NameOtd);
    }

    /// <summary>
    /// Батч-версия для списков: один запрос на пользователей и один на workers,
    /// вместо N+1 при обходе каждой записи по отдельности.
    /// </summary>
    public static async Task<Dictionary<int, CreatorInfo>> ResolveManyAsync(
        SiteContext context,
        IEnumerable<int> userIds
    )
    {
        var ids = userIds.Distinct().ToList();

        if (ids.Count == 0)
            return new Dictionary<int, CreatorInfo>();

        // MySql.EntityFrameworkCore не умеет транслировать List<T>.Contains()
        // в SQL IN(...) для этой версии провайдера ("Expression '@ids'/'@tabels'
        // in the SQL tree does not have a type mapping assigned") — что для
        // пустых списков, что для непустых. Забираем всё и фильтруем в памяти:
        // и Users, и Workers — это справочники (сотрудники завода), не десятки
        // тысяч строк, так что нагрузка не проблема.
        var allUsers = await context.Users.Include(u => u.Otdel).ToListAsync();
        var users = allUsers.Where(u => ids.Contains(u.Id)).ToList();

        var tabels = users.Where(u => u.Tabel != null).Select(u => u.Tabel!).Distinct().ToList();

        Dictionary<string, string> fioByTabel;
        if (tabels.Count == 0)
        {
            fioByTabel = new Dictionary<string, string>();
        }
        else
        {
            var allWorkers = await context.Workers.ToListAsync();
            fioByTabel = allWorkers
                .Where(w => tabels.Contains(w.Tabel))
                .ToDictionary(w => w.Tabel, w => w.Fio);
        }

        return users.ToDictionary(
            u => u.Id,
            u => new CreatorInfo(
                u.Tabel != null && fioByTabel.TryGetValue(u.Tabel, out var fio) ? fio : u.Login,
                u.Otdel?.NameOtd
            )
        );
    }
}
