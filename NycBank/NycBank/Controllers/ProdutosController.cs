using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NycBank.Data;
using NycBank.Data.Dtos;
using NycBank.Models;
using System;
using System.Threading.Tasks;

namespace NycBank.Controllers
{
    [ApiController]
    [Route("Produtos")] // Renomeado para usar o nome da classe em minúsculas
    public class ProdutosController : ControllerBase
    {
        private readonly BankContext _context;

        public ProdutosController(BankContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarProduto([FromBody] CreateProdutosDto dto)
        {
            if (dto.Nome != null && dto.Preco != null)
            {
                Produtos produto = new Produtos
                {
                    Nome = dto.Nome,
                    Preco = dto.Preco
                };

                await _context.CadastroProduto.AddAsync(produto);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(RecuperaProdutoID), new { id = produto.ID }, produto);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperaProdutoID(int id)
        {
            var produto = await _context.CadastroProduto.FirstOrDefaultAsync(p => p.ID == id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AtualizaProduto(int id, [FromBody] UpdateProdutosDto dto)
        {
            var produto = await _context.CadastroProduto.FirstOrDefaultAsync(p => p.ID == id);

            if (produto == null)
                return NotFound();

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletaProduto(int id)
        {
            var produto = await _context.CadastroProduto.FirstOrDefaultAsync(p => p.ID == id);

            if (produto == null)
                return NotFound();

            _context.CadastroProduto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
