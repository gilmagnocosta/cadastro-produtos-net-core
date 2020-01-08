using CadastroProdutos.Application.ViewModel;
using CadastroProdutos.Domain.Entity;

namespace SmartCheck.Application.Mapping
{
    public class ModelToDomainProfile : AutoMapper.Profile
    {
        public ModelToDomainProfile()
        {
            CreateMap<ProductViewModel, Product>();
        }
    }
}
