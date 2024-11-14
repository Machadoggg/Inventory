using Inventory.Domain.Entities;

namespace Inventory.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetProductsByCategoryAsync(string category);
        Task<Product> GetProductsByIdAsync(int id);
        List<Product> GetProductsByPriceGreatherThan(decimal price);
    }
}
