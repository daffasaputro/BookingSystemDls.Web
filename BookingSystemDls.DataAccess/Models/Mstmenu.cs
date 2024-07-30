using System;
using System.Collections.Generic;

namespace BookingSystemDls.DataAccess.Models;

public partial class Mstmenu
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Isheader { get; set; }

    public int? Header { get; set; }

    public virtual ICollection<Mstrole> Roles { get; set; } = new List<Mstrole>();
}
