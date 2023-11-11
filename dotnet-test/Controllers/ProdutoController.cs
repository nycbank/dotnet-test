using dotnet_test.Models;
using dotnet_test.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> BuscarTodosProdutos()
        {
            List<Produto> produtos = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<Produto>>> BuscarProdutoPorId(int id)
        {
            Produto produto = await _produtoRepositorio.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<Produto> Adicionar([FromBody] Produto produto)
        {
            Produto produtoCriado = _produtoRepositorio.Adicionar(produto);
            return Ok(produtoCriado);
        }

        [HttpDelete]
        public async Task< ActionResult> Apagar(int id)
        {
            bool removido = await _produtoRepositorio.Apagar(id);
            if (removido)
            {
                return NoContent();
            }
            else 
            { 
                return NotFound(); 
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Atualizar([FromBody] Produto produto, int id)
        {
            produto.Id = id;
            Produto produtoAtualizado = await _produtoRepositorio.Atualizar(produto, id);
            return Ok(produtoAtualizado);
        }

    }
}
