using System;
using System.Collections.Generic;

namespace BookingSystemDls.DataAccess.Models;

public partial class Mstroom
{
    public int Id { get; set; }

    public int Locationid { get; set; }

    public string Name { get; set; } = null!;

    public int Floor { get; set; }

    public string? Description { get; set; }

    public int Capacity { get; set; }

    public string Color { get; set; } = null!;

    public virtual Mstlocation Location { get; set; } = null!;

    public virtual ICollection<Mstresource> Resources { get; set; } = new List<Mstresource>();
}
