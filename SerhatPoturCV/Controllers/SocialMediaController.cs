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
        public PartialViewResult Index()
        {
           
            return PartialView(mediaRepository.GetList());
        }
    }
}