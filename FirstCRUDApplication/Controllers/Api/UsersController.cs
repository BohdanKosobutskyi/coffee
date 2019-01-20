using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Coffee.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Coffee.Controllers.Api
{
    [Produces("application/json")]
    [Consumes("application/json")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("api/web/users/all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserViewModel>))]
        public async Task Users()
        {
            var response = _userRepository.Get().Select(x => new UserViewModel
            {
                user_id = x.Id,
                password = x.Password,
                phone = x.Phone,
                register_date = x.AddedDate,
                is_confirmed = x.IsConfirm
            });

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost("/api/web/user/delete")]
        public async Task Delete([FromBody] UserDeleteView user)
        {
            var userId = user.user_id;

            var userDb = _userRepository.Get(item => item.Id == userId).FirstOrDefault();

            if (userDb == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Company with this parameters not exist.");
                return;
            }

            _userRepository.Remove(userDb);

            Response.StatusCode = 200;
            return;
        }
    }

    public class UserViewModel
    {
        public long user_id { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public DateTime register_date { get; set; }
        public bool is_confirmed { get; set; }
    }

    public class UserDeleteView
    {
        public long user_id { get; set; }
    }
}