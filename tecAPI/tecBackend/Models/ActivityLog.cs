using System;

namespace tecBackend.Models;

public partial class ActivityLog
{
    public int Id { get; set; }

    public string Action { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Subtitle { get; set; }

    public int? ActorUserId { get; set; }

    public DateTime CreatedAt { get; set; }
}