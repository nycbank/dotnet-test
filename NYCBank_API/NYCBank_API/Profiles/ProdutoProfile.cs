using System;
using AutoMapper;
using NYCBank_API.Data.DTOs;
using NYCBank_API.Models;
namespace NYCBank_API.Profiles;

public class ProdutoProfile : Profile
{
	public ProdutoProfile()
	{
		CreateMap<CreateProdutoDTO, Produto>();
        CreateMap<UpdateProdutoDTO, Produto>();
    }
}

