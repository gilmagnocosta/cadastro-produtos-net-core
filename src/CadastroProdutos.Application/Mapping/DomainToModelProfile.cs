using CadastroProdutos.Application.ViewModel;
using CadastroProdutos.Domain.Entity;
using CadastroProdutos.Settings;

namespace SmartCheck.Application.Mapping
{
    public class DomainToModelProfile : AutoMapper.Profile
    {
        public DomainToModelProfile()
        {
            CreateMap<AttractionCategory, AttractionCategoryViewModel>();
            CreateMap<Archive, ArchiveViewModel>().AfterMap((viewModel, dest) => {
                dest.Url = string.Format("{0}/api/archives/view-original/{1}", AppHttpHelper.AppBaseUrl, viewModel.Id);
                dest.Thumbnail = new ThumbnailViewModel()
                {
                    Mobile = string.Format("{0}/api/archives/view-thumbnail/{1}/mobile", AppHttpHelper.AppBaseUrl, viewModel.Id),
                    Web = string.Format("{0}/api/archives/view-thumbnail/{1}/web", AppHttpHelper.AppBaseUrl, viewModel.Id)
                };
                });
            CreateMap<Attraction, ProductViewModel>();
            CreateMap<Booking, BookingViewModel>();
            CreateMap<Contact, ContactViewModel>();
            CreateMap<Product, PersonViewModel>();
            CreateMap<User, UserViewModel>();
        }
    }
}
