using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using PagedList;
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

        public ActionResult GetAllContent(string parameter, int page=1)
        {
            var contents = contentManager.GetSearchContents(parameter).ToPagedList(page,6);
            return View(contents);
        }


        public ActionResult ContentByHeading(int headingId)
        {
            var contents = contentManager.GetListByHeadingId(headingId);
            return View(contents);
        }

    }
}