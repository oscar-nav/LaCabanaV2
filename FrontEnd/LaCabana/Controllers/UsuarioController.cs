using LaCabana.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Security;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading;
using System.Web.Mvc;
using System.Web.UI;

namespace LaCabana.Controllers
{
    public class UsuarioController : Controller
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
                instanciaBitacora.Registrar_Bitacora(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }



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
                instanciaBitacora.Registrar_Bitacora(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

    }
}



        //[AllowAnonymous]
        //[HttpPost]
        //[Route("api/Usuario/Validar_Usuario")]
        //public RespuestaUsuarioObj Validar_Usuario(UsuarioObj usuario)
        //{
        //    try
        //    {
        //        return instanciaUsuario.Validar_Usuario(usuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        instanciaBitacora.Registrar_Bitacora(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name);

        //        RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
        //        respuesta.Codigo = -1;
        //        respuesta.Mensaje = "Se presentó un error inesperado";
        //        return respuesta;
        //    }
        //}

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("api/Usuario/Registrar_Usuario")]
        //public RespuestaUsuarioObj Registrar_Usuario(UsuarioObj usuario)
        //{
        //    try
        //    {
        //        //Consultar usuarios por correo
        //        return instanciaUsuario.Registrar_Usuario(usuario);
        //    }
        //    catch (Exception ex)
        //    {
        //        instanciaBitacora.Registrar_Bitacora(usuario.Correo, ex, MethodBase.GetCurrentMethod().Name);

        //        RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
        //        respuesta.Codigo = -1;
        //        respuesta.Mensaje = "Se presentó un error inesperado";
        //        return respuesta;
        //    }
        //}
    
