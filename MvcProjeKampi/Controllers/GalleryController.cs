using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileService imageFile = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var values = imageFile.GetImages();
            return View(values);
        }
    }
}