using CadastroProdutos.Application.ViewModel;
using CadastroProdutos.Domain.Entity;
using CadastroProdutos.Domain.Entity.ValueObjects;

namespace SmartCheck.Application.Mapping
{
    public class ModelToDomainProfile : AutoMapper.Profile
    {
        public ModelToDomainProfile()
        {
            CreateMap<AttractionCategoryViewModel, AttractionCategory>();
            CreateMap<ArchiveViewModel, Archive>();
            CreateMap<ProductViewModel, Attraction>();
            CreateMap<AddressViewModel, Address>();
            CreateMap<BookingViewModel, Booking>();
            CreateMap<ContactViewModel, Contact>();
            
            CreateMap<PersonViewModel, Product>();
            
            
            CreateMap<UserViewModel, User>();
        }
    }
}
