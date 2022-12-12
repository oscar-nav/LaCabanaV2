using LaCabana.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Web.Http;

namespace LaCabana.Controllers
{
    public class HabitacionController : ApiController
    {
        ReservaModel instanciaReserva = new ReservaModel();
        ErrorLogModel instanciaBitacora = new ErrorLogModel();

        [Authorize]
        [HttpPost]
        [Route("api/Reserva/Crear_Habitacion")]
        public RespuestaReservaObj Crear_Reserva(ReservaObj reserva)
        {
            try
            {
                return instanciaReserva.Crear_Reserva(reserva);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog("Registro Reserva", ex, MethodBase.GetCurrentMethod().Name);
                RespuestaReservaObj respuesta = new RespuestaReservaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [Authorize]
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
                instanciaBitacora.Registrar_ErrorLog("Eliminar Reserva", ex, MethodBase.GetCurrentMethod().Name);
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
                instanciaBitacora.Registrar_ErrorLog("Leer Reserva", ex, MethodBase.GetCurrentMethod().Name);
                RespuestaReservaObj respuesta = new RespuestaReservaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [Authorize]
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
                instanciaBitacora.Registrar_ErrorLog("Leer Reservas", ex, MethodBase.GetCurrentMethod().Name);
                RespuestaReservaObj respuesta = new RespuestaReservaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [Authorize]
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
                instanciaBitacora.Registrar_ErrorLog("Modificar Reserva", ex, MethodBase.GetCurrentMethod().Name);
                RespuestaReservaObj respuesta = new RespuestaReservaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

    }
}
