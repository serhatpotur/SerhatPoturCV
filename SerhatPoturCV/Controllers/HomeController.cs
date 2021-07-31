using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SerhatPoturCV.Models.Entity;
namespace SerhatPoturCV.Controllers
{
    public class HomeController : Controller
    {
        SerhatPoturCVEntities entities = new SerhatPoturCVEntities();
        public ActionResult Index()
        {
            var abouts = entities.Abouts.SingleOrDefault();
            return View(abouts);
        }

        public ActionResult About2()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public PartialViewResult About()
        {
            DateTime d1 = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime d2 = Convert.ToDateTime("1998-05-24");
            TimeSpan snc = d1 - d2;
            ViewBag.Age = snc;
            var abouts = entities.Abouts.ToList();
            return PartialView(abouts);
        }
        public PartialViewResult WorkingHistory()
        {
            return PartialView();
        }
        public PartialViewResult Projects()
        {
            return PartialView();
        }
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        public PartialViewResult MySkills()
        {
            
            var skills = entities.Skills.ToList();
            return PartialView(skills);
        }
        public ActionResult Contactt()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}