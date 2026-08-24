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

    [System.ComponentModel.DataAnnotations.Schema.ForeignKey("CategoryId")]
    public Category Category { get; set; } 
}

