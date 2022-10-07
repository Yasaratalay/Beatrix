using Microsoft.AspNetCore.Mvc;

namespace Beatrix.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code) // startup.cs içinde tanımlandı.
        {

            return View();
        }
    }
}
