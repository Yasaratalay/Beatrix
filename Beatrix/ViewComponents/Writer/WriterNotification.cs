using Microsoft.AspNetCore.Mvc;

namespace Beatrix.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
