using System;
using Microsoft.AspNetCore.Mvc;
using NYCBank_API.Models;

namespace NYCBank_API.Controllers;

[ApiController]
[Route("[controller]")]

public class ProdutosController : ControllerBase
{
	private static List<Produto> produtos = new List<Produto>();
	private static int id = 0;

	[HttpPost]
	public void PostProduto([FromBody] Produto produto)
	{
		produto.Id = id++;
		produtos.Add(produto);
	}

	[HttpGet]
	public IEnumerable<Produto> GetProdutos(
		[FromQuery]int skip = 0, int take = 50)
	{
		return produtos.Skip(skip).Take(take);
	}

	[HttpGet("{id}")]
	public Produto? GetProdutoByID(int id)
	{
		return produtos.FirstOrDefault(produto => produto.Id == id);
	}

}

