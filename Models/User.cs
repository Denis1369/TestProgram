using System;
using System.Collections.Generic;

namespace APIWithPostgresql.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string? Name { get; set; }

    public string? Sname { get; set; }
}
