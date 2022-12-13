using LaCabana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace LaCabana.Controllers
{
    public class HabitacionController : Controller
    {
        // GET: Habitacion
        public ActionResult Index()
        {
            return View();
        }
        HabitacionModel instanciaHabitacion = new HabitacionModel();
        ErrorLogModel instanciaBitacora = new ErrorLogModel();

        [Authorize]
        [HttpPost]
        [Route("api/Habitacion/Crear_Habitacion")]
        public RespuestaHabitacionObj Crear_Habitacion(HabitacionObj habitacion)
        {
            try
            {
                return instanciaHabitacion.Crear_Habitacion(habitacion);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog("Registro Habitacion", ex, MethodBase.GetCurrentMethod().Name);
                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [Authorize]
        [HttpPost]
        [Route("api/Habitacion/Eliminar_Habitacion")]
        public RespuestaHabitacionObj Eliminar_Habitacion(HabitacionObj habitacion)
        {
            try
            {
                return instanciaHabitacion.Eliminar_Habitacion(habitacion);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog("Eliminar Habitacion", ex, MethodBase.GetCurrentMethod().Name);
                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Habitacion/Leer_Habitacion")]
        public RespuestaHabitacionObj Leer_Habitacion(HabitacionObj habitacion)
        {
            try
            {
                return instanciaHabitacion.Leer_Habitacion(habitacion);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog("Leer Habitacion", ex, MethodBase.GetCurrentMethod().Name);
                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/Habitacion/Habitaciones")]
        public RespuestaHabitacionObj Habitaciones()
        {
            try
            {
                return instanciaHabitacion.Habitaciones();
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog("Leer Habitacions", ex, MethodBase.GetCurrentMethod().Name);
                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("api/Habitacion/Modificar_Habitacion")]
        public RespuestaHabitacionObj Modificar_Habitacion(HabitacionObj habitacion)
        {
            try
            {
                return instanciaHabitacion.Modificar_Habitacion(habitacion);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog("Modificar Habitacion", ex, MethodBase.GetCurrentMethod().Name);
                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

    }
}

