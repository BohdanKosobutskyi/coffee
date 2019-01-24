using Coffee.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffee.Contracts;
using Coffee.Filters.Exceptions;
using Coffee.Repositories.Interfaces;
using Coffee.Security;

namespace Coffee.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private ISecurityService _securityService;
        private ISellerRepository _sellerRepository;
        private IIdentityService _identityService;

        public AuthService(IUserRepository userRepository,
            ISecurityService securityService,
            ISellerRepository sellerRepository,
            IIdentityService identityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
            _sellerRepository = sellerRepository;
            _identityService = identityService;
        }

        public TokenModelResponse RefreshToken(string RefreshToken)
        {
            var user = _userRepository.Get(x => x.RefreshToken == RefreshToken && x.IsConfirm).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidRefreshTokenException();
            }

            user.RefreshToken = Guid.NewGuid().ToString().Replace("-","");
            _userRepository.Update(user);

            return new TokenModelResponse
            {
                access_token = _securityService.GenerateToken(user),
                refresh_token = user.RefreshToken,
                expire_time = DateTime.UtcNow.AddMinutes(AuthOptions.LIFETIME)
            };
        }

        public TokenModelResponse TokenWeb(string email, string password)
        {
            var seller = _sellerRepository.Get(x => x.Email == email && x.Password == password).FirstOrDefault();

            var identity = _identityService.GetIdentity(seller);
            if (identity == null)
            {
                throw new InvalidCredentialsException("Invalid email or password.");
            }

            seller.RefreshToken = Guid.NewGuid().ToString().Replace("-","");
            _sellerRepository.Update(seller);

            return new TokenModelResponse
            {
                access_token = _securityService.GenerateToken(seller),
                refresh_token = seller.RefreshToken,
                expire_time = DateTime.UtcNow.AddMinutes(AuthOptions.LIFETIME)
            };
        }
    }
}
