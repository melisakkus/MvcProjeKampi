using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminMessageController : Controller
    {
        IMessageService messageService = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        public ActionResult DeleteMessage(int id)
        {
            var values = messageService.GetById(id);
            values.IsDeleted = true;
            messageService.Update(values);
            return RedirectToAction("Inbox");
        }

        public ActionResult Inbox()
        {
            var values = messageService.GetListInbox();
            return View(values);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var value = messageService.GetById(id);
            return View(value);
        }

        public ActionResult Sendbox()
        {
            var values = messageService.GetListSendbox();
            return View(values);
        }
        public ActionResult SendboxMessageDetails(int id)
        {
            var value = messageService.GetById(id);
            return View(value);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var results = validationRules.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = "admin@gmail.com";
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                message.IsDeleted = false;
                message.IsDraft = false;
                messageService.Add(message);
                return RedirectToAction("Sendbox");
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