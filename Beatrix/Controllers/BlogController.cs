using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beatrix.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }

        // Yazara göre blog listesi
        public IActionResult BlogListByWriter()
        {
            var values = bm.GetListWithCategoryByWriterBlogManager(1);
            return View(values);
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            // Dropdown içine category deki bilgileri yazdırdık. Text gözüken değer, value veritabanındaki id değeri.
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryValue;
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p) // Yeni blog ekleme.
        {
            BlogValidator bv = new BlogValidator(); // validasyon kontrolleri.
            ValidationResult results = bv.Validate(p);
            //Dropdown a kategorideki bilgileri getirmek için.
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryValue;
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
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

        public IActionResult DeleteBlog(int id) // id ye göre silme.
        {
            var blogValue = bm.TGetById(id); // silinecek veriyi bulma
            bm.TDelete(blogValue); // gönderdiğimiz id ye karşılık gelen veriyi sil
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet] // Sayfa yüklendiği zaman verileri getir
        public IActionResult UpdateBlog(int id)
        {
            var blogValue = bm.TGetById(id);
            //CategoryName leri dropdown olarak getiriyor
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryValue;
            return View(blogValue);
        }

        [HttpPost] // Post olduğu zaman çalışacak
        public IActionResult UpdateBlog(Blog b) // aynı isimde bir başka action varsa parametre almalı.
        {
            b.WriterId = 1;
            b.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            b.BlogStatus = true;
            bm.TUpdate(b);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
