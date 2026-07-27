using System.ComponentModel.DataAnnotations;

namespace tecBackend.Dtos;

public class DecideDocumentRequest
{
    /// <summary>
    /// 1 - разрешить, 2 - отклонить, 3 - отложить
    /// </summary>
    [Range(1, 3)]
    public short Action { get; set; }

    [MaxLength(150)]
    public string? Comment { get; set; }
}
