using Inventory.Domain.Entities;

namespace Inventory.Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProductsByCategory(string category);
        List<Product> GetProductsById(int id);
    }
}
