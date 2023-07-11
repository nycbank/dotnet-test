using dotnet_test.Data.Dtos.CategoriaDto;
using dotnet_test.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_test.Controllers;

[Route("[controller]")]
[ApiController]
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
    public IActionResult GetCategoriaById(int id)
    {
        ReadCategoriaDto readCategoriaDto = _categoriaService.GetCategoriaById(id);
        if (readCategoriaDto != null)
            return Ok(readCategoriaDto);
        return NotFound();
    }

    [HttpGet]
    public IActionResult GetCategoria()
    {
        List<ReadCategoriaDto> readCategoriaDtos = _categoriaService.GetCategorias();
        if (readCategoriaDtos != null)
            return Ok(readCategoriaDtos);
        return NotFound();
    }
}