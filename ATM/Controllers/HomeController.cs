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

            var dataM = db.ps_getMarcas().ToList();
            ViewBag.MarcaList = dataM;

            var dataT = db.sp_getAllTipos().ToList();
           

            List<SelectListItem> myList = new List<SelectListItem>();
            SelectListItem listItem = new SelectListItem();
            foreach (var item in dataT)
            {
                listItem.Text = item.nombre;
                listItem.Value = item.Id.ToString();
                myList.Add(listItem);
                listItem = new SelectListItem();
            }
            ViewBag.TipoList = myList;
            return View();
        }

        [HttpPost]
        public ActionResult Index(Inventario inventario, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                var selectedValueTipo = Request.Form["tipo"];
                using (InventarioEntities entities = new InventarioEntities())
                {
                    inventario.idTipo = Convert.ToInt32(selectedValueTipo);
                    entities.Inventario.Add(inventario);
                    entities.SaveChanges();
                    ModelState.Clear();
                }
            }

            InventarioEntities db = new InventarioEntities();
            var data = db.sp_getAllInvetory().ToList();
            ViewBag.InvList = data;
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
        public ActionResult AddItem(Inventario inventario,FormCollection form)
        {
          
            if (ModelState.IsValid)
            {
                var selectedValueTipo = Request.Form["tipo"];
                using (InventarioEntities entities = new InventarioEntities())
                {
                    inventario.idTipo = Convert.ToInt32(selectedValueTipo) ;
                    inventario.creado = DateTime.Now;
                    entities.Inventario.Add(inventario);
                    entities.SaveChanges();
                    ModelState.Clear();
                }
            }

            InventarioEntities db = new InventarioEntities();
            var data = db.sp_getAllInvetory().ToList();
            ViewBag.InvList = data;

            var dataT = db.sp_getAllTipos().ToList();

            List<SelectListItem> myList = new List<SelectListItem>();
            SelectListItem listItem = new SelectListItem();
            foreach (var item in dataT)
            {
                listItem.Text = item.nombre;
                listItem.Value = item.Id.ToString();
                myList.Add(listItem);
                listItem = new SelectListItem();
            }
            ViewBag.TipoList = myList;

            return View("Index");
        }
        [HttpPost]
        //public ActionResult UpdateItem(Inventario inventario, string id, string descripcion, int cantidad, string cb)
        public ActionResult UpdateItem(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                using (var db = new InventarioEntities())
                {
                    var id = Convert.ToInt32(form["id"]);
                    var inv = db.Inventario.FirstOrDefault(m => m.Id == id);
                    var selectedValueTipo = Request.Form["tipo"];

                    inv.cantidad = Convert.ToInt32(form["cantidad"]);
                    inv.CB = form["CodigoBarras"];
                    inv.descripcion = form["nombre"];
                    inv.Marca = form["Marca"];
                    inv.emei = form["emi"];
                    inv.idTipo = Convert.ToInt32(selectedValueTipo);

                    db.Inventario.Attach(inv);
                    db.Entry(inv).State = EntityState.Modified;

                    db.SaveChanges();

                    var data = db.sp_getAllInvetory().ToList();
                    ViewBag.InvList = data;


                    var dataT = db.sp_getAllTipos().ToList();

                    List<SelectListItem> myList = new List<SelectListItem>();
                    SelectListItem listItem = new SelectListItem();
                    foreach (var item in dataT)
                    {
                        listItem.Text = item.nombre;
                        listItem.Value = item.Id.ToString();
                        myList.Add(listItem);
                        listItem = new SelectListItem();
                    }
                    ViewBag.TipoList = myList;
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult DeleteItem(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                using (var db = new InventarioEntities())
                {
                    var id = Convert.ToInt32(form["id"]);
                    var inv = db.Inventario.FirstOrDefault(m => m.Id == id);

                    inv.activo = false;

                    db.Inventario.Attach(inv);
                    db.Entry(inv).State = EntityState.Modified;

                    db.SaveChanges();

                    var data = db.sp_getAllInvetory().ToList();
                    ViewBag.InvList = data;

                    var dataT = db.sp_getAllTipos().ToList();

                    List<SelectListItem> myList = new List<SelectListItem>();
                    SelectListItem listItem = new SelectListItem();
                    foreach (var item in dataT)
                    {
                        listItem.Text = item.nombre;
                        listItem.Value = item.Id.ToString();
                        myList.Add(listItem);
                        listItem = new SelectListItem();
                    }
                    ViewBag.TipoList = myList;
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
        //[HttpPost]
        //public ActionResult removeItem(FormCollection form)
        //{
        //    return View("Index");
        //}
    }
}