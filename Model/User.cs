using System;
using System.Collections.Generic;

namespace Shop_Manager_Assitant_Backend.Model;

public partial class User
{
    public int Id { get; set; }

    public int? CityId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? UserName { get; set; }

    public string? Surname { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Shift> ShiftUser2s { get; } = new List<Shift>();

    public virtual ICollection<Shift> ShiftUser3s { get; } = new List<Shift>();

    public virtual ICollection<Shift> ShiftUser4s { get; } = new List<Shift>();

    public virtual ICollection<Shift> ShiftUsers { get; } = new List<Shift>();
}
