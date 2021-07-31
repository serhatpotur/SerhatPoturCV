using SerhatPoturCV.Models.Entity;
using SerhatPoturCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerhatPoturCV.Controllers
{
    public class SkillController : Controller
    {
        SkillRepository skillRepository = new SkillRepository(new SerhatPoturCVEntities());
        // GET: About
        public ActionResult Index()
        {
            var skill = skillRepository.GetList();
            return View(skill);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {

            return View();
        }
        [HttpPost]

        public ActionResult AddSkill(Skills skills)
        {
            skillRepository.Add(skills);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var skill = skillRepository.GetById(id);
            skillRepository.Delete(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var skill = skillRepository.GetById(id);
            return View(skill);
        }
        [HttpPost]

        public ActionResult UpdateSkill(Skills skills)
        {
            skillRepository.Update(skills);
            return RedirectToAction("Index");
        }
    }
}