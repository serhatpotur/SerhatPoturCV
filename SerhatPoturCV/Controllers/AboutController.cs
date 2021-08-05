using SerhatPoturCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerhatPoturCV.Models.Entity;
using System.IO;
using SerhatPoturCV.ValidationRules.FluentValidation;
using FluentValidation.Results;

namespace SerhatPoturCV.Controllers
{
    public class AboutController : Controller
    {
       

        AboutRepository aboutRepository = new AboutRepository(new SerhatPoturCVEntities());
        AboutValidator validations = new AboutValidator();
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
            ValidationResult results = validations.Validate(abouts);
            if (results.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string randomFileName = string.Format(@"{0}.jpg", Guid.NewGuid());
                    string _path = Path.Combine(Server.MapPath("~/Images"), randomFileName);

                    abouts.Image = "/Images/" + randomFileName;
                    file.SaveAs(_path);

                }
                else
                {
                    abouts.Image = "/Images/default.jpg";
                }

                aboutRepository.Add(abouts);
                return RedirectToAction("AboutMe");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
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

        public ActionResult UpdateAbout(Abouts abouts, HttpPostedFileBase file, string defaultImage)
        {
            ValidationResult results = validations.Validate(abouts);
            if (results.IsValid)
            {
                //if (abouts.Image == null)
                //{
                //    abouts.Image = imgUrl;
                //}
                if (file != null && file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    string randomFileName = string.Format(@"{0}.jpg", Guid.NewGuid());
                    string _path = Path.Combine(Server.MapPath("~/Images"), randomFileName);
                    abouts.Image = "/Images/" + randomFileName;
                    file.SaveAs(_path);
                }
                else if (file == null && abouts.Image == null)
                {
                    abouts.Image = "/Images/default.jpg";
                }
                aboutRepository.Update(abouts);
                return RedirectToAction("AboutMe");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("UpdateAbout");
            }

        }
    }
}