using System.ComponentModel.DataAnnotations;

namespace tecBackend.Dtos;

public class CreateSuggestionRequest
{
    [Required(ErrorMessage = "Опишите ваше предложение")]
    [MaxLength(1000, ErrorMessage = "Предложение не должно превышать 1000 символов")]
    public string? Text { get; set; }

    [MaxLength(500, ErrorMessage = "Комментарий не должен превышать 500 символов")]
    public string? Comment { get; set; }
}

public class UpdateSuggestionCommentRequest
{
    /// <summary>Пустое значение удаляет комментарий.</summary>
    [MaxLength(500, ErrorMessage = "Комментарий не должен превышать 500 символов")]
    public string? Comment { get; set; }
}

/// <summary>Предложение в списке «Мои предложения».</summary>
public class SuggestionDto
{
    public int Id { get; set; }

    public string Text { get; set; } = "";

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    /// <summary>Ответ администратора (если есть).</summary>
    public string? AdminComment { get; set; }

    public DateTime? AdminCommentAt { get; set; }
}

/// <summary>Предложение в админке: дополнительно видно, кто его оставил.</summary>
public class AdminSuggestionDto : SuggestionDto
{
    public int UserId { get; set; }

    /// <summary>ФИО из кадровой записи, а если сотрудник не привязан — логин.</summary>
    public string UserName { get; set; } = "";

    public string UserLogin { get; set; } = "";

    public string? UserDepartment { get; set; }

    /// <summary>Кто из администраторов оставил комментарий.</summary>
    public string? AdminCommentBy { get; set; }
}