using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormulaForum.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager loginManager = new WriterLoginManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context context = new Context();
            var admininfo = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName &&
                                                          x.AdminPassword == admin.AdminPassword);
            if (admininfo != null)
            {
                FormsAuthentication.SetAuthCookie(admininfo.AdminUserName, false);
                Session["AdminUserName"] = admininfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult WriterLogin() 
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //Context context = new Context();
            //var writerinfo = context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            var writerinfo = loginManager.GetWriter(writer.WriterMail, writer.WriterPassword);
            if (writerinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerinfo.WriterMail, false);
                Session["WriterMail"] = writerinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}