using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        CategoryManager categoryManager = new CategoryManager();
        public ActionResult GetCategoryList()
        {
            //var categoryValues = categoryManager.GetAllBL();
            return View();
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //categoryManager.CategoryAddBL(p);
            return RedirectToAction("GetCategoryList");
        }
    }
}