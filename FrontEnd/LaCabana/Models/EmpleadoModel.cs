using LaCabana.BD;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace LaCabana.Models
{
    public class EmpleadoModel
    {
        public RespuestaEmpleadoObj Validar_Empleado(EmpleadoObj empleado)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Empleado/Validar_Empleado";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(empleado);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaEmpleadoObj>().Result;
                }
                return null;
            }
        }


        public RespuestaEmpleadoObj Registrar_Empleado(EmpleadoObj empleado)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Empleado/Registrar_Empleado";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(empleado);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaEmpleadoObj>().Result;
                }
                return null;
            }
        }

        public RespuestaEmpleadoObj Actualizar_Empleado(EmpleadoObj empleado)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Empleado/Actualizar_Empleado";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(empleado);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaEmpleadoObj>().Result;
                }
                return null;
            }
        }


        public RespuestaEmpleadoObj Consultar_Empleado_Id(long id)
        {

        }



    }
}