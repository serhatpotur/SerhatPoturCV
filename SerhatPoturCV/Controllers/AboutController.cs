using SerhatPoturCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerhatPoturCV.Models.Entity;
using System.IO;

namespace SerhatPoturCV.Controllers
{
    public class AboutController : Controller
    {
        string imgUrl;

        AboutRepository aboutRepository = new AboutRepository(new SerhatPoturCVEntities());
        // GET: About
        public ActionResult AboutMe()
        {
            var about = aboutRepository.GetList();
            return View(about);
        }
        [AllowAnonymous]
        public PartialViewResult MyAbout()
        {
            TimeSpan age = new TimeSpan();
            DateTime now = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime dateofbirth = Convert.ToDateTime("1998-05-24");
            age = (now - dateofbirth);
            ViewBag.Age = (age.Days / 365).ToString();
            var abouts = aboutRepository.AboutList();
            return PartialView(abouts);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {

            return View();
        }
        [HttpPost]

        public ActionResult AddAbout(Abouts abouts, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string randomFileName = string.Format(@"{0}.jpg", Guid.NewGuid());
                string _path = Path.Combine(Server.MapPath("~/Images"), randomFileName);
                file.SaveAs(_path);
                abouts.Image = "/Images/" + randomFileName;
                
            }
            imgUrl = abouts.Image;
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

        public ActionResult UpdateAbout(Abouts abouts,HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string randomFileName =  string.Format(@"{0}.jpg", Guid.NewGuid());
                string _path = Path.Combine(Server.MapPath("~/Images"), randomFileName);
                file.SaveAs(_path);
                abouts.Image = "/Images/" + randomFileName;
            }
            else
            {
                abouts.Image = imgUrl;
            }
            aboutRepository.Update(abouts);
            return RedirectToAction("AboutMe");
        }
    }
}