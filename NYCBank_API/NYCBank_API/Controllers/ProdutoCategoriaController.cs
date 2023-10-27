using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using NYCBank_API.Models;
using NYCBank_API.Data;
using NYCBank_API.Data.DTOs;

namespace NYCBank_API.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ProdutoCategoriaController : ControllerBase
    {
        private ProdutoContext _context;
        private IMapper _mapper;

        public ProdutoCategoriaController(ProdutoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um PRODUTO E CATEGORIA ao banco de dados
        /// </summary>
        /// <param name="produtoCategoriaDTO">Objeto parametros para criação do PRODUTO E CATEGORIA</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Se a inserção for feita corretamente.</response>
        [HttpPost]
        public IActionResult PostProdutoCategoria(CreateProdutoCategoriaDTO produtoCategoriaDTO)
        {
            ProdutoCategoria produtoCategoria = _mapper.Map<ProdutoCategoria>(produtoCategoriaDTO);
            _context.ProdutoCategorias.Add(produtoCategoria);
            _context.SaveChanges();
            var resultDTO = _mapper.Map<ReadProdutoCategoriaDTO>(produtoCategoria);
            return CreatedAtAction(nameof(GetProdutoCategoriaById), new { id = produtoCategoria.Id }, resultDTO);
        } //Por algum motivo que AINDA não encontrei, o relacionamento está sendo criado sempre com ID 0, mas continuarei trabalhando para solução.

        /// <summary>   
        /// Recebe o PRODUTO COM CATEGORIA do banco de dados baseado no ID
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se a resposta do BD for feita corretamente.</response>
        [HttpGet("{id}")]
        public IActionResult GetProdutoCategoriaById(int id)
        {
            var produtoCategoria = _context.ProdutoCategorias.Find(id);
            if (produtoCategoria == null)
                return NotFound();
            var produtoCategoriaDTO = _mapper.Map<ReadProdutoCategoriaDTO>(produtoCategoria);
            return Ok(produtoCategoriaDTO);
        }

        /// <summary>
        /// Recebe as CATEGORIAS COM PRODUTOS do banco de dados
        /// </summary>
        /// <returns>IEnumerable</returns>
        /// <response code="200">Se a resposta do BD for feita corretamente.</response>
        [HttpGet]
        public IActionResult GetAllProdutoCategorias()
        {
            var produtoCategorias = _context.ProdutoCategorias.ToList();
            if (produtoCategorias == null || produtoCategorias.Count == 0)
                return NotFound();
            var produtoCategoriasDTO = _mapper.Map<List<ReadProdutoCategoriaDTO>>(produtoCategorias);
            return Ok(produtoCategoriasDTO);
        }
    }
}



