namespace CashRegisterStore.DAL.DTOs
{
    public class ProductDto
    {
        public short SubcategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }
    }
}
