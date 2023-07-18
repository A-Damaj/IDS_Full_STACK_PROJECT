using System;
using System.Collections.Generic;

namespace WebApplicationfin.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public DateTime? MeetingDate { get; set; } = null;

    public TimeSpan? StartTime { get; set; } = null;

    public TimeSpan? EndTime { get; set; } = null;

    public int? RoomId { get; set; } = null;

    public int? NumberOfAttendees { get; set; } = null;

    public bool? MeetingStatus { get; set; } = null;

    public virtual Room? Room { get; set; } = null;
}
