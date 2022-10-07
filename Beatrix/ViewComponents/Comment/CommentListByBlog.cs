using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Beatrix.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            var values = cm.GetList(id);
            if (values.Count == 0)
            {
                ViewBag.message = "İlk yorumu siz bırakın.";
            }
            else
            {
                ViewBag.message = "Yorumlar";
            }
            return View(values);
        }
    }
}
