using CadastroProdutos.Domain.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Interface.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int productId);
    }
}
