using Coffee.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffee.Contracts;
using Coffee.Filters.Exceptions;
using Coffee.Repositories.Interfaces;
using Coffee.Security;
using Coffee.DbEntities;

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
            var user = _userRepository.GetConfirmUsers(x => x.RefreshToken == RefreshToken).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidRefreshTokenException("Invalid refresh token.");
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
        public TokenModelResponse TokenMobile(string phone,string password)
        {
            var user = _userRepository.GetConfirmUsers(x => x.Phone == phone && x.Password == password).FirstOrDefault();

            var identity = _identityService.GetIdentity(user);
            if (identity == null)
            {
                throw new InvalidCredentialsException("Invalid phone or password.");
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

        public void Registration(string phone)
        {
            var user = _userRepository.GetConfirmUsers(item => item.Phone == phone).FirstOrDefault();

            if (user != null)
            {
                throw new InvalidCredentialsException("User with this phone already exist.");
            }

            user = _userRepository.GetNotConfirmUsers(item => item.Phone == phone).FirstOrDefault();

            if (user != null)
            {
                _userRepository.Remove(user);
            }

            user = new User
            {
                Phone = phone,
                Password = "test",
                RefreshToken = Guid.NewGuid().ToString().Replace("-","")
            };

            // TO DO add sending sms

            _userRepository.Create(user);
        }

        public void ConfirmRegister(string phone)
        {
            var user = _userRepository.GetNotConfirmUsers(item => item.Phone == phone).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidCredentialsException("User with this phone already confirm or incorect confirm parameters.");
            }

            user.IsConfirm = true;

            _userRepository.Update(user);
        }

        public void Password(string phone)
        {
            User user = _userRepository.GetConfirmUsers(item => item.Phone == phone).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidCredentialsException("User with this phone not exist.");
            }

            // TO DO add sending new password by sms

            user.Password = "testNew";
            _userRepository.Update(user);
        }
    }
}
