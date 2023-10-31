using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NycBank.Data;
using NycbankAPI.Data.Dto;
using NycbankAPI.Models;

namespace NycbankAPI.Controllers
{
    [ApiController]
    [Route("CategoriaProduto")]
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


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ReadCategoriaProdutosDto> RecuperaCategoria()
        {
          

            return _mapper.Map<List<ReadCategoriaProdutosDto>>(_context.CategoriasProdutos.ToList());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RecuperaCategoriaProdutoID(int id)
        {

            CategoriaProduto catproduto = _context.CategoriasProdutos.FirstOrDefault(catproduto => catproduto.Id == id);

            if(catproduto!= null)
            {

                ReadCategoriaProdutosDto catprodutoDto = _mapper.Map<ReadCategoriaProdutosDto>(id);
                return Ok(catprodutoDto);

            }


            return NotFound();

        }
    
        }
    

}