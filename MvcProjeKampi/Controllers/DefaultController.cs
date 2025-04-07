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
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        IHeadingService headingManager = new HeadingManager(new EfHeadingDal());
        IContentService contentManager = new ContentManager(new EfContentDal());
        public ActionResult HeadingsDefaultLayout()
        {
            var values = headingManager.GetList();
            return View(values);
        }

        public PartialViewResult Index(int id = 0)
        {
            var contentList = contentManager.GetListByHeadingId(id);
            return PartialView(contentList);
        }
    }
}