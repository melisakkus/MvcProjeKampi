using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        public ActionResult AdminOrWriterLogin()
        {
            return View();
        }

        #region Admin Login
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
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                    return View(admin);
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı sisteme kayıtlı değil.");
                    return View(admin);
                }
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(admin);
        }
        #endregion

        #region Writer Login

        IWriterService writerService = new WriterManager(new EfWriterDal());
        WriterLoginValidator writervalidator = new WriterLoginValidator();

        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            var result = writervalidator.Validate(writer);
            if (result.IsValid)
            {
                var writerDb = writerService.GetWriterByMail(writer.WriterMail);
                if(writerDb != null)
                {
                    var checkingPassword = writerService.VerifyPassword(writerDb.WriterPassword,writer.WriterPassword);
                    if(checkingPassword == true)
                    {
                        FormsAuthentication.SetAuthCookie(writerDb.WriterMail, false);
                        Session["WriterMail"] = writerDb.WriterMail;
                        Session["WriterNameSurname"] = writerDb.WriterName + " " + writerDb.WriterSurName;
                        Session["WriterImage"] = writerDb.WriterImage;
                        return RedirectToAction("MyHeading", "WriterPanel");
                    }
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı maili sisteme kayıtlı değil.");
                }
            }
            else
            {
               foreach(var errors in result.Errors)
                {
                    ModelState.AddModelError(errors.PropertyName, errors.ErrorMessage);
                }
            }

            return View(writer);
        }

        public ActionResult WriterOldPasswordsHashing() //tek seferlik kullanım
        {
            writerService.HashExistingPassword();
            return RedirectToAction("WriterLogin", "Login");
        }
        #endregion
    }
}