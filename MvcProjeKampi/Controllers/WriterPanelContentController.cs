using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    }
}