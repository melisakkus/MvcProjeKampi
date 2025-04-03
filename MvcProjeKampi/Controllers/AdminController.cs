using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminController : Controller
    {
        IAdminService adminManager = new AdminManager(new EfAdminDal());

        [HttpGet] // tek seferlik kullanım için
        public ActionResult HashExistingPassword()
        {
            adminManager.THashExistingPassword();
            return Content("Tüm şifreler başarıyla hash'lendi!");
        }

        [HttpGet]
        public ActionResult AddNewAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewAdmin(Admin newAdmin)
        {
            if (ModelState.IsValid)
            {
                newAdmin.AdminPassword = adminManager.THashNewPassword(newAdmin.AdminPassword);
                adminManager.TAddAdmin(newAdmin);
                return RedirectToAction("AdminLogin", "Login");
            }
            else
            {
                ModelState.AddModelError("", "Lütfen tüm alanları doldurun.");
            }
            return View(newAdmin);
        }
    }
}