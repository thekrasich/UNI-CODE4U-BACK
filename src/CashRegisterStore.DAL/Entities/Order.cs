namespace DAL.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime CreationDateTime { get; set; }
        public char Status { get; set; }
    }
}
