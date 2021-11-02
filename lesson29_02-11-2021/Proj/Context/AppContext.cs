using Microsoft.EntityFrameworkCore;
using Proj.Models;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions options) : base (options) {  }

    public DbSet<Quote> Quotes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Quote>().HasData
            (
             new Quote() { Id = 1, Text = "Programming isn't about what you know; it's about what you can figure out", Author = "Chris Pine" },
             new Quote() { Id = 2, Text = "The only way to learn a new programming language is by writing programs in it.", Author = "Dennis Ritchie" },
             new Quote() { Id = 3, Text = "Sometimes it's better to leave something alone, to pause, and that's very true of programming.", Author = "Joyce Wheeler" },
             new Quote() { Id = 4, Text = "Testing leads to failure, and failure leads to understanding.", Author = "Burt Rutan" },
             new Quote() { Id = 5, Text = "The most damaging phrase in the language is.. it's always been done this way", Author = "Grace Hopper" }
            );
    }
}
