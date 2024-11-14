﻿using Inventory.Application.Interfaces;
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

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            return await _productRepository.GetProductsByCategoryAsync(category);
        }

        public async Task<Product?> GetProductsByIdAsync(int id)
        {
            return await _productRepository.GetProductsByIdAsync(id);
        }

        public List<Product> GetProductsByPriceGreatherThan(decimal price)
        {
            return _productRepository.GetProductsByPriceGreatherThan(price);
        }
    }
}
