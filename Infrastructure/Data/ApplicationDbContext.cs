using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Ensure table names match the exact SQL script provided in the assessment
        modelBuilder.Entity<Product>().ToTable("Product");
        modelBuilder.Entity<Item>().ToTable("Item");

        // Configure the One-to-Many relationship explicitly
        modelBuilder.Entity<Item>()
            .HasOne(i => i.Product)
            .WithMany(p => p.Items)
            .HasForeignKey(i => i.ProductId);
    }
}