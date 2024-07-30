using System;
using System.Collections.Generic;

namespace BookingSystemDls.DataAccess.Models;

public partial class Mstuser
{
    public string Loginname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Roleid { get; set; }

    public string Firstname { get; set; } = null!;

    public string? Middlename { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public virtual Mstrole Role { get; set; } = null!;
}
