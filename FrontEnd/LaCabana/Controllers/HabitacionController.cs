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

        ReservaModel instanciaReserva = new ReservaModel();
        BitacoraModel instanciaBitacora = new BitacoraModel();

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Reserva/Validar_Empleado")]
        public RespuestaEmpleadoObj Validar_Empleado(EmpleadoObj empleado)
        {
            try
            {
                return instanciaEmpleado.Validar_Empleado(empleado);
            }
            catch (Exception ex)
            {
<<<<<<< Updated upstream
                instanciaBitacora.Registrar_Bitacora(empleado.Cedula.ToString(), ex, MethodBase.GetCurrentMethod().Name);

                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();
=======
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
                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();
>>>>>>> Stashed changes
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Empleado/Registrar_Empleado")]
        public RespuestaEmpleadoObj Registrar_Empleado(EmpleadoObj empleado)
        {
            try
            {
                //Consultar empleados por correo
                return instanciaEmpleado.Registrar_Empleado(empleado);
            }
            catch (Exception ex)
            {
<<<<<<< Updated upstream
                instanciaBitacora.Registrar_Bitacora(empleado.Cedula.ToString(), ex, MethodBase.GetCurrentMethod().Name);

                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();
=======
                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();
>>>>>>> Stashed changes
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }
<<<<<<< Updated upstream
=======

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
                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

>>>>>>> Stashed changes
    }
}
