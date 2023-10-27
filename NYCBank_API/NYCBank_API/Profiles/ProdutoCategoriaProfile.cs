using System;
using AutoMapper;
using NYCBank_API.Data.DTOs;
using NYCBank_API.Models;

namespace NYCBank_API.Profiles;

public class ProdutoCategoriaProfile : Profile
{
	public ProdutoCategoriaProfile()
	{
        CreateMap<CreateProdutoCategoriaDTO, ProdutoCategoria>();
        CreateMap<ProdutoCategoria, ReadProdutoCategoriaDTO>();
    }
}

