using Microsoft.EntityFrameworkCore;
using NycBank.Models;

namespace NycBank.Data
{
    public class BankContext : DbContext
    {
        public DbSet<Produtos> CadastroProduto { get; set; }
        public DbSet<Categoria> CadastroCategoria { get; set; }

        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacionamento um-para-muitos entre Produtos e Categoria
            modelBuilder.Entity<Produtos>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);
        }
    }
}
