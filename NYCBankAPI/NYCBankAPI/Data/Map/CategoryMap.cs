using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NYCBankAPI.Models;

namespace NYCBankAPI.Data.Map;

public class CategoryMap : IEntityTypeConfiguration<CategoryModel>
{
    public void Configure(EntityTypeBuilder<CategoryModel> builder)
    {
        builder.HasKey(x => x.CategoryId);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

    }
}
