using LaCabana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaCabana.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Inicio()
        {
            ViewBag.Title = "Login";
            return View();
        }

        public ActionResult Habitaciones()
        {
            ViewBag.Title = "Habitaciones";

            return View();
        }

        public ActionResult Index() { 
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

        public ActionResult CrearReservas()
        {
            ViewBag.Title = "CrearReservas";
            return View();
        }


        UsuarioModel instanciaUsuario = new UsuarioModel();



        [HttpPost]
        public ActionResult ValidarAcceso(UsuarioObj usuario)
        {
            ViewBag.MsjError = string.Empty;

            //Acción para autenticar a un usuario
            var respuesta = instanciaUsuario.Validar_Usuario(usuario);

            if (respuesta != null && respuesta.Codigo == 1)
            {
                Session["Cedula"] = respuesta.objeto.Cedula;
                Session["token"] = respuesta.objeto.Token;
                Session["nombre"] = respuesta.objeto.Nombre;
                

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.MsjError = "Valide sus credenciales nuevamente";
                return View("Index");
            }
        }

    
        [HttpGet]
        public ActionResult Principal()
        {
            //Entrar al sistema
            return View();
        }

        [HttpGet]
        public ActionResult CerrarSesion()
        {
            return RedirectToAction("Index", "Home");
        }

    }



}

