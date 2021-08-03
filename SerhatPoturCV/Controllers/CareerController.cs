using SerhatPoturCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerhatPoturCV.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace SerhatPoturCV.Controllers
{
    public class CareerController : Controller
    {
        CareerRepository careerRepository = new CareerRepository(new SerhatPoturCVEntities());
        // GET: Career
        public ActionResult Index(int pageNumber=1)
        {
            var careers = careerRepository.GetList().ToPagedList(pageNumber,5);
            return View(careers);
        }
        [AllowAnonymous]
        public PartialViewResult WorkingHistory()
        {
            var career = careerRepository.GetList();
            return PartialView(career);
        }
        [HttpGet]
        public ActionResult AddCareer()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddCareer(Careers career)
        {
            careerRepository.Add(career);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCareer(int id)
        {
            var career = careerRepository.GetById(id);
            return View(career);
        }
        [HttpPost]
        public ActionResult UpdateCareer(Careers career)
        {
            careerRepository.Update(career);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCareer(int id)
        {
            var career = careerRepository.GetById(id);
            careerRepository.Delete(career);
            return RedirectToAction("Index");
        }
        

    }
}