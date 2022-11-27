using System;
using System.Collections.Generic;

namespace Shop_Manager_Assitant_Backend.Model;

public partial class ShiftValue
{
    public int Id { get; set; }

    public string? ShiftNumber { get; set; }

    public decimal? ShiftValueVal { get; set; }

    public virtual ICollection<Shift> Shifts { get; } = new List<Shift>();
}
