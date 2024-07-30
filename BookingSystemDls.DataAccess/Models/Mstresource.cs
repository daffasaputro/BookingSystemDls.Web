using System;
using System.Collections.Generic;

namespace BookingSystemDls.DataAccess.Models;

public partial class Mstresource
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Status { get; set; }

    public string? Icon { get; set; }

    public virtual ICollection<Resourcecode> Resourcecodes { get; set; } = new List<Resourcecode>();

    public virtual ICollection<Mstroom> Rooms { get; set; } = new List<Mstroom>();
}
