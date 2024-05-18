using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CashRegisterStore.DAL.Auth
{
    public class AuthOption
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "MyAuthClient";
        const string KEY = "mysupersecret_secrfdsfsdsdfsdfsdfsdfsdfetkey!123";
        public const int LIFETIME = 360;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
