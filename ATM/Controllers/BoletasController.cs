﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Controllers
{
    public class BoletasController : Controller
    {
        // GET: Boletas
        public ActionResult Index()
        {
            return View();
        }
    }
}