using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Beatrix.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous] // Bütün kurallardan muhaf olmak için. Yetkisi olmayan yerlere bile girebilir.
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous] // Yetkisi olmasa bile bu controller çalışsın indexe gitsin.
        public async Task<IActionResult> Index(Writer writer)
        {
            // Giriş yaptıktan sonra diğer sayfalara geçiş yapabilmek için. Yoksa sürekli Login ekranına geri gönderir.
            Context c = new Context();
            var dataValue = c.Writers.FirstOrDefault(x => x.WriterEmail == writer.WriterEmail && x.WriterPassword == writer.WriterPassword);

            if (dataValue != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,writer.WriterEmail)
                };
                var userIdentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Blog");
            }
            else
            {
                return View();
            }
        }
    }
}
//Context c = new Context();
////Form üzerinde girilen Email ve Password bilgisini alıp sessiona gönderiyor.
//var dataValue = c.Writers.FirstOrDefault(x => x.WriterEmail == writer.WriterEmail && x.WriterPassword == writer.WriterPassword);

//if (dataValue != null)
//{
//    HttpContext.Session.SetString("username", writer.WriterEmail); //Başarılı ise sayfaya yönlendir.
//    return RedirectToAction("Index", "Writer");
//}
//else
//{
//    return View(); // Hatalı durumda boş view döndür.
//}