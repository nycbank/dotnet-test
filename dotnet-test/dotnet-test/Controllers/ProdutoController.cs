using dotnet_test.Data.Dtos.ProdutoDto;
using dotnet_test.Models;
using dotnet_test.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_test.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize("Bearer")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _produtoService;

    public ProdutoController(ProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost]
    public IActionResult PostProduto([FromBody] CreatProdutoDto produtoDto)
    {
        ReadProdutoDto readProdutoDto = _produtoService.PostProduto(produtoDto);
        return CreatedAtAction(nameof(GetProdutoById), new { Id = readProdutoDto.id }, readProdutoDto);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public IActionResult GetProdutoById(int id)
    {
        ReadProdutoDto readProdutoDto = _produtoService.GetProdutoById(id);
        if (readProdutoDto != null)
            return Ok(readProdutoDto);
        return NotFound();
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult GetProduto()
    {
        List<ReadProdutoDto> readProdutoDtos = _produtoService.GetProdutos();
        if (readProdutoDtos != null)
            return Ok(readProdutoDtos);
        return NotFound();
    }

    [HttpPut]
    public IActionResult UpdateProduto(UpdateProdutoDto produtoDto)
    {
        Result result = _produtoService.UpdateProduto(produtoDto);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTeam(int id)
    {
        Result result = _produtoService.DeleteProduto(id);
        if (result.IsFailed)
            return NotFound();
        return NoContent();
    }
    
}