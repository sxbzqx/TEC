namespace tecBackend.Models;

/// <summary>Предложение по улучшению от сотрудника (раздел «Предложения»).</summary>
public class Suggestion
{
    public int Id { get; set; }

    /// <summary>Кто предложил (users.id).</summary>
    public int UserId { get; set; }

    /// <summary>Суть предложения.</summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>Необязательный комментарий / пояснение к предложению.</summary>
    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    /// <summary>Комментарий (ответ) администратора к предложению.</summary>
    public string? AdminComment { get; set; }

    public DateTime? AdminCommentAt { get; set; }

    /// <summary>Кто из администраторов оставил комментарий (users.id).</summary>
    public int? AdminCommentByUserId { get; set; }
}