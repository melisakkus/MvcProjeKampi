using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules_Fluent;
using DataAccessLayer.EntityFramework;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminMessageTrashController : Controller
    {
        IMessageService messageService = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();
        
        public ActionResult Index()
        {
            string sessionMail = (string)Session["WriterMail"];
            var values = messageService.GetListDeleteds(sessionMail);
            return View(values);
        }
    }
}