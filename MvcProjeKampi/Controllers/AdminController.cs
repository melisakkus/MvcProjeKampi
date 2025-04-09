using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminController : Controller
    {
        IAdminService adminManager = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            var values = adminManager.TAdminList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddNewAdmin()
        {
            ViewBag.Roles = new SelectList(
                new List<SelectListItem>
                {
            new SelectListItem { Text = "A", Value = "A" },
            new SelectListItem { Text = "B", Value = "B" },
                }, "Value", "Text");

            return View();
        }

        [HttpPost]
        public ActionResult AddNewAdmin(Admin newAdmin)
        {
            if (ModelState.IsValid)
            {
                newAdmin.AdminPassword = adminManager.THashNewPassword(newAdmin.AdminPassword);
                adminManager.TAddAdmin(newAdmin);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doldurun.");
            }
            return View(newAdmin);
        }

        public ActionResult MakeAdminRoleA(int id)
        {
            var admin = adminManager.TGetAdmin(id);
            admin.AdminRole = "A";
            adminManager.TUpdateAdmin(admin);
            return RedirectToAction("Index");
        }

        public ActionResult MakeAdminRoleB(int id)
        {
            var admin = adminManager.TGetAdmin(id);
            admin.AdminRole = "B";
            adminManager.TUpdateAdmin(admin);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAdmin(int id)
        {
            ViewBag.Roles = new SelectList(
               new List<SelectListItem>
               {
            new SelectListItem { Text = "A", Value = "A" },
            new SelectListItem { Text = "B", Value = "B" },
               }, "Value", "Text");
            var admin = adminManager.TGetAdmin(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin updateAdmin)
        {
            if (ModelState.IsValid)
            {
                adminManager.TUpdateAdmin(updateAdmin);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doldurun.");
            }
            return View(updateAdmin);
        }




        // tek seferlik kullanım için
        public ActionResult HashExistingPassword()
        {
            adminManager.THashExistingPassword();
            return Content("Tüm şifreler başarıyla hash'lendi!");
        }
    }
}