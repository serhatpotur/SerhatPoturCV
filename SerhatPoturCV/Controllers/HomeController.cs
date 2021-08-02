using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SerhatPoturCV.Models.Entity;
using SerhatPoturCV.Repositories;

namespace SerhatPoturCV.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        AboutRepository aboutRepository = new AboutRepository(new SerhatPoturCVEntities());
        ContactRepository contactRepository = new ContactRepository(new SerhatPoturCVEntities());
        public ActionResult Index()
        {
            var abouts = aboutRepository.GetEntity();
            return View(abouts);
        }

        public PartialViewResult AdminSidebar()
        {
            var contact = contactRepository.GetList();
            ViewBag.contactCount = contact.Count;
            return PartialView();
        }
     
       
       
     
       
      
       
       
       
    }
}