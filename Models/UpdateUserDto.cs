using System;

namespace WebApplicationBackEnd.Models;

public class UpdateUserDto
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Type { get; set; }
}
