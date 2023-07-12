using AutoMapper;
using dotnet_test.Data.Dtos.ProdutoDto;
using dotnet_test.Models;

namespace dotnet_test.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreatProdutoDto, Produtos>();
        CreateMap<UpdateProdutoDto, Produtos>();
        CreateMap<Produtos, ReadProdutoDto>()
            .ForMember(c => c.Categorias,
                opts => opts.MapFrom(t => t.Categorias.Select(c => new { c.id, c.nome })))
            .ForMember(dest => dest.Categorias, opt => opt.MapFrom(src => src.Categorias))
            .ReverseMap();
    }
}