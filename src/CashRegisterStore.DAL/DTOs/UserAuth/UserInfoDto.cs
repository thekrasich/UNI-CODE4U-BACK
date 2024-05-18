namespace CashRegisterStore.DAL.DTOs.UserAuth
{
    public class UserInfoDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
    }
}
