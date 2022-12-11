using LaCabana.Models;
using System;
using System.Reflection;
using System.Threading;
using System.Web.Http;

namespace LaCabana.Controllers
{
    public class UsuarioController : ApiController
    {
        UsuarioModel instanciaUsuario = new UsuarioModel();
        ErrorLogModel instanciaBitacora = new ErrorLogModel();

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/Validar_Usuario")]
        public RespuestaUsuarioObj Validar_Usuario(UsuarioObj usuario)
        {
            try
            {
                return instanciaUsuario.Validar_Usuario(usuario);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/Registrar_Usuario")]
        public RespuestaUsuarioObj Registrar_Usuario(UsuarioObj usuario)
        {
            try
            {
                return instanciaUsuario.Registrar_Usuario(usuario);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }


        [Authorize]
        [HttpPut]
        [Route("api/Usuario/Actualizar_Usuario")]
        public RespuestaUsuarioObj Actualizar_Usuario(UsuarioObj usuario)
        {
            try
            {
                return instanciaUsuario.Actualizar_Usuario(usuario);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_ErrorLog(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }
    }
}
