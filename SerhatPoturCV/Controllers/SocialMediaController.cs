using SerhatPoturCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerhatPoturCV.Models.Entity;

namespace SerhatPoturCV.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaRepository mediaRepository = new SocialMediaRepository(new SerhatPoturCVEntities());
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
            mediaRepository.Add(media);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var media = mediaRepository.GetById(id);
            mediaRepository.Delete(media);
            return RedirectToAction("Index");
        }
    }
}