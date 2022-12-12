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
                instanciaBitacora.Registrar_Bitacora(empleado.Cedula.ToString(), ex, MethodBase.GetCurrentMethod().Name);

                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();
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
                instanciaBitacora.Registrar_Bitacora(empleado.Cedula.ToString(), ex, MethodBase.GetCurrentMethod().Name);

                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }
    }
}
