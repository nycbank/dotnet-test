using System;
using Microsoft.AspNetCore.Mvc;
using NYCBank_API.Models;
using NYCBank_API.Data;

namespace NYCBank_API.Controllers;

[ApiController]
[Route("[controller]")]

public class ProdutosController : ControllerBase
{
	private ProdutoContext _context;

	public ProdutosController(ProdutoContext context)
	{
		_context = context;
	}


	[HttpPost]
	public IActionResult PostProduto([FromBody] Produto produto)
	{
		_context.Produtos.Add(produto);
		_context.SaveChanges();
		return CreatedAtAction(nameof(GetProdutoByID),
			new { id = produto.Id }, produto);
	}

	[HttpGet]
	public IEnumerable<Produto> GetProdutos(
		[FromQuery]int skip = 0, int take = 50)
	{
		return _context.Produtos.Skip(skip).Take(take);
	}

	[HttpGet("{id}")]
	public IActionResult GetProdutoByID(int id)
	{
		var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
		if (produto == null) return NotFound();
        return Ok();
	}

}

