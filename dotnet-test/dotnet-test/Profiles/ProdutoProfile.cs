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
        CreateMap<Produtos, ReadProdutoDto>();
    }
}