using System;
using System.Collections.Generic;

namespace RMA.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; } = 0;

    public bool IsActive { get; set; }
}
