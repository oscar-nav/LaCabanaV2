using LaCabana.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;

namespace LaCabana.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoModel instanciaEmpleado = new EmpleadoModel();
        BitacoraModel instanciaBitacora = new BitacoraModel();

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Empleado/Validar_Empleado")]
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
