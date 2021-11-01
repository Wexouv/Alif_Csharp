using Microsoft.EntityFrameworkCore;
using Project.Models;

public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions options) : base(options) {}

    public DbSet<Product> Products { get; set; }
}
