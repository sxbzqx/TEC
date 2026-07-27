using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Documents202002
{
    public int Id { get; set; }

    public int IdPerUser { get; set; }

    public string? IdUser { get; set; }

    public int IdResource { get; set; }

    public short? Amount { get; set; }

    public DateTime DateFirst { get; set; }

    public DateTime? DateReshenie { get; set; }

    /// <summary>
    /// Пользователь, который разрешил/отклонил заявку
    /// </summary>
    public string UserReshenie { get; set; } = null!;

    public string CommentReshenie { get; set; } = null!;

    public short Action { get; set; }

    public string? IdReceiver { get; set; }

    public short Archive { get; set; }

    public string? Comment { get; set; }

    public short Made { get; set; }

    public DateTime? DateVyp { get; set; }

    public string? Format { get; set; }
}
