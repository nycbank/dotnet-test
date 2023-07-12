using dotnet_test.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_test.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produtos>()
            .HasMany(p => p.Categorias)
            .WithMany(c => c.Produtos);

    }

    public DbSet<Produtos> Produtos { get; set; }
    public DbSet<Categorias> Categorias { get; set; }
}