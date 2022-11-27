using System;
using System.Collections.Generic;

namespace Shop_Manager_Assitant_Backend.Model;

public partial class Shift
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? ShiftNumber { get; set; }

    public int? CityId { get; set; }

    public int? UserId { get; set; }

    public int? User2Id { get; set; }

    public int? User3Id { get; set; }

    public int? User4Id { get; set; }

    public decimal? AccountBalance { get; set; }

    public virtual City? City { get; set; }

    public virtual ShiftValue? ShiftNumberNavigation { get; set; }

    public virtual User? User { get; set; }

    public virtual User? User2 { get; set; }

    public virtual User? User3 { get; set; }

    public virtual User? User4 { get; set; }
}
