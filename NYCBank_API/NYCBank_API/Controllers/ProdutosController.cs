using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using NYCBank_API.Models;
using NYCBank_API.Data;
using NYCBank_API.Data.DTOs;

namespace NYCBank_API.Controllers;

[ApiController]
[Route("[controller]")]

public class ProdutosController : ControllerBase
{
	private ProdutoContext _context;
	private IMapper _mapper;

	public ProdutosController(ProdutoContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}


	[HttpPost]
	public IActionResult PostProduto([FromBody] CreateProdutoDTO produtoDTO)
	{
		Produto produto = _mapper.Map<Produto>(produtoDTO);
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

	[HttpPut("{id}")]
	public IActionResult UpdateProduto(int id,
		[FromBody] UpdateProdutoDTO produtoDTO)
	{
		var produto = _context.Produtos.FirstOrDefault(
			produto => produto.Id == id);
		if (produto == null) return NotFound();
		_mapper.Map(produtoDTO, produto);
		_context.SaveChanges();
		return NoContent();
	}

}

