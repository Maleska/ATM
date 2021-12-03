using ATM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Controllers
{
    public class UsuariosController : Controller
    {
        ATMEntities db = new ATMEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var data = db.SP_getAllPeople().ToList();
            ViewBag.UsrList = data;

            List<SelectListItem> myList = new List<SelectListItem>();
            SelectListItem listItem = new SelectListItem();
          
            var dataType = db.sp_getAllRol().ToList();
            foreach (var item in dataType)
            {
                listItem.Text = item.rol;
                listItem.Value = item.Id.ToString();
                myList.Add(listItem);
                listItem = new SelectListItem();
            }
            ViewBag.RolList = dataType;
            ViewBag.RolListItem = myList;


            //DPFP.Capture.Capture capture = null;

            //capture = new DPFP.Capture.Capture("");



            return View();
        }

        [HttpGet]
        public JsonResult getValuesUser(int id)
        {
            var rstJson = db.Personal.Where(m => m.Id == id).FirstOrDefault();

            return Json(rstJson, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateUser(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ATMEntities())
                {
                    var id = Convert.ToInt32(form["id"]);
                    var personal = db.Personal.FirstOrDefault(m => m.Id == id);

                    personal.nombre = form["nombre"];
                    personal.apellidos= form["apellidos"];
                    personal.telefono = form["telefono"];

                    db.Personal.Attach(personal);
                    db.Entry(personal).State = EntityState.Modified;

                    db.SaveChanges();

                    var data = db.SP_getAllPeople().ToList();
                    ViewBag.UsrList = data;

                    var dataType = db.sp_getAllRol().ToList();
                    ViewBag.RolList = dataType;
                }
            }

            return View("Index");
        }
        [HttpPost]
        public ActionResult DeleteUser(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ATMEntities())
                {
                    var id = Convert.ToInt32(form["id"]);
                    var inv = db.Personal.FirstOrDefault(m => m.Id == id);

                    inv.activo = false;

                    db.Personal.Attach(inv);
                    db.Entry(inv).State = EntityState.Modified;

                    db.SaveChanges();

                    var data = db.SP_getAllPeople().ToList();
                    ViewBag.InvList = data;

                    var dataType = db.sp_getAllRol().ToList();
                    ViewBag.RolList = dataType;
                }
            }
            return View("Index");
        }
        
        [HttpGet]
        public JsonResult getValues(int id)
        {
            var rstJson = db.Rol.Where(m => m.Id == id).FirstOrDefault();
            return Json(rstJson, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateRol(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ATMEntities())
                {
                    var id = Convert.ToInt32(form["IdRolEdit"]);
                    var rol = db.Rol.FirstOrDefault(m => m.Id == id);

                    rol.rol1= form["txbEditRol"];
               

                    db.Rol.Attach(rol);
                    db.Entry(rol).State = EntityState.Modified;

                    db.SaveChanges();

                    var data = db.SP_getAllPeople().ToList();
                    ViewBag.UsrList = data;

                    var dataType = db.sp_getAllRol().ToList();
                    ViewBag.RolList = dataType;
                }
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult deleteRol(int id)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ATMEntities())
                {
                    var inv = db.Rol.FirstOrDefault(m => m.Id == id);

                    inv.active = false;

                    db.Rol.Attach(inv);
                    db.Entry(inv).State = EntityState.Modified;

                    db.SaveChanges();

                    var data = db.SP_getAllPeople().ToList();
                    ViewBag.InvList = data;

                    var dataType = db.sp_getAllRol().ToList();
                    ViewBag.RolList = dataType;
                }
            }
            return View("Index");
        }
    }
}