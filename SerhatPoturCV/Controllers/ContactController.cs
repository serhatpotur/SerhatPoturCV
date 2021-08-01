using SerhatPoturCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SerhatPoturCV.Models.Entity;
namespace SerhatPoturCV.Controllers
{
    public class ContactController : Controller
    {
        ContactRepository contactRepository = new ContactRepository(new SerhatPoturCVEntities());
        AboutRepository aboutRepository = new AboutRepository(new SerhatPoturCVEntities());
        // GET: Contact
       
        public ActionResult Index()
        {
            var contact = contactRepository.GetList();
            return View(contact);
        }
        public PartialViewResult Contact()
        {
            var mail = aboutRepository.GetEntity();
            ViewBag.mail = mail.Mail;
            return PartialView();
        }
        public ActionResult ContactDetails(int id)
        {
            var contact = contactRepository.GetById(id);
            return View(contact);
        }
        [HttpGet]
        public ActionResult AddContact()
        {

            return View();
        }
        [HttpPost]

        public ActionResult AddContact(Contacts contacts)
        {
            contactRepository.Add(contacts);
            return RedirectToAction("Index","Home");
        }
        public ActionResult DeleteContact(int id)
        {
            var contacts = contactRepository.GetById(id);
            contactRepository.Delete(contacts);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contacts = contactRepository.GetById(id);
            return View(contacts);
        }
        [HttpPost]

        public ActionResult UpdateContact(Contacts contacts)
        {
            contactRepository.Update(contacts);
            return RedirectToAction("Index");
        }
    }
}