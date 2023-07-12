using AutoMapper;
using dotnet_test.Data;
using dotnet_test.Data.Dtos.CategoriaDto;
using dotnet_test.Data.Dtos.ProdutoDto;
using dotnet_test.Models;
using FluentResults;

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
        var categorias = _context.Categorias.Where(c => c.id == produtoDto.categoriasId).FirstOrDefault();
        produtos.Categorias.Add(categorias);
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


    public ReadProdutoDto GetProdutoById(int id)
    {
        Produtos produtos = _context.Produtos.FirstOrDefault(p => p.id == id);
        var categorias = _context.Produtos
            .Where(p => p.id == id)
            .SelectMany(p => p.Categorias)
            .Take(20)
            .ToList();
        if (produtos != null)
        {
            ReadProdutoDto result = _mapper.Map<ReadProdutoDto>(produtos);
            result.Categorias = categorias;
            return result;
        }

        return null;
    }

    public Result UpdateProduto(UpdateProdutoDto produtoDto)
    {
        Produtos produtos = _context.Produtos.FirstOrDefault(p => p.id == produtoDto.id);
        if (produtos == null)
        {
            return Result.Fail("Not Found");
        }

        _mapper.Map(produtoDto, produtos);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result DeleteProduto(int id)
    {
        Produtos produtos = _context.Produtos.FirstOrDefault(p => p.id == id);
        if(produtos == null)
            return Result.Fail("Not Found");
        _context.Produtos.Remove(produtos);
        _context.SaveChanges();
        return Result.Ok();
    }
}