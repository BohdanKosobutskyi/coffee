using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Coffee.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;

namespace Coffee.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return File(System.IO.File.OpenRead(Path.Combine("wwwroot/index.html")), "text/html");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
