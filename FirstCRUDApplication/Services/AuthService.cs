using Coffee.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffee.Contracts;
using Coffee.Filters.Exceptions;
using Coffee.Repositories.Interfaces;

namespace Coffee.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private ISecurityService _securityService;

        public AuthService(IUserRepository userRepository,
            ISecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
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
                refresh_token = user.RefreshToken
            };
        }
    }
}
