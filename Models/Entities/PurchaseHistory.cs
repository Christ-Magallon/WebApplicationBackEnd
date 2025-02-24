using System;

namespace WebApplicationBackEnd.Models.Entities;

public class PurchaseHistory
{
    public Guid id { get; set; }
    public required string ProductId { get; set; }
    public required string UserId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int Quantity { get; set; }
    public string? UserName { get; set; }
    public string? ProductName { get; set; }

}
