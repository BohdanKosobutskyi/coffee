using System;
using System.Linq;
using System.Threading.Tasks;
using Coffee.Models;
using Coffee.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FirstCRUDApplication.DbEntities;
using Coffee.Repositories.Interfaces;
using Coffee.Services.Interfaces;
using Coffee.Contracts;
using Coffee.Contracts.Authorization;
using Coffee.DbEntities;
using Coffee.Code;

namespace Coffee.Controllers.Api
{   
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        private ISellerRepository _sellerRepository;
        private IIdentityService _identityService;
        private ISecurityService _securityService;

        public AccountController(IUserRepository userRepository, 
            ISellerRepository sellerRepository,
            IIdentityService identityService,
            ISecurityService securityService)
        {
            _userRepository = userRepository;
            _sellerRepository = sellerRepository;
            _identityService = identityService;
            _securityService = securityService;
        }

        [HttpGet("/api/mobile/token/{refresh_token}/refresh")]
        public async Task RefreshToken(string refresh_token)
        {
            var user = _userRepository.Get(x => x.RefreshToken == refresh_token && x.IsConfirm).FirstOrDefault();

            if (user == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid refresh token.");
                return;
            }
 
            user.RefreshToken = Guid.NewGuid().ToString().Replace("-", "");
            _userRepository.Update(user);

            var response = new
            {
                access_token = _securityService.GenerateToken(user),
                refresh_token = user.RefreshToken
            };
            
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost("/api/web/token")]
        [ProducesResponseType(200, Type = typeof(TokenModelResponse))]
        public async Task TokenWeb([FromBody] LoginWebModel model)
        {
            var email = model.email;
            var password = model.password;

            var seller = _sellerRepository.Get(x => x.Email == email && x.Password == password).FirstOrDefault();

            var identity = _identityService.GetIdentity(seller);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid email or password.");
                return;
            }

            seller.RefreshToken = Guid.NewGuid().ToString().Replace("-", "");
            _sellerRepository.Update(seller);

            var response = new TokenModelResponse
            {
                access_token = _securityService.GenerateToken(seller),
                refresh_token = seller.RefreshToken,
                expire_time = DateTime.UtcNow.AddMinutes(AuthOptions.LIFETIME)
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }


        [HttpPost("/api/mobile/token")]
        [ProducesResponseType(200, Type = typeof(TokenModelResponse))]
        public async Task Token([FromBody] LoginModel model)
        {
            var phone = model.phone;
            var password = model.password;

            var user = _userRepository.Get(x => x.Phone == phone && x.Password == password && x.IsConfirm).FirstOrDefault();

            var identity = _identityService.GetIdentity(user);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid phone or password.");
                return;
            }

            user.RefreshToken = Guid.NewGuid().ToString().Replace("-", "");
            _userRepository.Update(user);

            var response = new TokenModelResponse
            {
                access_token = _securityService.GenerateToken(user),
                refresh_token = user.RefreshToken,
                expire_time = DateTime.UtcNow.AddMinutes(AuthOptions.LIFETIME)
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost("/api/mobile/register")]
        public async Task Registration([FromBody] RegisterModel model)
        {
            var phone = model.phone;

            var user = _userRepository.Get(item => item.Phone == phone && item.IsConfirm).FirstOrDefault();

            if(user != null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("User with this phone already exist.");
                return;
            }

            user = _userRepository.Get(item => item.Phone == phone && item.IsConfirm == false).FirstOrDefault();

            if(user != null)
            {
                _userRepository.Remove(user);
            }

            user = new User
            {
                Phone = phone,
                Password = "test",
                RefreshToken = Guid.NewGuid().ToString().Replace("-", "")
            };

            // TO DO add sending sms
            
            _userRepository.Create(user);
            
            Response.StatusCode = 200;
            return;
        }

        [HttpPost("/api/mobile/confirm")]
        public async Task ConfirmRegister([FromBody] ConfirmModel model)
        {
            var phone = model.phone;

            var user = _userRepository.Get(item => item.Phone == phone && item.IsConfirm == false).FirstOrDefault();

            if (user == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("User with this phone already confirm or incorect confirm parameters.");
                return;
            }

            user.IsConfirm = true;

            _userRepository.Update(user);

            Response.StatusCode = 200;
            return;
        }

        [HttpPost("/api/mobile/password")]
        public async Task Password([FromBody] PasswordModel model)
        {
            var phone = model.phone;

            User user = _userRepository.Get(item => item.Phone == phone && item.IsConfirm).FirstOrDefault();

            if (user == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("User with this phone not exist.");
                return;
            }

            // TO DO add sending new password by sms

            user.Password = "testNew";
            _userRepository.Update(user);

            Response.StatusCode = 200;
            return;
        }
    }
}