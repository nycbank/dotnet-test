using dotnet_test.Models;
using dotnet_test.Repositorios;
using dotnet_test.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task <ActionResult<List<Categoria>>> BuscarTodasCategorias()
        {
            List<Categoria> categorias = await _categoriaRepositorio.BuscarTodasCategorias();
            return Ok(categorias);
        }

        [HttpGet("id")]
        public async Task<ActionResult<List<Categoria>>> BuscarCategoriaPorId(int id)
        {
            Categoria categoria = await _categoriaRepositorio.BuscarPorId(id);
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Cadastrar([FromBody] Categoria categoria)
        {
            Categoria categoriaCriada = await _categoriaRepositorio.Adicionar(categoria);
            return Ok(categoriaCriada);
        }

        [HttpDelete]
        public async Task<ActionResult> Remover(int id)
        {
            bool removido = await _categoriaRepositorio.Apagar(id);
            if (removido)
            {
                return Ok("Item " + id + "removido com sucesso!");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Atualizar([FromBody] Categoria categoria, int id)
        {
            categoria.Id = id;
            Categoria categoriaAtualizada = await _categoriaRepositorio.Atualizar(categoria, id);
            return Ok(categoriaAtualizada);
        }

    }
}
