using System;
using System.Collections.Generic;

namespace BookingSystemDls.DataAccess.Models;

public partial class Mstrole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Mstmenu> Menus { get; set; } = new List<Mstmenu>();
}
