using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}