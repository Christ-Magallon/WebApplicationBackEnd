using System;

namespace WebApplicationBackEnd.Models;

public class UpdateProductDto
{
    public required string name { get; set; }
    public required int quantity { get; set; }
    public string? description { get; set; }
    public decimal price { get; set; }

}
