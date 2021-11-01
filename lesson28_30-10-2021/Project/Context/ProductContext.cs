using Microsoft.EntityFrameworkCore;
using Project.Models;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions options) : base(options) {}

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().HasData
            (
             new Product { Id = 1, Name = "Banana", Cost = 5, Category = "Fruit" },
             new Product { Id = 2, Name = "Apple", Cost = 10, Category = "Fruit" },
             new Product { Id = 3, Name = "Mellon", Cost = 15, Category = "Vegetable" },
             new Product { Id = 4, Name = "Carrot", Cost = 3, Category = "Vegetable" }
            );
    }
}
