namespace Inventory.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } = default!;
    }
}
