using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ATM.Models;

namespace ATM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var sessiones = this.HttpContext.Session["User"];
            if (sessiones != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if (ModelState.IsValid)
            {
                if (login.password is null)
                {
                    ModelState.AddModelError("Error", "Por favor, Ingresar nombre del usuario y password");
                }
                else if (login.usuario is null)
                {
                    ModelState.AddModelError("Error", "Por favor, Ingresar nombre del usuario y password");
                }

                using (ATMEntities1 db = new ATMEntities1())
                {
                    var obj = db.Usuarios.Where(a => a.user.Equals(login.usuario) && a.pass.Equals(login.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.Id.ToString();
                        Session["User"] = obj.user.ToString();
                        Session["IdRol"] = obj.idRol.ToString();
                        ModelState.Clear();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "No se encontro un usuario");
                    }

                }
              }
            else
            {
                ModelState.AddModelError("Error", "Por favor, Ingresar nombre del usuario y password");
            }
            return View();
        }
    }
}