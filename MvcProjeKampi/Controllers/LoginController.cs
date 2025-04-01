using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        IAdminService adminManager = new AdminManager(new EfAdminDal());
        LoginValidator loginValidator = new LoginValidator();

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var results = loginValidator.Validate(admin);
            if (results.IsValid)
            {
                var value = adminManager.TCheckUserNamePassword(admin.AdminUserName, admin.AdminPassword);
                if (value != null)
                {
                    FormsAuthentication.SetAuthCookie(value.AdminUserName,false);
                    Session["AdminUserName"] = value.AdminUserName;
                    return RedirectToAction("Index", "AdminCategory");
                }
                ModelState.AddModelError("AdminPassword", "Kullanıcı Adı veya Şifre Hatalı");
                return View(admin);
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(admin);
        }
    }
}