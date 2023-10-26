using System;
using Microsoft.EntityFrameworkCore;
using NYCBank_API.Models;
namespace NYCBank_API.Data;


public class ProdutoContext : DbContext
{
	public ProdutoContext(DbContextOptions<ProdutoContext> opts) : base(opts)
	{
	
	}
	public DbSet<Produto> Produtos { get; set; }
}

