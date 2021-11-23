using ATM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        [HttpPost]
        public ActionResult AddItem(Inventario inventario)
        {

            if (ModelState.IsValid)
            {
                using (InventarioEntities entities = new InventarioEntities())
                {
                    entities.Inventario.Add(inventario);
                    entities.SaveChanges();
                    ModelState.Clear();
                }
            }
            InventarioEntities db = new InventarioEntities();
            var data = db.sp_getAllInvetory().ToList();
            ViewBag.InvList = data;
            return View("Index");
        }
        [HttpPost]
        //public ActionResult UpdateItem(Inventario inventario, string id, string descripcion, int cantidad, string cb)
        public ActionResult UpdateItem(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                using(var db = new InventarioEntities())
                {
                    var id = Convert.ToInt32(form["id"]);
                    var inv = db.Inventario.FirstOrDefault(m => m.Id == id);

                    inv.cantidad = Convert.ToInt32(form["cantidad"]);
                    inv.CB = form["CodigoBarras"];
                    inv.descripcion = form["nombre"];

                    db.Inventario.Attach(inv);
                    db.Entry(inv).State = EntityState.Modified;

                    db.SaveChanges();

                    var data = db.sp_getAllInvetory().ToList();
                    ViewBag.InvList = data;
                }
            }
           
            return View("Index");
        }
        [HttpGet]
        public JsonResult getValues(int id)
        {
            InventarioEntities db = new InventarioEntities();
            var rstJson = db.Inventario.Where(m => m.Id == id).FirstOrDefault();
            
            return Json(rstJson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult removeItem(FormCollection form)
        {
            return View("Index");
        }
    }
}