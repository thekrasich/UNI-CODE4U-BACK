namespace CashRegisterStore.DAL.Data.Entities
{
    public class Subcategory
    {
        public short Id { get; set; }
        public short CategoryId { get; set; }
        public string Name { get; set; }
    }
}