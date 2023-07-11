using AutoMapper;
using dotnet_test.Data;
using dotnet_test.Data.Dtos.ProdutoDto;
using dotnet_test.Models;

namespace dotnet_test.Services;

public class ProdutoService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProdutoService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadProdutoDto PostProduto(CreatProdutoDto produtoDto)
    {
        Produtos produtos = _mapper.Map<Produtos>(produtoDto);
        _context.Produtos.Add(produtos);
        _context.SaveChanges();
        return _mapper.Map<ReadProdutoDto>(produtos);
    }

    public List<ReadProdutoDto> GetProdutos()
    {
        List<Produtos> produtos;
        produtos = _context.Produtos.ToList();
        if (produtos != null)
        {
            List<ReadProdutoDto> readProdutoDtos = _mapper.Map<List<ReadProdutoDto>>(produtos);
            return readProdutoDtos;
        }

        return null;
    }
    
     
}