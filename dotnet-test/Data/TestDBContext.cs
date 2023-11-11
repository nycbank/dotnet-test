using dotnet_test.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_test.Data
{
    public class TestDBContext:DbContext
    {
        public TestDBContext(DbContextOptions<TestDBContext> options)
            : base(options) 
        { 
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
