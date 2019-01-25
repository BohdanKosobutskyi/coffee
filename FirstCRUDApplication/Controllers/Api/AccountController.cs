using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Coffee.Repositories.Interfaces;
using Coffee.Services.Interfaces;
using Coffee.Contracts;
using Coffee.Contracts.Authorization;

namespace Coffee.Controllers.Api
{   
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AccountController : Controller
    {
        private IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("/api/mobile/token/{refresh_token}/refresh")]
        public async Task RefreshToken(string refresh_token)
        {
            var response = _authService.RefreshToken(refresh_token);

            Response.ContentType = "application/json";

            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost("/api/web/token")]
        [ProducesResponseType(200, Type = typeof(TokenModelResponse))]
        public async Task TokenWeb([FromBody] LoginWebModel model)
        {
            var response = _authService.TokenWeb(model.email, model.password);

            Response.ContentType = "application/json";

            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }


        [HttpPost("/api/mobile/token")]
        [ProducesResponseType(200, Type = typeof(TokenModelResponse))]
        public async Task TokenMobile([FromBody] LoginModel model)
        {
            var response = _authService.TokenMobile(model.phone,model.password);

            Response.ContentType = "application/json";

            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost("/api/mobile/register")]
        public void Registration([FromBody] RegisterModel model)
        {
            _authService.Registration(model.phone);

            Response.StatusCode = 200;

            return;
        }

        [HttpPost("/api/mobile/confirm")]
        public void ConfirmRegister([FromBody] ConfirmModel model)
        {
            _authService.ConfirmRegister(model.phone);

            Response.StatusCode = 200;

            return;
        }

        [HttpPost("/api/mobile/password")]
        public void Password([FromBody] PasswordModel model)
        {
            _authService.Password(model.phone);

            Response.StatusCode = 200;

            return;
        }
    }
}