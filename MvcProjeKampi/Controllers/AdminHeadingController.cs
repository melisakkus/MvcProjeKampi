using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminHeadingController : Controller
    {
        IHeadingService _headingManager = new HeadingManager(new EfHeadingDal());
        ICategoryService _categoryManager = new CategoryManager(new EfCategoryDal());
        IWriterService _writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var values = _headingManager.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in _categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.valueCategory = valueCategory;

            List<SelectListItem> valueWriters = (from writer in _writerManager.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = writer.WriterName + " " + writer.WriterSurName,
                                                     Value = writer.WriterId.ToString()
                                                 }).ToList();
            ViewBag.valueWriters = valueWriters;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingManager.HeadingAdd(heading);
            return RedirectToAction("Index");
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
            var heading = _headingManager.GetById(id);
            return View(heading);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            _headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var heading = _headingManager.GetById(id);
            heading.HeadingStatus = false;
            _headingManager.HeadingDelete(heading);
            return RedirectToAction("Index");
        }
        public ActionResult ActivateHeading(int id)
        {
            var heading = _headingManager.GetById(id);
            heading.HeadingStatus = true;
            _headingManager.HeadingDelete(heading);
            return RedirectToAction("Index");
        }
    }
}