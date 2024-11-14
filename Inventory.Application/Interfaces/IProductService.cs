using Inventory.Domain.Entities;

namespace Inventory.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        List<Product> GetProductsByCategory(string category);
        Product GetProductsById(int id);
        List<Product> GetProductsByPriceGreatherThan(decimal price);
    }
}
