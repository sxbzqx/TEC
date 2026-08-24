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
}
