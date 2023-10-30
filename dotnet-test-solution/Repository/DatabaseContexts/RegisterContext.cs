using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.DatabaseContexts;

public class RegisterContext : DbContext
{
    /*public RegisterContext(DbContextOptions<RegisterContext> options) : base(options)
    {
        
    }
    */
    private static string connectionString = @"Server=127.0.0.1;Database=register;User Id=SA;Password=P@ssw0rd;TrustServerCertificate=True;";
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
        //Use in memory database if SQL Server is not installed in your environment
        //optionsBuilder.UseInMemoryDatabase("register");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
      
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Price).IsRequired();
            entity.HasMany(e => e.Categories)
                    .WithMany(e => e.Products)
                    .UsingEntity<ProductCategory>();
        });
        
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.HasMany(e => e.Products)
                    .WithMany(e => e.Categories)
                    .UsingEntity<ProductCategory>();
        });
    }
}