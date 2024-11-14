using Inventory.Domain.Entities;
using System.Text.Json;

namespace Inventory.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private readonly string _filePath = "C:\\ProjectsDEV\\Inventory\\Inventory.Infrastructure\\Data\\inventory.json";

        public ProductRepository(string filePath)
        {
            _filePath = filePath;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            if (!File.Exists(_filePath))
                return new List<Product>();

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public async Task<List<Product>> GetProductsByCategoryAsync(string category)
        {
            var products = await GetAllProductsAsync();
            return products.Where(p => p.Category == category)
                .ToList();
        }

        public Product? GetProductsById(int id)
        {
            var product = GetAllProducts();
            return product.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductsByPriceGreatherThan(decimal price)
        {
            var products = GetAllProducts().Where(p => p.Price > price).ToList();
            return products;
        }
    }
}
