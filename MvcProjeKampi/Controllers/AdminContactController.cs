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
            ViewBag.SendMessageCount = messageManager.TSendMessageCount();
            ViewBag.ReceivedMessageCount = messageManager.TReceivedMessageCount();
            ViewBag.DraftsCount = messageManager.TDraftsCount();
            ViewBag.DeletedCount = messageManager.TDeletedCount();
            ViewBag.ContactCount = contactManager.TContactCount();
            return PartialView();
        }
    }
}