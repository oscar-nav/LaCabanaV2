using LaCabana.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;

namespace LaCabana.Controllers
{
    public class ReservaController : Controller
    {
<<<<<<< Updated upstream
        ReservaModel instanciaReserva = new ReservaModel();
        BitacoraModel instanciaBitacora = new BitacoraModel();
=======

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearReservas()
        {
            ViewBag.Title = "Crear Reserva";

            return View();
        }


        ReservaModel instanciaReserva = new ReservaModel();        
>>>>>>> Stashed changes

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Reserva/Crear_Reserva")]
        public RespuestaReservaObj Crear_Reserva(ReservaObj reserva)
        {
            try
            {
                return instanciaReserva.Crear_Reserva(reserva);
            }
            catch (Exception ex)
            {
                RespuestaReservaObj respuesta = new RespuestaReservaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Reserva/Eliminar_Reserva")]
        public RespuestaReservaObj Eliminar_Reserva(ReservaObj reserva)
        {
            try
            {
                return instanciaReserva.Eliminar_Reserva(reserva);
            }
            catch (Exception ex)
            {
                RespuestaReservaObj respuesta = new RespuestaReservaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Reserva/Leer_Reserva")]
        public RespuestaReservaObj Leer_Reserva(ReservaObj reserva)
        {
            try
            {
                return instanciaReserva.Leer_Reserva(reserva);
            }
            catch (Exception ex)
            {
                RespuestaReservaObj respuesta = new RespuestaReservaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Reserva/Reservas")]
        public RespuestaReservaObj Reservas(ReservaObj reserva)
        {
            try
            {
                return instanciaReserva.Reservas(reserva);
            }
            catch (Exception ex)
            {
                RespuestaReservaObj respuesta = new RespuestaReservaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Reserva/Modificar_Reserva")]
        public RespuestaReservaObj Modificar_Reserva(ReservaObj reserva)
        {
            try
            {
                return instanciaReserva.Modificar_Reserva(reserva);
            }
            catch (Exception ex)
            {
                RespuestaReservaObj respuesta = new RespuestaReservaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        public ActionResult Habitaciones()
        {
            ViewBag.Title = "Habitaciones";
            return View();
        }

    }
}
