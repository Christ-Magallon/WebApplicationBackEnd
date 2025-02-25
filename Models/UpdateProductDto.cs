using System;

namespace WebApplicationBackEnd.Models;

public class UpdateProductDto
{
    public required string name { get; set; }
    public required string description { get; set; }
    public required int quantity { get; set; }
    public required decimal price { get; set; }

}
