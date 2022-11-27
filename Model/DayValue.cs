using System;
using System.Collections.Generic;

namespace Shop_Manager_Assitant_Backend.Model;

public partial class DayValue
{
    public int Id { get; set; }

    public decimal? Monday { get; set; }

    public decimal? Tuesday { get; set; }

    public decimal? Wednesday { get; set; }

    public decimal? Thursday { get; set; }

    public decimal? Friday { get; set; }

    public decimal? Saturday { get; set; }

    public decimal? Sunday { get; set; }
}
