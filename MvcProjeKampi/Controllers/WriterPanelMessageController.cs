using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        IMessageService messageService = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        public PartialViewResult OptionsSidebar()
        {
            return PartialView();
        }

        #region Inbox
        public ActionResult Inbox()
        {
            string sessionMail = (string)Session["WriterMail"];
            ViewBag.ReadCount = messageService.TReadCount(sessionMail);
            ViewBag.NotReadCount = messageService.TNotReadCount(sessionMail);
            var values = messageService.GetListInbox(sessionMail);
            return View(values);
        }
        public ActionResult InboxMessageRead(int id)
        {
            var value = messageService.GetById(id);
            value.IsRead = true;
            messageService.Update(value);
            return RedirectToAction("Inbox");
        }

        public ActionResult InboxMessageNotRead(int id)
        {
            var value = messageService.GetById(id);
            value.IsRead = false;
            messageService.Update(value);
            return RedirectToAction("Inbox");
        }

        public ActionResult GetInBoxMessageDetails(int id)
        {
            var value = messageService.GetById(id);
            return View(value);
        }
        #endregion

        #region Sendbox
        public ActionResult Sendbox()
        {
            string sessionMail = (string)Session["WriterMail"];
            var values = messageService.GetListSendbox(sessionMail);
            return View(values);
        }
        public ActionResult SendboxMessageDetails(int id)
        {
            var value = messageService.GetById(id);
            return View(value);
        }
        #endregion

        #region NewMessage
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var sessionValue = (string)Session["WriterMail"];
            var results = validationRules.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = sessionValue;
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
        #endregion

        #region Drafts
        public ActionResult DraftMessage()
        {
            string sessionMail = (string)Session["WriterMail"];
            var values = messageService.GetListDrafts(sessionMail);
            return View(values);
        }

        [HttpPost]
        public ActionResult NewDraft(Message model)
        {
            model.IsDraft = true;
            model.IsDeleted = false;
            model.MessageDate = DateTime.Now;
            model.SenderMail = (string)Session["WriterMail"];
            messageService.Add(model);
            return RedirectToAction("DraftMessage");
        }

        [HttpGet]
        public ActionResult UpdateDraft(int id)
        {
            var value = messageService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateDraft(Message message)
        {
            var results = validationRules.Validate(message);
            if (results.IsValid)
            {
                message.SenderMail = (string)Session["WriterMail"];
                message.IsDeleted = false;
                message.IsDraft = true;
                message.MessageDate = DateTime.Now;
                messageService.Update(message);
                return RedirectToAction("DraftMessage");
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

        [HttpPost]
        public ActionResult DraftToSend(Message message)
        {
            var results = validationRules.Validate(message);
            if (results.IsValid)
            {
                message.IsDeleted = false;
                message.IsDraft = false;
                message.MessageDate = DateTime.Now;
                message.SenderMail = (string)Session["WriterMail"];
                messageService.Update(message);
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
        #endregion

        public ActionResult TrashMessage()
        {
            var values = messageService.GetListDeleteds((string)Session["WriterMail"]);
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var values = messageService.GetById(id);
            values.IsDeleted = true;
            messageService.Update(values);
            return RedirectToAction("Inbox");
        }

    }
}