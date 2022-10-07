using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Beatrix.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public PartialViewResult SubscribeEmail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SubscribeEmail(NewsLetter p)
        {
            p.EmailStatus = true;
            nm.AddNewsLetter(p);
            return PartialView();
        }
    }
}
