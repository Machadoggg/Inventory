using Inventory.Domain.Entities;

namespace Inventory.API.Generic
{
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }

        
    }
}
