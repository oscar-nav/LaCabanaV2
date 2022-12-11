using LaCabana.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Web.Http;

namespace LaCabana.Controllers
{
    public class EmpleadoController : ApiController
    {
        EmpleadoModel instanciaEmpleado = new EmpleadoModel();
        ErrorLogModel instanciaBitacora = new ErrorLogModel();


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
                instanciaBitacora.Registrar_ErrorLog(empleado.Cedula.ToString(), ex, MethodBase.GetCurrentMethod().Name);

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
                return instanciaEmpleado.Registrar_Empleado(empleado);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog(empleado.Cedula.ToString(), ex, MethodBase.GetCurrentMethod().Name);

                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }


        [Authorize]
        [HttpPut]
        [Route("api/Empleado/Actualizar_Empleado")]
        public RespuestaEmpleadoObj Actualizar_Empleado(EmpleadoObj empleado)
        {
            try
            {
                return instanciaEmpleado.Actualizar_Empleado(empleado);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog(empleado.Cedula.ToString(), ex, MethodBase.GetCurrentMethod().Name);

                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/Empleado/Consultar_Empleado_Id")]
        public RespuestaEmpleadoObj Consultar_Empleado_Id(long id)
        {
            var correoToken = Thread.CurrentPrincipal.Identity.Name;
            try
            {
                return instanciaEmpleado.Consultar_Empleado_Id(id);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog(correoToken, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }
    }
}
