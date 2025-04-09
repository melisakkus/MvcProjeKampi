using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal()); 

        public ActionResult Index(int p=1)
        {
            var values = categoryManager.GetList().ToPagedList(p,6);
            return View(values);
        }

        public ActionResult HeadingByCategory(int id)
        {
            var values = headingManager.GetListByCategory(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category model)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(model);
            if (result.IsValid)
            {
                categoryManager.CategoryAddBL(model);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError(errors.PropertyName, errors.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = categoryManager.GetById(id);
            categoryManager.RemoveCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = categoryManager.GetById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category model)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(model);
            if (result.IsValid)
            {
                categoryManager.CategoryUpdate(model);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var errors in result.Errors)
                {
                    ModelState.AddModelError(errors.PropertyName, errors.ErrorMessage);
                }
            }
            return View();
        }
    }
}