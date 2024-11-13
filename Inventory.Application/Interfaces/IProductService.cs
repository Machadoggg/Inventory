using Inventory.Domain.Entities;

namespace Inventory.Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProductsByCategory(string category);
        Product GetProductsById(int id);
    }
}
