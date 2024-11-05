using Inventory.Domain.Entities;
using System.Text.Json;

namespace Inventory.Infrastructure.Repositories
{
    public class ProductRepository
    {
        private readonly string _filePath = "Data/inventory.json";


        public List<Product> GetAllProducts()
        {
            if (!File.Exists(_filePath))
                return new List<Product>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }
    }
}
