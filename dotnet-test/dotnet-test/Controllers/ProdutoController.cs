using dotnet_test.Data.Dtos.ProdutoDto;
using dotnet_test.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_test.Controllers;

[Route("[controller]")]
[ApiController]
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
    public IActionResult GetProdutoById(int id)
    {
        ReadProdutoDto readProdutoDto = _produtoService.GetProdutoById(id);
        if (readProdutoDto != null)
            return Ok(readProdutoDto);
        return NotFound();
    }

    [HttpGet]
    public IActionResult GetProduto()
    {
        List<ReadProdutoDto> readProdutoDtos = _produtoService.GetProdutos();
        if (readProdutoDtos != null)
            return Ok(readProdutoDtos);
        return NotFound();
    }
    
}