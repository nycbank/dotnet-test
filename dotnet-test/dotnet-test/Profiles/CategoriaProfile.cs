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
        CreateMap<Categorias, ReadCategoriaDto>();
    }
}