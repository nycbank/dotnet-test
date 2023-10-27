using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using NYCBank_API.Models;
using NYCBank_API.Data;
using NYCBank_API.Data.DTOs;

namespace NYCBank_API.Controllers;

[ApiController]
[Route("[controller]")]

public class ProdutoCategorizadoController : ControllerBase
{

    private ProdutoContext _context;
    private IMapper _mapper;

    public ProdutoCategorizadoController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um PRODUTO COM CATEGORIA ao banco de dados
    /// </summary>
    /// <param name="produtoCategorizadoDTO">Objeto parametros para criação do PRODUTO COM CATEGORIA</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Se a inserção for feita corretamente.</response>
    [HttpPost]
    public IActionResult PostProdutoCategorizado(CreateProdutoCategorizadoDTO produtoCategorizadoDTO)
    {
        ProdutoCategorizado produtoCategorizado = _mapper.Map<ProdutoCategorizado>(produtoCategorizadoDTO);
        _context.ProdutosCategorizados.Add(produtoCategorizado);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProdutoCategorizadoByID),
            new { id = produtoCategorizado.Id }, produtoCategorizado);
    }

    /// <summary>
    /// Recebe os PRODUTOS COM CATEGORIAS do banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Se a resposta do BD for feita corretamente.</response>
    [HttpGet]
    public IEnumerable<ReadProdutoCategorizadoDTO> GetProdutosCategorizados()
    {
        return _mapper.Map<List<ReadProdutoCategorizadoDTO>>(_context.ProdutosCategorizados.ToList());
    }

    /// <summary>
    /// Recebe o PRODUTO COM CATEGORIA do banco de dados baseado no ID
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a resposta do BD for feita corretamente.</response>
    [HttpGet("{id}")]
    public IActionResult GetProdutoCategorizadoByID(int id)
    {
        var produtoCategorizado = _context.ProdutosCategorizados.FirstOrDefault(produtoCategorizado => produtoCategorizado.Id == id);
        if (produtoCategorizado == null) return NotFound();
        var produtoCategorizadoDTO = _mapper.Map<ReadProdutoCategorizadoDTO>(produtoCategorizado);
        return Ok(produtoCategorizadoDTO);
    }
}

