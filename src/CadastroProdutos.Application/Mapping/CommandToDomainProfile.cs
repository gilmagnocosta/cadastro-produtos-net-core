using AutoMapper;
using CadastroProdutos.Application.Requests;
using CadastroProdutos.Application.ViewModel;
using CadastroProdutos.Domain.Entity;

namespace CadastroProdutos.Application.Mapping
{
    public class CommandToDomainProfile : AutoMapper.Profile
    {
        public CommandToDomainProfile()
        {
            CreateMap<CreateAttractionCategoryRequest, AttractionCategory>();
            CreateMap<CreateAttractionRequest, Attraction>();
            CreateMap<CreateBookingRequest, Booking>();
            CreateMap<CreateUserRequest, User>();
        }
    }
}
