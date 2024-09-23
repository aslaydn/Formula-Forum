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
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var contactvalues = contactManager.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id) 
        {
            var contactvalues = contactManager.GetByID(id);
            return View(contactvalues);
        }

        public PartialViewResult MessageListMenu()
        {
            string session = (string)Session["AdminUserName"];

            var contact = contactManager.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = messageManager.GetListSendbox(session).Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = messageManager.GetListInbox(session).Count();
            ViewBag.receiverMail = receiverMail;
            return PartialView();
        }

        [HttpGet, AllowAnonymous]
        public ActionResult NewContact()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult NewContact(Contact contact)
        {
            ValidationResult validationResult = contactValidator.Validate(contact);
            if (validationResult.IsValid)
            {
                contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contactManager.ContactAddBL(contact);
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();

        }
    }
}