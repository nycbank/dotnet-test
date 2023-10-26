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

    /// <summary>
    /// Adiciona um PRODUTO ao banco de dados
    /// </summary>
    /// <param name="produtoDTO">Objeto parametros para criação do PRODUTO</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Se a inserção for feita corretamente.</response>
	    [HttpPost]
	public IActionResult PostProduto([FromBody] CreateProdutoDTO produtoDTO)
	{
		Produto produto = _mapper.Map<Produto>(produtoDTO);
		_context.Produtos.Add(produto);
		_context.SaveChanges();
		return CreatedAtAction(nameof(GetProdutoByID),
			new { id = produto.Id }, produto);
	}

    /// <summary>
    /// Recebe os PRODUTOS do banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Se a resposta do BD for feita corretamente.</response>
    [HttpGet]
	public IEnumerable<ReadProdutoDTO> GetProdutos(
		[FromQuery]int skip = 0, int take = 50)
	{
		return _mapper.Map<List<ReadProdutoDTO>>(_context.Produtos.Skip(skip).Take(take));
	}

    /// <summary>
    /// Recebe o PRODUTO do banco de dados baseado no ID
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a resposta do BD for feita corretamente.</response>
    [HttpGet("{id}")]
	public IActionResult GetProdutoByID(int id)
	{
		var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
		if (produto == null) return NotFound();
		var produtoDTO = _mapper.Map < ReadProdutoDTO>(produto);
        return Ok(produtoDTO);
	}

    /// <summary>
    /// Edita os campos de um PRODUTO do banco de dados baseado no ID
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="201">Se edição no BD for feita corretamente.</response>
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

    /// <summary>
    /// Edita um campo especifico de um PRODUTO do banco de dados baseado no ID e campo informado pelo usuário.
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="201">Se edição no BD for feita corretamente.</response>
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

    /// <summary>
    /// Remove um PRODUTO do banco de dados baseado no ID
    /// <returns>IActionResult</returns>
    /// <response code="201">Se a deleção no BD for feita corretamente.</response>
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

