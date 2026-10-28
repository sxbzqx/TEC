using System.ComponentModel.DataAnnotations;

namespace tecBackend.Dtos;

public class PostRequest
{
    [Required(ErrorMessage = "Заголовок обязателен")]
    [MaxLength(200)]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Контент обязателен")]
    public string? Content { get; set; }
    public int CategoryId { get; set; }

    [MaxLength(500)]
    public string? Summary { get; set; }

    public bool IsPublished { get; set; } = true;

    public bool ShowOnMain { get; set; }

    /// <summary>0 — обычная, 1 — важная, 2 — срочная.</summary>
    [Range(0, 2)]
    public int Priority { get; set; }
}
