using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers.Api
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CompanyController : Controller
    {
    }
}