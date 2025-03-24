using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminContentController : Controller
    {
        IContentService contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int headingId)
        {
            var contents = contentManager.GetListByHeadingId(headingId);
            return View(contents);
        }

    }
}