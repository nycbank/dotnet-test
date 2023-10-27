using Microsoft.EntityFrameworkCore;
using NYCBankAPI.Data.Map;
using NYCBankAPI.Models;

namespace NYCBankAPI.Data;

public class NycBankDBContext : DbContext
{
    public NycBankDBContext(DbContextOptions<NycBankDBContext> options) : base(options)
    {
    }

    public DbSet<ProductModel> Products { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<ProductCategoryModel> ProductCategory { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());

        base.OnModelCreating(modelBuilder);
    }

}
