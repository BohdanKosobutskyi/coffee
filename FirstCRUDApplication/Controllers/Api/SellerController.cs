using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Coffee.Controllers.Api
{
    [Produces("application/json")]
    [Consumes("application/json")]
    public class SellerController : Controller
    {
        /// <summary>
        /// Uplaods an image to the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("api/add/points")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult UploadImage()
        {
            return null;
        }

        [HttpPost("api/add/points/test")]
        [Authorize(AuthenticationSchemes = "test")]
        public IActionResult UploadImageTest()
        {
            return null;
        }
    }
}