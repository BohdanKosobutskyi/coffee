using Coffee.DbEntities;
using Coffee.DbEntities;
using System.Security.Claims;

namespace Coffee.Services.Interfaces
{
    public interface ISecurityService
    {
        string GenerateToken(BaseEntity user);
    }
}
