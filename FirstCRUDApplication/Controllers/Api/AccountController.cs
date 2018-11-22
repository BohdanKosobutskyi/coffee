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

namespace Coffee.Controllers.Api
{   
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AccountController : Controller
    {
        private IUserRepository _userRepository;
        private ISecurityService _securityService;

        public AccountController(IUserRepository userRepository, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
        }

        [HttpGet("/token/{refresh_token}/refresh")]
        public async Task RefreshToken(string refresh_token)
        {
            var user = _userRepository.Get(x => x.RefreshToken == refresh_token).FirstOrDefault();

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

        [HttpPost("/token")]
        [ProducesResponseType(200, Type = typeof(TokenModelResponse))]
        public async Task Token([FromBody] LoginModel model)
        {
            var phone = model.phone;
            var password = model.password;

            var user = _userRepository.Get(x => x.Phone == phone && x.Password == password).FirstOrDefault();

            var identity = _securityService.GetIdentity(user);
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
                expire_time = DateTime.UtcNow.AddSeconds(AuthOptions.LIFETIME)
            };

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost("/register")]
        public async Task Registration([FromBody] RegisterModel model)
        {
            var phone = model.phone;

            var user = _userRepository.Get(item => item.Phone == phone).FirstOrDefault();

            if(user != null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("User with this phone already exist.");
                return;
            }

            user = new User
            {
                Phone = phone,
                Password = "test",
                RefreshToken = Guid.NewGuid().ToString().Replace("-", "")
            };
            
            _userRepository.Create(user);
            
            Response.StatusCode = 200;
            return;
        }
    }
}