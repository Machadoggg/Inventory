using Inventory.Domain.Entities;
using System.Text.Json;

namespace Inventory.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private readonly string _filePath = "C:\\ProjectsDEV\\Inventory\\Inventory.Infrastructure\\Data\\inventory.json";

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

        public async Task<Product?> GetProductsByIdAsync(int id)
        {
            var product = await GetAllProductsAsync();
            return product.FirstOrDefault(p => p.Id == id);
        }

        public async Task<List<Product>> GetPriceGreatherThanAsync(decimal price)
        {
            var products = await GetAllProductsAsync();
            return products.Where(p => p.Price > price).ToList();
        }
    }
}
