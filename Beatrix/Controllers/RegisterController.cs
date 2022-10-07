using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Beatrix.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        [HttpGet]
        public IActionResult Index() // Sayfa yüklenince bu Action çalışır
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer writer) // Sayfada buton tetiklenince çalışır
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(writer);
            if (results.IsValid)
            {
                writer.WriterStatus = true;
                writer.WriterAbout = "Deneme Test";
                wm.WriterAdd(writer);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
    }
}
