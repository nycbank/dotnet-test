using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
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
	public IActionResult PutProduto(int id,
		[FromBody] UpdateProdutoDTO produtoDTO)
	{
		var produto = _context.Produtos.FirstOrDefault(
			produto => produto.Id == id);
		if (produto == null) return NotFound();
		_mapper.Map(produtoDTO, produto);
		_context.SaveChanges();
		return NoContent();
	}

	[HttpPatch]
    public IActionResult PatchProduto(int id, JsonPatchDocument<UpdateProdutoDTO> patch)
    {
        var produto = _context.Produtos.FirstOrDefault(
            produto => produto.Id == id);
        if (produto == null) return NotFound();

		var produtoPatch = _mapper.Map<UpdateProdutoDTO>(produto);
		patch.ApplyTo(produtoPatch, ModelState);

		if(!TryValidateModel(produtoPatch))
		{
			return ValidationProblem(ModelState);
		}
		_mapper.Map(produtoPatch, produto);
        _context.SaveChanges();
        return NoContent();
    }

	[HttpDelete("{id}")]
	public IActionResult DeleteProduto(int id)
	{
        var produto = _context.Produtos.FirstOrDefault(
            produto => produto.Id == id);
        if (produto == null) return NotFound();
		_context.Remove(produto);
		_context.SaveChanges();
		return NoContent();
    }

}

