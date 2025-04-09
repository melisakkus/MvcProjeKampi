using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json.Linq;
using System.Net;
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

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("HeadingsDefaultLayout", "Default");
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
            var response = Request["g-recaptcha-response"];
            const string secret = "6LfSIxErAAAAAMa1OKC5GPsfSre3woi1-t2NLneR";
            using (var client = new WebClient())
            {
                var result = client.DownloadString(
                    $"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={response}"
                );
                var obj = JObject.Parse(result);
                var status = (bool)obj["success"];

                if (!status)
                {
                    ViewBag.ErrorMessage = "Lütfen robot olmadığınızı doğrulayın.";
                    return View();
                }
            }

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
            var response = Request["g-recaptcha-response"];
            const string secret = "6LfSIxErAAAAAMa1OKC5GPsfSre3woi1-t2NLneR";
            using (var client = new WebClient())
            {
                var result2 = client.DownloadString(
                    $"https://www.google.com/recaptcha/api/siteverify?secret={secret}&response={response}"
                );
                var obj = JObject.Parse(result2);
                var status = (bool)obj["success"];

                if (!status)
                {
                    ViewBag.ErrorMessage = "Lütfen robot olmadığınızı doğrulayın.";
                    return View();
                }
            }

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