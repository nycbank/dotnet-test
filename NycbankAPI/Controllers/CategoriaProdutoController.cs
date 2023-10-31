using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NycBank.Data;
using NycbankAPI.Data.Dto;
using NycbankAPI.Models;

namespace NycbankAPI.Controllers
{
    public class CategoriaProdutoController : ControllerBase
    {
        private readonly BankContext _context;
        private IMapper _mapper;

        public CategoriaProdutoController(BankContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult> AdicionarCategoriaProduto(CreateCategoriaProdutosDto dto)
        {


            CategoriaProduto catproduto = _mapper.Map<CategoriaProduto>(dto);
            _context.CategoriasProdutos.Add(catproduto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(RecuperaCategoriaProdutoID), new
            { Id = catproduto.Id }, catproduto);


        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RecuperaCategoriaProdutoID(int id)
        {
            var produto = await _context.CategoriasProdutos.FirstOrDefaultAsync(p => p.ID == id);
            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AtualizaProduto(int id)
        {
            var produto = await _context.CategoriasProdutos.FirstOrDefaultAsync(p => p.ID == id);

            if (produto == null)
                return NotFound();

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    
        }
    

}