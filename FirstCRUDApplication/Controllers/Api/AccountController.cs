using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Coffee.Models;
using Coffee.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using FirstCRUDApplication.DbEntities;
using Coffee.Repositories.Interfaces;
using Coffee.Services.Interfaces;

namespace Coffee.Controllers.Api
{
    public class LoginModel
    {
        public string Phone { get; set; }
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        public string Phone { get; set; }
    }

    public class PasswordModel
    {
        public string Phone { get; set; }
    }



    public class AccountController : Controller
    {
        private CoffeeContext context;
        private IUserRepository _userRepository;
        private ISecurityService _securityService;

        public AccountController(CoffeeContext context, IUserRepository userRepository)
        {
            this.context = context;
            _userRepository = userRepository;
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
        public async Task Token([FromBody] LoginModel model)
        {
            var phone = model.Phone;
            var password = model.Password;

            User user = _userRepository.Get(x => x.Phone == phone && x.Password == password).FirstOrDefault();

            var identity = _securityService.GetIdentity(user);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid phone or password.");
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

        [HttpPost("/register")]
        public async Task Registration([FromBody] RegisterModel model)
        {
            var phone = model.Phone;

            User user = _userRepository.Get(item => item.Phone == phone).FirstOrDefault();

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
                RefreshToken = Guid.NewGuid().ToString().Replace("-", ""),
                AddedDate = DateTime.Now
            };
            
            _userRepository.Create(user);
            
            Response.StatusCode = 200;
            return;
        }

        [HttpPost("/password")]
        public async Task Password([FromBody] PasswordModel model)
        {
            var phone = model.Phone;

            User user = _userRepository.Get(item => item.Phone == phone).FirstOrDefault();

            if (user == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("User with this phone not exist.");
                return;
            }

            user.Password = "test";
            _userRepository.Update(user);

            Response.StatusCode = 200;
            return;
        }
    }
}