using SerhatPoturCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerhatPoturCV.Models.Entity;
using SerhatPoturCV.ValidationRules.FluentValidation;
using FluentValidation.Results;

namespace SerhatPoturCV.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaRepository mediaRepository = new SocialMediaRepository(new SerhatPoturCVEntities());
        SocialMediaValidator validations = new SocialMediaValidator();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var media = mediaRepository.GetList();
            return View(media);
        }
        [AllowAnonymous]
        public PartialViewResult MySocialMedia()
        {
            return PartialView(mediaRepository.GetList());
        }
        public PartialViewResult AddMediaPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {

            return View();
        }
        [HttpPost]

        public ActionResult AddSocialMedia(SocialMedias media)
        {
            ValidationResult result = validations.Validate(media);
            if (result.IsValid)
            {
                mediaRepository.Add(media);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var media = mediaRepository.GetById(id);
            mediaRepository.Delete(media);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = mediaRepository.GetById(id);
            return View(socialMedia);
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedias media)
        {
            ValidationResult result = validations.Validate(media);
            if (result.IsValid)
            {
                mediaRepository.Update(media);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(media);
            }

        }
    }
}