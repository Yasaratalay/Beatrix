using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Beatrix.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            Context c = new Context();
            ViewBag.value1 = c.Blogs.Count().ToString();
            ViewBag.value2 = c.Blogs.Where(x => x.WriterId == 1).Count();
            ViewBag.value3 = c.Categories.Count();
            return View();
        }
    }
}
