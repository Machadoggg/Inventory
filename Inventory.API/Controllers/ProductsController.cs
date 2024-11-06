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
        public ActionResult<List<Product>> Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("category/{category}")]
        public ActionResult<List<Product>> GetByCategory(string category)
        {
            var products = _productService.GetProducts()
                .Where(p => p.Category.Equals(category, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (products.Count == 0)
            {
                return NotFound($"No se encontraron productos en la categoría '{category}'.");
            }

            return Ok(products);
        }
    }
}
