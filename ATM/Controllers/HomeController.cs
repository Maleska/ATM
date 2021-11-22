using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            InventarioEntities db = new InventarioEntities();
            var data = db.sp_getAllInvetory().ToList();
            ViewBag.InvList = data;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Inventarios inventario)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}