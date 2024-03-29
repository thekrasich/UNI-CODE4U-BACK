namespace DAL.Models
{
    public class OrderProduct
    {
        public long OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
