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

public class CategoriaController : ControllerBase
{
    private ProdutoContext _context;
    private IMapper _mapper;

    public CategoriaController(ProdutoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona uma CATEGORIA ao banco de dados
    /// </summary>
    /// <param name="categoriaDTO">Objeto parametros para criação de CATEGORIA</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Se a inserção for feita corretamente.</response>
    [HttpPost]
    public IActionResult PostCategoria([FromBody] CreateCategoriaDTO categoriaDTO)
    {
        Categoria categoria = _mapper.Map<Categoria>(categoriaDTO);
        _context.Categorias.Add(categoria);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCategoriaByID),
            new { id = categoria.Id }, categoria);
    }

    /// <summary>
    /// Recebe as CATEGORIAS do banco de dados
    /// </summary>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Se a resposta do BD for feita corretamente.</response>
    [HttpGet]
    public IEnumerable<ReadCategoriaDTO> GetCategoria(
        [FromQuery] int skip = 0, int take = 50)
    {
        return _mapper.Map<List<ReadCategoriaDTO>>(_context.Categorias.Skip(skip).Take(take));
    }

    /// <summary>
    /// Recebe o PRODUTO do banco de dados baseado no ID
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="200">Se a resposta do BD for feita corretamente.</response>
    [HttpGet("{id}")]
    public IActionResult GetCategoriaByID(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
        if (categoria == null) return NotFound();
        var categoriaDTO = _mapper.Map<ReadCategoriaDTO>(categoria);
        return Ok(categoriaDTO);
    }

    /// <summary>
    /// Edita um campo especifico de um PRODUTO do banco de dados baseado no ID e campo informado pelo usuário.
    /// </summary>
    /// <returns>IActionResult</returns>
    /// <response code="201">Se edição no BD for feita corretamente.</response>
    [HttpPatch]
    public IActionResult PatchCategoria(int id, JsonPatchDocument<UpdateCategoriaDTO> patch)
    {
        var categoria = _context.Categorias.FirstOrDefault(
            categoria => categoria.Id == id);
        if (categoria == null) return NotFound();

        var categoriaPatch = _mapper.Map<UpdateCategoriaDTO>(categoria);
        patch.ApplyTo(categoriaPatch, ModelState);

        if (!TryValidateModel(categoriaPatch))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(categoriaPatch, categoria);
        _context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Remove um PRODUTO do banco de dados baseado no ID
    /// <returns>IActionResult</returns>
    /// <response code="201">Se a deleção no BD for feita corretamente.</response>
    [HttpDelete("{id}")]
    public IActionResult DeleteCategoria(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(
            categoria => categoria.Id == id);
        if (categoria== null) return NotFound();
        _context.Remove(categoria);
        _context.SaveChanges();
        return NoContent();
    }

}


