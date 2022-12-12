

using LaCabana.BD;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace LaCabana.Models
{
    public class ReservaModel
    {

        public RespuestaReservaObj Crear_Reserva(ReservaObj reserva)
        {
            using (HttpClient client = new HttpClient())
            {

                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Reserva/Crear_Reserva";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(reserva);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaReservaObj>().Result;
                }
                return null;
            }
        }

        public RespuestaReservaObj Eliminar_Reserva(ReservaObj reserva)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Reserva/Eliminar_Reserva";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaReservaObj>().Result;
                }
                return null;

            }
        }


        public RespuestaReservaObj Leer_Reserva(ReservaObj reserva)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Reserva/Leer_Reserva";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(reserva);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaReservaObj>().Result;
                }
                return null;
            }
        }

        public RespuestaReservaObj Reservas(ReservaObj reserva)
        {

            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Reserva/Reservas";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaReservaObj>().Result;
                }
                return null;
            }
        }

        public RespuestaReservaObj Modificar_Reserva(ReservaObj reserva)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Reserva/Modificar_Reserva";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaReservaObj>().Result;
                }
                return null;
            }


        }
    }
}   