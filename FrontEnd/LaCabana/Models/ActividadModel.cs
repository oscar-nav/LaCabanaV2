using LaCabana.BD;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;

namespace LaCabana.Models
{
    public class ActividadModel
    {

        public RespuestaActividadObj Crear_Actividad(ActividadObj actividad)
        {
            using (HttpClient client = new HttpClient())
            {

                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Actividad/Crear_Actividad";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(actividad);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaActividadObj>().Result;
                }
                return null;
            }
        }

        public RespuestaActividadObj Validar_Actividad(ActividadObj activdad)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Actividad/Validar_Actividad";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(activdad);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaActividadObj>().Result;
                }
                return null;
            }
        }
        

        public RespuestaActividadObj Registrar_Actividad(ActividadObj actividad)

        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Actividad/Registrar_Actividad";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(actividad);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaActividadObj>().Result;
                }
                return null;
            }
        }


        public RespuestaActividadObj Eliminar_Actividad(ActividadObj actividad)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Actividad/Eliminar_Actividad";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaActividadObj>().Result;
                }
                return null;

            }
        }


        public RespuestaActividadObj Actividades(ActividadObj actividad)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Actividad/Actividades";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaActividadObj>().Result;
                }
                return null;
            }
        }
        

        public RespuestaActividadObj Modificar_Actividad(ActividadObj actividad)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Actividad/Modificar_Actividad";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(actividad);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaActividadObj>().Result;
                }
                return null;
            }
        }


    }
}