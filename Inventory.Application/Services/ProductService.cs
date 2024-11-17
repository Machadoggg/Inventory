using AutoMapper;
using Inventory.Application.DTOs;
using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Repositories;

namespace Inventory.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<List<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            return await _productRepository.GetProductsByCategoryAsync(category);
        }

        public async Task<Product> GetProductsByIdAsync(int id)
        {
            return await _productRepository.GetProductsByIdAsync(id);
        }

        public async Task<List<Product>> GetPriceGreatherThanAsync(decimal price)
        {
            return await _productRepository.GetPriceGreatherThanAsync(price);
        }
    }
}
