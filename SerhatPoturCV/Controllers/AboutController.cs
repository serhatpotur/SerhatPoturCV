using SerhatPoturCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerhatPoturCV.Models.Entity;
namespace SerhatPoturCV.Controllers
{
    public class AboutController : Controller
    {
       
        AboutRepository aboutRepository = new AboutRepository(new SerhatPoturCVEntities());
        // GET: About
        public ActionResult AboutMe()
        {
            var about = aboutRepository.GetList();
            return View(about);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {

            return View();
        }
        [HttpPost]

        public ActionResult AddAbout(Abouts abouts)
        {
            aboutRepository.Add(abouts);
            return RedirectToAction("AboutMe");
        }
        public ActionResult DeleteAbout(int id)
        {
            var about = aboutRepository.GetById(id);
            aboutRepository.Delete(about);
            return RedirectToAction("AboutMe");
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = aboutRepository.GetById(id);
            return View(about);
        }
        [HttpPost]

        public ActionResult UpdateAbout(Abouts abouts)
        {
            aboutRepository.Update(abouts);
            return RedirectToAction("AboutMe");
        }
    }
}