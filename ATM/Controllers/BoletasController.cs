using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATM.Controllers
{
    public class BoletasController : Controller
    {
        // GET: Boletas
        InventarioEntities db = new InventarioEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Boleteras boletas)
        {
            if (ModelState.IsValid)
            {
                using (InventarioEntities entities = new InventarioEntities())
                {
                   // boletas.idTipo = Convert.ToInt32(selectedValueTipo);
                    boletas.Created = DateTime.Now;
                    entities.Boleteras.Add(boletas);
                    entities.SaveChanges();
                    ModelState.Clear();
                }
            }
            return View();
        }
    }
}