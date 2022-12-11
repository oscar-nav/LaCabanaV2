using LaCabana.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Web.Http;

namespace LaCabana.Controllers
{
    public class ActividadController : ApiController
    {
        ActividadModel instanciaActividad = new ActividadModel();
        ErrorLogModel instanciaBitacora = new ErrorLogModel();

        [Authorize]
        [HttpPost]
        [Route("api/Actividad/Crear_Actividad")]
        public RespuestaActividadObj Crear_Actividad(ActividadObj actividad)
        {
            try
            {
                return instanciaActividad.Crear_Actividad(actividad);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog("SISTEMA", ex, MethodBase.GetCurrentMethod().Name);

                RespuestaActividadObj respuesta = new RespuestaActividadObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }


        [Authorize]
        [HttpPut]
        [Route("api/Actividad/Modificar_Actividad")]
        public RespuestaActividadObj Modificar_Actividad(ActividadObj actividad)
        {
            try
            {
                return instanciaActividad.Modificar_Actividad(actividad);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog("SISTEMA", ex, MethodBase.GetCurrentMethod().Name);

                RespuestaActividadObj respuesta = new RespuestaActividadObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("api/Actividad/Eliminar_Actividad")]
        public RespuestaActividadObj Eliminar_Actividad(ActividadObj actividad)
        {
            try
            {
                return instanciaActividad.Eliminar_Actividad(actividad);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog("SISTEMA", ex, MethodBase.GetCurrentMethod().Name);

                RespuestaActividadObj respuesta = new RespuestaActividadObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [Authorize]
        [HttpPut]
        [Route("api/Actividad/Actividades")]
        public RespuestaActividadObj Actividades()
        {
            try
            {
                return instanciaActividad.Actividades();
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog("SISTEMA", ex, MethodBase.GetCurrentMethod().Name);

                RespuestaActividadObj respuesta = new RespuestaActividadObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }
    }
}
