using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaCabana.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Habitaciones()
        {
            ViewBag.Title = "Habitaciones";

            return View();
        }
        public ActionResult Actividades()
        {
            ViewBag.Title = "Actividades";

            return View();
        }
        public ActionResult Paquetes()
        {
            ViewBag.Title = "Paquetes";

            return View();
        }
    }
}
