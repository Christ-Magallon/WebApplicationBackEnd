using System;
using Microsoft.EntityFrameworkCore;
using WebApplicationBackEnd.Models.Entities;

namespace WebApplicationBackEnd.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
}
