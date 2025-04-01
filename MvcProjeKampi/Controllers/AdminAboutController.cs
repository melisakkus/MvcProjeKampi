using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminAboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var values = aboutManager.GetList();
            return View(values);
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AboutAddBL(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ActiveAbout(int id)
        {
            var aboutValue = aboutManager.GetById(id);
            aboutValue.IsActive = true;
            aboutManager.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult PassiveAbout(int id)
        {
            var aboutValue = aboutManager.GetById(id);
            aboutValue.IsActive = false;
            aboutManager.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAbout(int id)
        {
            var aboutValue = aboutManager.GetById(id);
            return View(aboutValue);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            aboutManager.AboutUpdate(about);
            return RedirectToAction("Index");
        }
    }
}