using System;
using System.Collections.Generic;

namespace BookingSystemDls.DataAccess.Models;

public partial class Resourcecode
{
    public string Code { get; set; } = null!;

    public int Resourceid { get; set; }

    public bool Status { get; set; }

    public virtual Mstresource Resource { get; set; } = null!;
}
