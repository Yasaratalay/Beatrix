using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beatrix.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous] // Bütün kurallardan muhaf olmak için. Yetkisi olmayan yerlere bile girebilir.
        public IActionResult Index()
        {
            return View();
        }
    }
}
