using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Coffee.Handler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers.Api
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ImageController : Controller
    {
        private readonly IImageHandler _imageHandler;

        public ImageController(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }

        /// <summary>
        /// Uplaods an image to the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("api/mobile/image/upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            return await _imageHandler.UploadImage(file);
        }
    }
}