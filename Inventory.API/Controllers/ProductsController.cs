﻿using Inventory.Application.Interfaces;
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
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategoryAsync(string category)
        {
            var products = await _productService.GetProductsByCategoryAsync(category);

            if (products.Count == 0)
            {
                return NotFound($"No se encontraron productos en la categoría '{category}'.");
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetProductsById(id);

            if (product == null)
                return NotFound($"No se encontró un producto con el ID {id}.");

            return Ok(product);
        }

        [HttpGet("price/{price}")]
        public ActionResult<List<Product>> GetByPriceGreatherThan(decimal price)
        {
            var products = _productService.GetProductsByPriceGreatherThan(price);

            if (products == null)
                return NotFound($"No se encontraron productos con un precio mayor a: {price}.");

            return Ok(products);

        }
    }
}
