using CadastroProdutos.Domain.Entity;
using CadastroProdutos.Domain.Interface.Repository;
using CadastroProdutos.Infra.Data.Interface;

namespace CadastroProdutos.Infra.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork) { }
    }
}