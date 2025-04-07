using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules_Fluent;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ICategoryService _categoryManager = new CategoryManager(new EfCategoryDal());
        IWriterService _writerManager = new WriterManager(new EfWriterDal());
        WriterValidator validator = new WriterValidator();

        public ActionResult WriterProfile()
        {
            var writer = _writerManager.GetWriterByMail((string)Session["WriterMail"]);
            ViewBag.writerId = writer.WriterId;
            return View(writer);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            var results = validator.Validate(writer);
            if (results.IsValid)
            {

                _writerManager.WriterUpdate(writer);
                return RedirectToAction("MyHeading");
            }
            else
            {
                foreach (var error in results.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(writer);
            }
        }



        #region Headings
        public ActionResult MyHeading()
        {
            var sessionValue = (string)Session["WriterMail"];
            var writerId = _writerManager.GetWriterByMail(sessionValue).WriterId;
            var values = headingManager.GetListByWriter(writerId);
            return View(values);
        }

        public ActionResult AllHeading(int p = 1)
        {
            var headings = headingManager.GetList().ToPagedList(p,5);
            return View(headings);
        }

        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var sessionValue = (string)Session["WriterMail"];
            heading.WriterId = _writerManager.GetWriterByMail(sessionValue).WriterId;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;
            var heading = headingManager.GetById(id);
            return View(heading);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            var sessionValue = (string)Session["WriterMail"];
            heading.WriterId = _writerManager.GetWriterByMail(sessionValue).WriterId;
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var heading = headingManager.GetById(id);
            heading.HeadingStatus = false;
            headingManager.HeadingDelete(heading);
            return RedirectToAction("MyHeading");
        }
        #endregion

    }
}