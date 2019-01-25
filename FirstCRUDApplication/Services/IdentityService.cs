using Coffee.Services.Interfaces;
using Coffee.DbEntities;
using System.Collections.Generic;
using System.Security.Claims;

namespace Coffee.Services
{
    public class IdentityService : IIdentityService
    {
        public ClaimsIdentity GetIdentity(BaseEntity user)
        {
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            return null;
        }
    }
}
