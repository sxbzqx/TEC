using System;
using System.Collections.Generic;

namespace tecBackend.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
    
    public string? Role { get; set; } = "Worker";

    public int? OtdelId { get; set; }

    public Otdel? Otdel { get; set; }


    public string? Question { get; set; }

    public string? Answer { get; set; }

    public short? IdGroup { get; set; }

    public short IdPost { get; set; }

    public string? Tabel { get; set; }

    public string? Mail { get; set; }

    public sbyte Ban { get; set; }

    public DateTime? BanDate { get; set; }

    public string? BanComment { get; set; }

    public sbyte BanAmount { get; set; }

    public DateTime ComeDate { get; set; }
}
