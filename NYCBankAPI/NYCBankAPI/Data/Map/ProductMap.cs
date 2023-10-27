using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NYCBankAPI.Models;

namespace NYCBankAPI.Data.Map;

public class ProductMap : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.HasKey(x => x.ProductId);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Price).IsRequired();
        builder.Ignore(x => x.CategoryId);

        builder.HasMany(x => x.Categories).WithMany(x=> x.Products).UsingEntity<ProductCategoryModel>
            (
                x => x.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId),
                x => x.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.ProductId),
                x => 
                {
                    x.ToTable("ProductCategory");

                    x.HasKey(p=> new { p.ProductId, p.CategoryId });

                    x.Property(p=> p.ProductId).IsRequired();
                    x.Property(p=> p.ProductId).IsRequired();
                }
            );
    }
}