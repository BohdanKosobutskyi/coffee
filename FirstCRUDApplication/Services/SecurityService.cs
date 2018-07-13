using System;
using System.IdentityModel.Tokens.Jwt;
using Coffee.Models;
using Coffee.Security;
using Microsoft.IdentityModel.Tokens;
using Coffee.Services.Interfaces;
using System.Security.Claims;
using System.Collections.Generic;

namespace Coffee.Services
{
    public class SecurityService : ISecurityService
    {
        public string GenerateToken(User user)
        {
            var identity = GetIdentity(user);
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

        public ClaimsIdentity GetIdentity(User user)
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
