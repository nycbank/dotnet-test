using AutoMapper;
using dotnet_test.Data.Dtos.CategoriaDto;
using dotnet_test.Models;

namespace dotnet_test.Profiles;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CreateCategoriaDto, Categorias>();
        CreateMap<UpdateCategoriaDto, Categorias>();
        CreateMap<Categorias, ReadCategoriaDto>()
            .ForMember(p => p.ProdutosList,
                opts => opts.MapFrom(t => t.Produtos.Select(p => new { p.id, p.nome, p.preco })))
            .ForMember(dest => dest.ProdutosList, opt => opt.MapFrom(src => src.Produtos))
            .ReverseMap();
    }
}