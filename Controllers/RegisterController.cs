using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormulaForum.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator validator = new WriterValidator();

        [HttpPost]
        public ActionResult Register(Writer p)
        {
            ValidationResult validationResult = validator.Validate(p);
            if (validationResult.IsValid)
            {
                writerManager.WriterAdd(p);
                return RedirectToAction("WriterProfile", "WriterPanel");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("HomePage", "Home");
        }
    }
}