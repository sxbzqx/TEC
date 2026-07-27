using System;

namespace tecBackend.Models;

public partial class ActivityLog
{
    public int Id { get; set; }

    /// <summary>
    /// Семантический тип события: "post_created", "post_updated",
    /// "post_deleted", "role_changed" и т.д. Список открытый —
    /// фронтенд сам решает, какую иконку/цвет показать для известных
    /// типов и какой дефолт показывать для неизвестных.
    /// </summary>
    public string Action { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Subtitle { get; set; }

    public int? ActorUserId { get; set; }

    public DateTime CreatedAt { get; set; }
}