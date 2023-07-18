using System;
using System.Collections.Generic;

namespace WebApplicationfin.Models;

public partial class Room
{
    public int Id { get; set; }

    public string? Name { get; set; } = null;

    public string? Location { get; set; } = null;

    public int? Capacity { get; set; } = null;

    public string? RoomDescription { get; set; } = null;

    public int? CompanyId { get; set; } = null;

    public virtual Company? Company { get; set; } = null;

    public virtual ICollection<Reservation> Reservations { get; set; } = null;//= new List<Reservation>();
}
