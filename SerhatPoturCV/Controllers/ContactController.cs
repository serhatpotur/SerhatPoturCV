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


        public ActionResult Index(string search)
        {
            var contact = contactRepository.GetList();
            if (!String.IsNullOrEmpty(search))
            {
                contact = contact.Where(x => x.Name.Contains(search) || x.Surname.Contains(search) || x.Subject.Contains(search) || x.Message.Contains(search) || x.Mail.Contains(search)).ToList();
            }

            return View(contact);
        }
        [AllowAnonymous]
        public PartialViewResult ContactMe()
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
            contacts.MessageDate = DateTime.Now;
            contactRepository.Add(contacts);

            return RedirectToAction("Index", "Home");
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