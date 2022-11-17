using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Beatrix.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            // Kategorileri de getir blogları da 
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }
    }
}
