using System;
using System.Collections.Generic;

namespace WebApplicationfin.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; } = null;

    public DateTime? DateOfBirth { get; set; } = null;

    public string? Gender { get; set; } = null;

    public string? Email { get; set; } = null;

    public string? Password { get; set; } = null;

    public string? Role { get; set; } = null;

    public virtual ICollection<Company> Companies { get; set; } = null;//= new List<Company>();
}
