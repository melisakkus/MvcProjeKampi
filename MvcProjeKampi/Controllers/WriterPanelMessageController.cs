﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    }
}