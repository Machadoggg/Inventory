﻿using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;

namespace Inventory.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}