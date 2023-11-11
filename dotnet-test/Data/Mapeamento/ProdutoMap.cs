using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_test.Models;

namespace dotnet_test.Data.Mapeamento
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(produto => produto.Id);
            builder.Property(produto => produto.Nome).IsRequired().HasMaxLength(255);
            builder.Property(produto => produto.Preco).IsRequired();
            
        }
    }
}
