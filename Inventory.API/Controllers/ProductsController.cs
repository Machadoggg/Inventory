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

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetProducts()
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound($"No se encontró un producto con el ID {id}.");

            return Ok(product);
        }

        [HttpGet("price/{price}")]
        public ActionResult<List<Product>> GetByPriceGreatherThan(decimal price)
        {
            var products = _productService.GetProducts()
                .Where(p => p.Price > price)
                .ToList();

            if (products == null)
                return NotFound($"No se encontraron productos con un precio mayor a: {price}.");

            return Ok(products);

        }
    }
}
