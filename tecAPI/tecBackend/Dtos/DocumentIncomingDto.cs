namespace tecBackend.Dtos;

public class DocumentIncomingDto
{
    public int Id { get; set; }

    public DateTime DateFirst { get; set; }

    public int IdResource { get; set; }

    public string ResourceName { get; set; } = "";

    /// <summary>Кто создал заявку</summary>
    public string CreatorName { get; set; } = "";

    /// <summary>Из какого отдела создатель заявки (его собственный отдел, не получатель)</summary>
    public string? CreatorDepartment { get; set; }

    public short? Amount { get; set; }

    public string? Comment { get; set; }

    /// <summary>
    /// 0 - на рассмотрении, 1 - разрешено, 2 - отклонено, 3 - отложено
    /// </summary>
    public short Action { get; set; }

    /// <summary>
    /// 1, если выполнена (актуально только для разрешённых заявок)
    /// </summary>
    public short Made { get; set; }

    public DateTime? DateReshenie { get; set; }

    public string? CommentReshenie { get; set; }

    public DateTime? DateVyp { get; set; }
}
