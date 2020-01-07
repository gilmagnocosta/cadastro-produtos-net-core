using CadastroProdutos.Application.ViewModel;
using CadastroProdutos.Domain.Entity;
using CadastroProdutos.Settings;

namespace SmartCheck.Application.Mapping
{
    public class DomainToModelProfile : AutoMapper.Profile
    {
        public DomainToModelProfile()
        {
            CreateMap<Product, ProductViewModel>().AfterMap((viewModel, dest) =>
            {
                dest.ImageURL = string.Format("{0}/api/products/{1}/image", AppHttpHelper.AppBaseUrl, viewModel.Id);
            });
        }
    }
}
