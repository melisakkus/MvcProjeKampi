using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminDraftController : Controller
    {
        IMessageService messageService = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        public ActionResult Index()
        {
            string sessionMail = (string)Session["AdminUserName"];
            var values = messageService.GetListDrafts(sessionMail);
            return View(values);
        }


        [HttpPost]
        public ActionResult NewDraft(Message model)
        {
            model.IsDraft = true;
            model.IsDeleted = false;
            model.MessageDate = DateTime.Now;
            model.SenderMail = (string)Session["AdminUserName"];
            messageService.Add(model);
            return RedirectToAction("Index");
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
                message.IsDeleted = false;
                message.IsDraft = true;
                message.MessageDate = DateTime.Now;
                messageService.Update(message);
                return RedirectToAction("Index");
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
                message.SenderMail = (string)Session["AdminUserName"];
                messageService.Update(message);
                return RedirectToAction("Index");
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