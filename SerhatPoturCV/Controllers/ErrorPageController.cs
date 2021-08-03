﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SerhatPoturCV.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult Error404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}