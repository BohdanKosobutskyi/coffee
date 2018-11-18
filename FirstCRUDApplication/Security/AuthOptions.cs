using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Coffee.Security
{
    public class AuthOptions
    {
        public const string ISSUER = "http://localhost:58114/"; // издатель токена
        public const string AUDIENCE = "test"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123test";   // ключ для шифрации
        public const int LIFETIME = 360; // время жизни токена - 6 минут
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
