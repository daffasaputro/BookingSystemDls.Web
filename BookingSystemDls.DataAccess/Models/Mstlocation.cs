using System;
using System.Collections.Generic;

namespace BookingSystemDls.DataAccess.Models;

public partial class Mstlocation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Mstroom> Mstrooms { get; set; } = new List<Mstroom>();
}
