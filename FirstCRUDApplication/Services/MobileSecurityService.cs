using System;
using System.IdentityModel.Tokens.Jwt;
using Coffee.Security;
using Microsoft.IdentityModel.Tokens;
using Coffee.Services.Interfaces;
using System.Security.Claims;
using System.Collections.Generic;
using FirstCRUDApplication.DbEntities;

namespace Coffee.Services
{
    public class MobileSecurityService : ISecurityService
    {
        private IIdentityService _identityService;

        public MobileSecurityService(IIdentityService identityService)
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
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
