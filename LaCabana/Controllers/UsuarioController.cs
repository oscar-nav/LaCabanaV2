using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using System.Web.UI;


namespace LaCabana.Controllers
{
    public class UsuarioController
    {
    
        UsuarioModel instanciaUsuario = new UsuarioModel();
        BitacoraModel instanciaBitacora = new BitacoraModel();



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
                instanciaBitacora.Registrar_Bitacora(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("api/Usuario/Consultar_Usuarios_Estado")]
        public RespuestaUsuarioObj Consultar_Usuarios_Estado(bool activo)
        {
            var correoToken = Thread.CurrentPrincipal.Identity.Name;
            try
            {
                return instanciaUsuario.Consultar_Usuarios_Estado(activo);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_Bitacora(correoToken, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

    }

}