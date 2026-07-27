using System.ComponentModel.DataAnnotations;

namespace tecBackend.Dtos;

public class CreateDocumentRequest
{
    [Required]
    public int IdResource { get; set; }

    public short? Amount { get; set; }

    [MaxLength(1000)]
    public string? Comment { get; set; }
}
