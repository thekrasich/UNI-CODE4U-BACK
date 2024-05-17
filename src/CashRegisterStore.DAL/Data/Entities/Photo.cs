namespace CashRegisterStore.DAL.Data.Entities
{
    public class Photo
    {
        public long Id { get; set; }
        public int ProductId { get; set; }
        public string Path { get; set; }
    }
}