using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        IContentService contentManager = new ContentManager(new EfContentDal());
        IWriterService writerService = new WriterManager(new EfWriterDal());

        public ActionResult MyContent()
        {
            string parametre = (string)Session["WriterMail"];
            var writergetbymail = writerService.GetWriterByMail(parametre);
            int id = writergetbymail.WriterId;
            var contents = contentManager.GetListByWriter(id);
            return View(contents);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content newContent)
        {
            string parametre = (string)Session["WriterMail"];
            var writergetbymail = writerService.GetWriterByMail(parametre);            
            newContent.WriterId = writergetbymail.WriterId;
            newContent.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            newContent.ContentStatus = true;
            contentManager.ContentAddBL(newContent);
            return RedirectToAction("MyContent");

        }
    }
}