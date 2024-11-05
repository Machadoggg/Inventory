using Inventory.Domain.Entities;

namespace Inventory.Application.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
