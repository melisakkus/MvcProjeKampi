using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminStatisticsController : Controller
    {
        StatisticsManager statisticsManager = new StatisticsManager(new EfStatisticsDal());
        public ActionResult Index()
        {
            ViewBag.categoryCount = statisticsManager.TCategoryCount();
            ViewBag.headingCountWithSoftware = statisticsManager.THeadingCountWithSoftware();
            ViewBag.writerNameCountWithA = statisticsManager.TWriterNameCountWithA();
            ViewBag.maxCategory = statisticsManager.TMaxCategory();
            ViewBag.differenceBtTrueFalseCategory = statisticsManager.TDifferenceBtTrueFalseCategory();
            return View();
        }
        public ActionResult Statistics1()
        {
            return View();
        }

        public ActionResult CategoryListChart()
        {
            return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        }

        public List<StatisticsCategory> CategoryList()
        {
            return statisticsManager.TCategoryList();
        }

        public ActionResult Statistics2()
        {
            return View();
        }

        public ActionResult WriterContentChart()
        {
            return Json(WriterContentList(), JsonRequestBehavior.AllowGet);
        }

        public List<StatisticsWriter> WriterContentList()
        {
            return statisticsManager.TWriterContentList();
        }


        #region Statik Grafik
        //public ActionResult CategoryChart()
        //{
        //    return Json(BlogList(), JsonRequestBehavior.AllowGet);
        //}

        //public List<CategoryClass> BlogList()
        //{
        //    List<CategoryClass> categoryClasses = new List<CategoryClass>();
        //    categoryClasses.Add(new CategoryClass()
        //    {
        //        CategoryName = "Yazılım",
        //        CategoryCount = 8
        //    });
        //    categoryClasses.Add(new CategoryClass()
        //    {
        //        CategoryName = "Seyahat",
        //        CategoryCount = 4
        //    });
        //    categoryClasses.Add(new CategoryClass()
        //    {
        //        CategoryName = "Teknoloji",
        //        CategoryCount = 7
        //    });
        //    categoryClasses.Add(new CategoryClass()
        //    {
        //        CategoryName = "Spor",
        //        CategoryCount = 1
        //    });
        //    return categoryClasses;
        //}
        #endregion

        #region Dinamik Grafik
        //public ActionResult CategoryListChart()
        //{
        //    return Json(CategoryList(), JsonRequestBehavior.AllowGet);
        //}

        //public List<CategoryClass> CategoryList()
        //{
        //    List<CategoryClass> categoryClasses = new List<CategoryClass>();
        //    using (var context = new DataAccessLayer.Concrete.Context())
        //    {
        //        categoryClasses = context.Categories.Select(x => new CategoryClass
        //        {
        //            CategoryName = x.CategoryName,
        //            CategoryCount = x.Headings.Count()
        //        }).ToList();
        //    }
        //    return categoryClasses;
        //}

        //View tarafında 
        //url: '@Url.Action("CategoryListChart", "AdminStatistics")',

        #endregion
    }
}