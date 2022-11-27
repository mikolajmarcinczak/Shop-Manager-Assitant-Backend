using System;
using System.Collections.Generic;

namespace Shop_Manager_Assitant_Backend.Model;

public partial class City
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Shift> Shifts { get; } = new List<Shift>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
