using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dotnet_test.Models;

namespace dotnet_test.Data.Mapeamento
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(categoria => categoria.Id);
            builder.Property(categoria => categoria.Nome).IsRequired().HasMaxLength(255);
        }
    }
}
