using CadastroProdutos.Domain.Entity;
using CadastroProdutos.Domain.Interface.Repository;
using CadastroProdutos.Domain.Interface.Service;
using CadastroProdutos.Domain.Notifications;
using CadastroProdutos.Domain.Service.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain.Service
{
    public class ProductService : IProductService
    {
        private NotificationContext _notificationContext;
        private readonly IProductRepository _productRepository;

        public ProductService(NotificationContext notificationContext, IProductRepository userRepository)
        {
            _notificationContext = notificationContext;
            _productRepository = userRepository;
        }



        /// <summary>
        /// Adds a product
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <returns></returns>
        public async Task AddAsync(Product product)
        {
            var existingProduct = await _productRepository.FindByAsync(x => x.Name.Equals(product.Name));

            if (existingProduct != null)
            {
                _notificationContext.AddNotification("produto", "Produto já existe");
                return;
            }

            await _productRepository.AddAsync(product);
        }

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="product">Product to update</param>
        /// <returns></returns>
        public async Task UpdateAsync(Product product)
        {
            var existingProduct = await _productRepository.FindByAsync(x => x.Id.Equals(product.Id));

            if (existingProduct == null)
            {
                _notificationContext.AddNotification("produto", "Produto não encontrado");
                return;
            }

            existingProduct.Name = product.Name;
            existingProduct.Value = product.Value;

            _productRepository.Update(product);

            await Task.CompletedTask;
        }

        /// <summary>
        /// Deletes a product
        /// </summary>
        /// <param name="productId">Id of Product to delete</param>
        /// <returns></returns>
        public async Task DeleteAsync(int productId)
        {
            var existingProduct = await _productRepository.FindByAsync(x => x.Id.Equals(productId));

            if (existingProduct == null)
            {
                _notificationContext.AddNotification("produto", "Produto não encontrado");
                return;
            }

            await _productRepository.DeleteAsync(existingProduct);
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.All();
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id">Id of product to get</param>
        /// <returns></returns>
        public async Task<Product> GetById(int id)
        {
            return await _productRepository.FindByAsync(x => x.Id.Equals(id));
        }
    }
}