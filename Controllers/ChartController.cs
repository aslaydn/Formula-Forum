using DataAccessLayer.Concrete;
using FormulaForum.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace FormulaForum.Controllers
{
    public class ChartController : Controller
    {
        Context context = new Context();
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<Category> BlogList()
        {
            List<Category> ct = new List<Category>();
            ct.Add(new Category()
            {
                CategoryName = "Yazılım Geliştirme",
                CategoryCount = 8
            });
            ct.Add(new Category() 
            {
                CategoryName = "Mobil Cihazlar",
                CategoryCount = 5
            });

            ct.Add(new Category() 
            {
                CategoryName = "Donanım",
                CategoryCount = 10
            });
            return ct;
        }

        public List<Category> CategoryListChart()
        {
            List<Category> categoryClasses = new List<Category>();
            using (var _context = new Context())
            {
                categoryClasses = _context.Categories.Select(x => new Category
                {
                    CategoryName = x.CategoryName,
                    CategoryCount = x.CategoryName.Length
                }).ToList();
            }

            return categoryClasses;
        }
    }

}