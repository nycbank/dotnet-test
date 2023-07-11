using AutoMapper;
using dotnet_test.Data;
using dotnet_test.Data.Dtos.CategoriaDto;
using dotnet_test.Data.Dtos.ProdutoDto;
using dotnet_test.Models;
using FluentResults;

namespace dotnet_test.Services;

public class CategoriaService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CategoriaService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadCategoriaDto PostCategoria(CreateCategoriaDto categoriaDto)
    {
        Categorias categorias = _mapper.Map<Categorias>(categoriaDto);
        _context.Categorias.Add(categorias);
        _context.SaveChanges();
        return _mapper.Map<ReadCategoriaDto>(categorias);
    }

    public List<ReadCategoriaDto> GetCategorias()
    {
        List<Categorias> categoriasList;
        categoriasList = _context.Categorias.ToList();
        if (categoriasList != null)
        {
            List<ReadCategoriaDto> readCategoriaDtos = _mapper.Map<List<ReadCategoriaDto>>(categoriasList);
            return readCategoriaDtos;
        }

        return null;
    }

    public ReadCategoriaDto GetCategoriaById(int id)
    {
        Categorias categorias = _context.Categorias.FirstOrDefault(p => p.id == id);
        if (categorias != null)
        {
            ReadCategoriaDto result = _mapper.Map<ReadCategoriaDto>(categorias);
            return result;
        }

        return null;
    }

    public Result UpdateCategoria(UpdateCategoriaDto categoriaDto)
    {
        Categorias categorias = _context.Categorias.FirstOrDefault(p => p.id == categoriaDto.id);
        if(categorias == null)
            return Result.Fail("Not Found");
        _mapper.Map(categoriaDto, categorias);
        _context.SaveChanges();
        return Result.Ok();
    }

    public Result DeleteCategoria(int id)
    {
        Categorias categorias = _context.Categorias.FirstOrDefault(p => p.id == id);
        if(categorias == null)
            return Result.Fail("Not Found");
        _context.Categorias.Remove(categorias);
        _context.SaveChanges();
        return Result.Ok();
    }
}