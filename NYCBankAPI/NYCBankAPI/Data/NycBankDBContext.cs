using Microsoft.EntityFrameworkCore;
using NYCBankAPI.Models;

namespace NYCBankAPI.Data;

public class NycBankDBContext : DbContext
{
    public NycBankDBContext(DbContextOptions<NycBankDBContext> options) : base(options)
    {
    }

    public DbSet<ProductModel> Products { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
