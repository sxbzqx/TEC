using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using tecBackend.Models;

namespace tecBackend.Services;

/// <summary>
/// Побочные эффекты успешного SaveChanges:
///  • по изменённым сущностям определяет темы и рассылает DataChanged — контроллерам ничего делать не нужно;
///  • при изменении User сбрасывает кэш роли/бана, чтобы старый JWT перестал работать сразу.
/// События уходят только ПОСЛЕ успешного сохранения, поэтому клиент не успеет запросить старые данные.
/// </summary>
public sealed class RealtimeSaveChangesInterceptor(
    IPortalNotifier notifier,
    IUserAuthStateService authState
) : SaveChangesInterceptor
{
    private sealed record Pending(HashSet<string> Topics, HashSet<int> UserIds);

    // Перехватчик — singleton, а контекстов много, поэтому состояние хранится на каждый контекст отдельно.
    private readonly ConditionalWeakTable<DbContext, Pending> _pending = new();

    private static readonly Dictionary<Type, string> TopicByEntity = new()
    {
        [typeof(Post)] = RealtimeTopics.Posts,
        [typeof(Category)] = RealtimeTopics.Categories,
        [typeof(ActivityLog)] = RealtimeTopics.Activity,
        [typeof(Otdel)] = RealtimeTopics.Departments,
        [typeof(Document)] = RealtimeTopics.Bids,
        [typeof(Resource)] = RealtimeTopics.Resources,
        [typeof(OfficeEquipment)] = RealtimeTopics.Equipment,
        [typeof(Worker)] = RealtimeTopics.Workers,
        [typeof(User)] = RealtimeTopics.Users,
    };

    private void Capture(DbContext? context)
    {
        if (context is null)
            return;

        var topics = new HashSet<string>();
        var userIds = new HashSet<int>();

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.State is not (EntityState.Added or EntityState.Modified or EntityState.Deleted))
                continue;

            if (TopicByEntity.TryGetValue(entry.Entity.GetType(), out var topic))
                topics.Add(topic);

            if (entry.Entity is User user && entry.State != EntityState.Added)
                userIds.Add(user.Id);
        }

        if (topics.Count > 0 || userIds.Count > 0)
            _pending.AddOrUpdate(context, new Pending(topics, userIds));
    }

    private async Task FlushAsync(DbContext? context)
    {
        if (context is null || !_pending.TryGetValue(context, out var pending))
            return;

        _pending.Remove(context);

        foreach (var userId in pending.UserIds)
            authState.Invalidate(userId);

        if (pending.Topics.Count > 0)
            await notifier.PublishDataChangedAsync(pending.Topics);
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result
    )
    {
        Capture(eventData.Context);
        return result;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
    )
    {
        Capture(eventData.Context);
        return ValueTask.FromResult(result);
    }

    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        FlushAsync(eventData.Context).GetAwaiter().GetResult();
        return result;
    }

    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = default
    )
    {
        await FlushAsync(eventData.Context);
        return result;
    }

    public override void SaveChangesFailed(DbContextErrorEventData eventData)
    {
        if (eventData.Context is { } context)
            _pending.Remove(context);
    }

    public override Task SaveChangesFailedAsync(
        DbContextErrorEventData eventData,
        CancellationToken cancellationToken = default
    )
    {
        SaveChangesFailed(eventData);
        return Task.CompletedTask;
    }
}
