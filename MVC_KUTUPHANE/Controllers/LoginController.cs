﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_KUTUPHANE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }
    }
}