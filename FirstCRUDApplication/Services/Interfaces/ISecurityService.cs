using Coffee.Models;
using System.Security.Claims;

namespace Coffee.Services.Interfaces
{
    public interface ISecurityService
    {
        string GenerateToken(User user);
        ClaimsIdentity GetIdentity(User user);
    }
}
