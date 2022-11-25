using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beatrix.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager messageManager = new Message2Manager(new EfMessage2Repository());

        [AllowAnonymous]
        public IActionResult InBox() // Gelen Mesajlar
        {
            int id = 2;
            var values = messageManager.GetInboxListByWriter(id);
            return View(values);
        }

        [HttpGet] // Sayfa yüklendiği zaman verileri getir
        [AllowAnonymous]
        public IActionResult MessageDetails(int id)
        {
            var value = messageManager.TGetById(id);
            return View(value);
        }
    }
}
