using dotnet_test.Data.Dtos.CategoriaDto;
using dotnet_test.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_test.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize("Bearer")]
public class CategoriaController : ControllerBase
{
    private readonly CategoriaService _categoriaService;

    public CategoriaController(CategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpPost]
    public IActionResult PostCategoria([FromBody] CreateCategoriaDto categoriaDto)
    {
        ReadCategoriaDto readCategoriaDto = _categoriaService.PostCategoria(categoriaDto);
        return CreatedAtAction(nameof(GetCategoriaById), new { id = readCategoriaDto.id }, readCategoriaDto);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public IActionResult GetCategoriaById(int id)
    {
        ReadCategoriaDto readCategoriaDto = _categoriaService.GetCategoriaById(id);
        if (readCategoriaDto != null)
            return Ok(readCategoriaDto);
        return NotFound();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetCategoria()
    {
        List<ReadCategoriaDto> readCategoriaDtos = _categoriaService.GetCategorias();
        if (readCategoriaDtos != null)
            return Ok(readCategoriaDtos);
        return NotFound();
    }
    
    [HttpPut]
    public IActionResult UpdateProduto(UpdateCategoriaDto categoriaDto)
    {
        Result result = _categoriaService.UpdateCategoria(categoriaDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteTeam(int id)
    {
        Result result = _categoriaService.DeleteCategoria(id);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
}