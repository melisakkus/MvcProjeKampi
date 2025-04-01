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
    public class AdminSkillsController : Controller
    {
        ISkillsService skills = new SkillsManager(new EfSkillsDal());
        public ActionResult Index()
        {
            var skillsValues = skills.TGetSkills();
            return View(skillsValues);
        }
    }
}