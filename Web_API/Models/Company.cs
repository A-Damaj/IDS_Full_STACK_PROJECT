using System;
using System.Collections.Generic;

namespace WebApplicationfin.Models;

public partial class Company
{
    public int Id { get; set; } 

    public string? Name { get; set; } = null;

    public string? Description { get; set; } = null;

    public string? Email { get; set; } = null;

    public string? Logo { get; set; } = null; 

    public bool? Active { get; set; } = null;

    public int? UserId { get; set; } = null;

    public virtual ICollection<Room> Rooms { get; set; } = null; //= new List<Room>();

    public virtual User? User { get; set; } = null;
}
