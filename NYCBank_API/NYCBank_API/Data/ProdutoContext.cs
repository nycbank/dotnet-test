using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using NYCBank_API.Models;

namespace NYCBank_API.Data
{
    public class ProdutoContext : DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProdutoCategoria>()
                 .HasKey(produtoCategoria => new { produtoCategoria.ProdutoId, produtoCategoria.CategoriaId });

            builder.Entity<ProdutoCategoria>()
                .HasOne(produtoCategoria => produtoCategoria.Produto)
                .WithMany(produto => produto.ProdutoCategorias)
                .HasForeignKey(produtoCategoria => produtoCategoria.ProdutoId);

            builder.Entity<ProdutoCategoria>()
                .HasOne(produtoCategoria => produtoCategoria.Categoria)
                .WithMany(categoria => categoria.ProdutoCategorias)
                .HasForeignKey(produtoCategoria => produtoCategoria.CategoriaId);
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }
    }
}


