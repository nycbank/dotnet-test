using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Category = Set<Category>();
            Product = Set<Product>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=sql_server_dotnet_test;User Id=sa;Password=reallyStrongPwd123;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories)
                .UsingEntity(j => j.ToTable("CategoryProduct"));

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Category> Category { get; set; }

        public virtual DbSet<Product> Product { get; set; }
    }
}
