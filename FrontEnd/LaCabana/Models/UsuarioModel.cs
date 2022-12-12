

using LaCabana.BD;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Net.Http.Headers;
using System.Web;

namespace LaCabana.Models
{
    public class UsuarioModel
    {
        public RespuestaUsuarioObj Validar_Usuario(UsuarioObj usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Validar_Usuario";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(usuario);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaUsuarioObj>().Result;
                }
                return null;
            }
        }

        public RespuestaUsuarioObj Registrar_Usuario(UsuarioObj usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Registrar_Usuario";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(usuario);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaUsuarioObj>().Result;
                }
                return null;
            }
        }

        public RespuestaUsuarioObj Actualizar_Usuario(UsuarioObj usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Actualizar_Usuario";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(usuario);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaUsuarioObj>().Result;
                }
                return null;
            }
        }
    }
}

//private string CrearToken(string Correo)
//{
//    List<Claim> claims = new List<Claim> {
//        new Claim(ClaimTypes.Name, Correo)
//    };

//    var llave = "laCabanaRemix2022";
//    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(llave));
//    var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

//    var token = new JwtSecurityToken(
//        claims: claims,
//        expires: DateTime.UtcNow.AddMinutes(10),
//        signingCredentials: cred);

//    return new JwtSecurityTokenHandler().WriteToken(token);
//}


