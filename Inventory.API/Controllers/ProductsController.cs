﻿using Inventory.API.Generic;
using Inventory.Application.DTOs;
using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("paginated")]
        public async Task<ActionResult<PaginatedResult<Product>>> GetPaginated(int page = 1, int pageSize = 10)
        {
            var products = await _productService.GetAllProductsAsync();
            var paginatedResult = new PaginatedResult<ProductDto>
            {
                Items = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                TotalCount = products.Count
            };
            return Ok(paginatedResult);
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategory(string category)
        {
            var products = await _productService.GetProductsByCategoryAsync(category);

            if (products.Count == 0)
            {
                return NotFound($"No se encontraron productos en la categoría '{category}'.");
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _productService.GetProductsByIdAsync(id);

            if (product == null)
                return NotFound($"No se encontró un producto con el ID {id}.");

            return Ok(product);
        }

        [HttpGet("price/{price}")]
        public async Task<ActionResult<List<Product>>> GetPriceGreatherThan(decimal price)
        {
            var products = await _productService.GetPriceGreatherThanAsync(price);

            if (products == null)
                return NotFound($"No se encontraron productos con un precio mayor a: {price}.");

            return Ok(products);

        }
    }
}
