using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Repositories;

namespace Inventory.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _productRepository.GetProductsByCategory(category);
        }

        public Product? GetProductsById(int id)
        {
            return _productRepository.GetProductsById(id);
        }

        public List<Product> GetProductsByPriceGreatherThan(decimal price)
        {
            return _productRepository.GetProductsByPriceGreatherThan(price);
        }
    }
}
