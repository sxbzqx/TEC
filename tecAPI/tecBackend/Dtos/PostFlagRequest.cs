using System.ComponentModel.DataAnnotations;

namespace tecBackend.Dtos;

/// <summary>Быстрое изменение флагов новости из таблицы (без редактора).</summary>
public class PostFlagsRequest
{
    public bool? IsPublished { get; set; }
    public bool? ShowOnMain { get; set; }

    [Range(0, 2)]
    public int? Priority { get; set; }
}
