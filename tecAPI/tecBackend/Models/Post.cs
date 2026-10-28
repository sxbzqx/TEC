namespace tecBackend.Models;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; } = string.Empty;
    public string? Content { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; }

    public int? CreatedByUserId { get; set; }
    public string? CreatorName { get; set; }
    public string? CreatorDepartment { get; set; }

    public int CategoryId { get; set;}

    /// <summary>Короткое описание для карточек (необязательно).</summary>
    public string? Summary { get; set; }

    /// <summary>false — черновик, виден только администраторам.</summary>
    public bool IsPublished { get; set; } = true;

    /// <summary>Показывать в блоке новостей на главной странице (DashboardPage).</summary>
    public bool ShowOnMain { get; set; }

    /// <summary>Приоритет: 0 — обычная, 1 — важная, 2 — срочная. Влияет на порядок на главной.</summary>
    public int Priority { get; set; }

    public DateTime? UpdatedAt { get; set; }

    [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CategoryId")]
    public Category Category { get; set; } 
}

