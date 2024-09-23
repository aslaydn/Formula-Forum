using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormulaForum.Controllers
{
    public class StatisticsController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            var categorycount = context.Categories.Count().ToString();
            ViewBag.categorycount = categorycount;

            var totalheadingcount = context.Headings.Count().ToString();
            ViewBag.totalheadingcount = totalheadingcount;

            var totalcontentcount = context.Contents.Count().ToString();
            ViewBag.totalcontentcount = totalcontentcount;

            var totalwritercount = context.Writers.Count().ToString();
            ViewBag.totalwritercount = totalwritercount;

            var totalmessagecount = context.Messages.Count().ToString();
            ViewBag.totalmessagecount = totalmessagecount;

            var categoryid = context.Categories.Select(x => x.CategoryID).Where(x => x.Equals("Yazılım Geliştirme")).FirstOrDefault();
            var headingcount = context.Headings.Count(x => x.CategoryID == categoryid).ToString();
            ViewBag.headingcount = headingcount;

            
            var writerstarta = (from x in context.Writers select x.WriterName.IndexOf("a")).Distinct().Count().ToString();
            ViewBag.writerstarta = writerstarta;

            var value = context.Categories.Where(u => u.CategoryID == context.Headings.GroupBy(x => x.CategoryID).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.value = value;

            var value2 = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.value2 = value2;

            return View();
        }
    }
}