using FluentValidation.Results;
using Newtonsoft.Json;
using SerhatPoturCV.Models.Entity;
using SerhatPoturCV.Repositories;
using SerhatPoturCV.ValidationRules.FluentValidation;
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
        SkillValidator validations = new SkillValidator();
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
            ValidationResult result = validations.Validate(skills);
            if (result.IsValid)
            {
                skillRepository.Add(skills);
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

        public ActionResult AddSkillPartial()
        {

            return PartialView();
        }

        public ActionResult UpdateSkillPartial(int id)
        {
            var skill = skillRepository.GetById(id);

            return PartialView(skill);
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
            ValidationResult result = validations.Validate(skills);
            if (result.IsValid)
            {
                skillRepository.Update(skills);
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
        [AllowAnonymous]
        public PartialViewResult MySkills()
        {

            var skills = skillRepository.GetList();
            return PartialView(skills);
        }
    }
}