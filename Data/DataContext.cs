using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnet_test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=sql_server_dotnet_test;User Id=sa;Password=reallyStrongPwd123;TrustServerCertificate=True;");
        }

        public DbSet<dotnet_test.Models.Category> Category { get; set; }

        public DbSet<dotnet_test.Models.Product> Product { get; set; }
    }
}
