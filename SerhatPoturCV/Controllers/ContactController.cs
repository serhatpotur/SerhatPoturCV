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
    public class ContactController : Controller
    {
        ContactRepository contactRepository = new ContactRepository(new SerhatPoturCVEntities());
        AboutRepository aboutRepository = new AboutRepository(new SerhatPoturCVEntities());
        ContactValidator validations = new ContactValidator();
        // GET: Contact


        public ActionResult Index(string search)
        {
            var contact = contactRepository.UnReadInbox();
            if (!String.IsNullOrEmpty(search))
            {
                contact = contact.Where(x => x.Name.Contains(search) || x.Surname.Contains(search) || x.Subject.Contains(search) || x.Message.Contains(search) || x.Mail.Contains(search)).OrderBy(x => Convert.ToDateTime(x.MessageDate)).ToList();
            }

            return View(contact);
        }
        public ActionResult ReadInboxList(string search)
        {
            var readMessages = contactRepository.ReadInbox();
            if (!String.IsNullOrEmpty(search))
            {
                readMessages = readMessages.Where(x => x.Name.Contains(search) || x.Surname.Contains(search) || x.Subject.Contains(search) || x.Message.Contains(search) || x.Mail.Contains(search)).ToList();
            }
            return View(readMessages);
        }
        public ActionResult DeletedMessagesList(string search)
        {
            var deletedMessages = contactRepository.DeletedMessages();
            if (!String.IsNullOrEmpty(search))
            {
                deletedMessages = deletedMessages.Where(x => x.Name.Contains(search) || x.Surname.Contains(search) || x.Subject.Contains(search) || x.Message.Contains(search) || x.Mail.Contains(search)).ToList();
            }
            return View(deletedMessages);
        }
        public ActionResult ReadMessage(int id)
        {
            var message = contactRepository.GetById(id);
            message.isRead = true;
            contactRepository.Update(message);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMessage(int id)
        {
            var message = contactRepository.GetById(id);
            message.isDeleted = true;
            contactRepository.Update(message);
            return RedirectToAction("Index");
        }
        public ActionResult RestoreMessage(int id)
        {
            var message = contactRepository.GetById(id);
            message.isDeleted = false;
            contactRepository.Update(message);
            return RedirectToAction("Index");
        }
        public PartialViewResult ContactSidebar()
        {
            var readmessage = contactRepository.ReadInbox().Count;
            var unreadmessage = contactRepository.UnReadInbox().Count;
            var deletemessage = contactRepository.DeletedMessages().Count;

            ViewBag.readmessagecount = readmessage;
            ViewBag.unreadmessagecount = unreadmessage;
            ViewBag.deletemessagecount = deletemessage;
            return PartialView();
        }
        [AllowAnonymous]

        public PartialViewResult ContactMe(Contacts contacts)
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
        public ActionResult ReadMessageDetails(int id)
        {
            var contact = contactRepository.GetById(id);
            return View(contact);
        }
        public ActionResult TrashMessageDetails(int id)
        {
            var contact = contactRepository.GetById(id);
            return View(contact);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult AddContact()
        {
            var mail = aboutRepository.GetEntity();
            ViewBag.mail = mail.Mail;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddContact(Contacts contacts)
        {


            if (ModelState.IsValid)
            {
                contacts.MessageDate = DateTime.Now;
                contacts.isRead = false;
                contacts.isDeleted = false;
                contacts.isActive = true;

                contactRepository.Add(contacts);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }



        }
        public ActionResult DeleteContact(int id)
        {
            var contacts = contactRepository.GetById(id);
            contacts.isActive = false;
            contacts.isDeleted = false;
            contactRepository.Update(contacts);
            return RedirectToAction("Index");
        }

    }
}