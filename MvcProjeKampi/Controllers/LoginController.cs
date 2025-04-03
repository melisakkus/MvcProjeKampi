using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.Ajax.Utilities;
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
                var data = adminManager.TGetAdminByUserName(admin.AdminUserName);
                if (data != null)
                {
                    if (adminManager.TVerifyPassword(data.AdminPassword, admin.AdminPassword))
                    {
                        FormsAuthentication.SetAuthCookie(data.AdminUserName, false);
                        Session["AdminUserName"] = data.AdminUserName;
                        return RedirectToAction("Index", "AdminStatistics");
                    }
                    ModelState.AddModelError("AdminPassword", "Kullanıcı Adı veya Şifre Hatalı");
                    return View(admin);
                }                
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(admin);
        }
    }
}