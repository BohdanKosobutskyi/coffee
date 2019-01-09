using Coffee.Security;
using Coffee.Services.Interfaces;
using FirstCRUDApplication.DbEntities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Services
{
    public class WebSecurityService : ISecurityService
    {
        private IIdentityService _identityService;

        public WebSecurityService(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public string GenerateToken(BaseEntity user)
        {
            var identity = _identityService.GetIdentity(user);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha512));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
