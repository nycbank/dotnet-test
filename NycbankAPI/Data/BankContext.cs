using Microsoft.EntityFrameworkCore;

using NycbankAPI.Models;

namespace NycBank.Data
{
    public class BankContext : DbContext
    {
      

        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<CategoriaProduto>()
            //    .HasOne(p => p.Categoria)
            //    .WithMany(c => c.Produtos)
            //    .HasForeignKey(p => p.CategoriaId);

            modelBuilder.Entity<CategoriaProduto>()
                .HasKey(catproduto => new { catproduto.ProdutoId,
                    catproduto.CategoriaId});

            modelBuilder.Entity<CategoriaProduto>()
                .HasOne(catproduto => catproduto.Produto)
                .WithMany(Produto => Produto.Categorias)
                .HasForeignKey(catproduto => catproduto.ProdutoId);

            modelBuilder.Entity<CategoriaProduto>()
               .HasOne(catproduto => catproduto.Categoria)
               .WithMany(categoria => categoria.Produtos)
               .HasForeignKey(catproduto => catproduto.CategoriaId);
        }

        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<CategoriaProduto> CategoriasProdutos { get; set; }
    }
}
