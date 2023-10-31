using AutoMapper;
using NycbankAPI.Data.Dto;

namespace NycbankAPI.Profiles
{
    public class CategoriaProdutos : Profile
    {

        public CategoriaProdutos()
        {
            CreateMap<CreateCategoriaProdutosDto, CategoriaProdutos>();
            CreateMap<CategoriaProdutos,ReadCategoriaProdutosDto>();
        }
    }
}
