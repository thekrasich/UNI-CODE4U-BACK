using Microsoft.AspNetCore.Identity;

namespace CashRegisterStore.DAL.Data.Entities
{
    public class User : IdentityUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }       
        public string Role { get; set; }
    }
}