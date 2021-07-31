using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SerhatPoturCV.Models.Entity;
using SerhatPoturCV.Models.Sinif;

namespace SerhatPoturCV.Controllers
{
    public class CVController : Controller
    {
        SerhatPoturCVEntities db = new SerhatPoturCVEntities();
        // GET: CV
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.About = db.Hakkımda;
            cs.Career = db.Kariyer;
            cs.Projects = db.Projeler;
            cs.Skills = db.Yetenekler;
            return View(cs);
        }
    }
}