using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class Movement
{
    public short Id { get; set; }

    public int InvNum { get; set; }

    public int IdUstr { get; set; }

    public string TypeUstr { get; set; } = null!;

    public string FromDep { get; set; } = null!;

    public string FromUser { get; set; } = null!;

    public string FromUserFio { get; set; } = null!;

    public string FromNetname { get; set; } = null!;

    public string IntoDep { get; set; } = null!;

    public string IntoUser { get; set; } = null!;

    public string IntoUserFio { get; set; } = null!;

    public string IntoNetname { get; set; } = null!;

    public DateTime MoveDate { get; set; }

    public string MoveUser { get; set; } = null!;
}
