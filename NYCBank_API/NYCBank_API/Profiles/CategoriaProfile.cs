using System;
using AutoMapper;
using NYCBank_API.Data.DTOs;
using NYCBank_API.Models;

namespace NYCBank_API.Profiles;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CreateCategoriaDTO, Categoria>();
        CreateMap<UpdateCategoriaDTO, Categoria>();
        CreateMap<Categoria, UpdateCategoriaDTO>();
        CreateMap<Categoria, ReadCategoriaDTO>();
    }


}

