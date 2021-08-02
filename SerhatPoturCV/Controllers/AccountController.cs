using SerhatPoturCV.Models.Entity;
using SerhatPoturCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SerhatPoturCV.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        AboutRepository aboutRepository = new AboutRepository(new SerhatPoturCVEntities());
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Abouts about)
        {
            var login = aboutRepository.GetByUser(about.Mail, about.Password);
            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.Mail,false);
                Session["Mail"] = login.Mail;
                return RedirectToAction("AboutMe", "About");

            }
            else
            {
                ViewBag.errorMessage = "Eksik ya da hatalı giriş yaptınız";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}