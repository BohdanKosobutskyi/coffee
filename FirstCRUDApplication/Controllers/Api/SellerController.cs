using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Coffee.Controllers.Api
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class SellerController : Controller
    {
        /// <summary>
        /// Uplaods an image to the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        //[HttpPost("api/add/points")]
        //public async Task<IActionResult> UploadImage(long userId, double points)
        //{
        //    return null;
        //}
    }
}