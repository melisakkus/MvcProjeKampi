using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator validationRules = new ContactValidator();
        public ActionResult Index()
        {            
            var values = contactManager.GetList();
            return View(values);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contact = contactManager.GetContactById(id);
            return View(contact);
        }

        public PartialViewResult OptionsSidebar()
        {
            string sessionMail = (string)Session["WriterMail"];
            ViewBag.SendMessageCount = messageManager.TSendMessageCount(sessionMail);
            ViewBag.ReceivedMessageCount = messageManager.TReceivedMessageCount(sessionMail);
            ViewBag.DraftsCount = messageManager.TDraftsCount(sessionMail);
            ViewBag.DeletedCount = messageManager.TDeletedCount(sessionMail);
            ViewBag.ContactCount = contactManager.TContactCount();
            return PartialView();
        }
    }
}