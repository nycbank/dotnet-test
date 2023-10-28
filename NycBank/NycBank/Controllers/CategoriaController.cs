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
    [Route("Categoria")] // Renomeado para usar o nome da classe em minúsculas
    public class CategoriaController : ControllerBase
    {
        private readonly BankContext _context;

        public CategoriaController(BankContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegistrarCategoria([FromBody] CreateCategoriaDto dto)
        {
            if (dto.Nome != null)
            {
                Categoria categoria = new Categoria
                {
                    Nome = dto.Nome
                };

                await _context.CadastroCategoria.AddAsync(categoria);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(RecuperaCategoriaID), new { id = categoria.Id }, categoria);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperaCategoriaID(int id)
        {
            var categoria = await _context.CadastroCategoria.FirstOrDefaultAsync(c => c.Id == id);
            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AtualizaCategoria(int id, [FromBody] UpdateCategoriaDto dto)
        {
            var categoria = await _context.CadastroCategoria.FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
                return NotFound();

            categoria.Nome = dto.Nome;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeletaCategoria(int id)
        {
            var categoria = await _context.CadastroCategoria.FirstOrDefaultAsync(c => c.Id == id);

            if (categoria == null)
                return NotFound();

            _context.CadastroCategoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
