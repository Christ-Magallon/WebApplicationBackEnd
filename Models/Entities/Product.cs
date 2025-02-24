using System;
using System.Buffers.Text;

namespace WebApplicationBackEnd.Models.Entities;

public class Product
{
    public Guid id { get; set; }
    public required string name { get; set; }
    public required int quantity { get; set; }
    public string? description { get; set; }
    public decimal price { get; set; }
    public byte[]? image { get; set; }
    public required string category { get; set; }
    public int? PurchaseCount { get; set; }
    
}
