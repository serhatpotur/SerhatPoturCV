using SerhatPoturCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerhatPoturCV.Models.Entity;

namespace SerhatPoturCV.Controllers
{
    public class CareerController : Controller
    {
        CareerRepository careerRepository = new CareerRepository(new SerhatPoturCVEntities());
        // GET: Career
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult WorkingHistory()
        {
            var career = careerRepository.GetList();
            return PartialView(career);
        }
    }
}