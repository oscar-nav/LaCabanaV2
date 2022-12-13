using LaCabana.BD;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;

namespace LaCabana.Models
{
    public class HabitacionModel
    {

        public RespuestaHabitacionObj Crear_Habitacion(HabitacionObj habitacion)
        {
            using (HttpClient client = new HttpClient())
            {

                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Habitacion/Crear_Habitacion";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(habitacion);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaHabitacionObj>().Result;
                }
                return null;
            }
        }

        public RespuestaHabitacionObj Eliminar_Habitacion(HabitacionObj habitacion)
        {
            using (HttpClient client = new HttpClient())
            {

                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Habitacion/Eliminar_Habitacion";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(habitacion);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaHabitacionObj>().Result;
                }
                return null;
            }
        }


        public RespuestaHabitacionObj Leer_Habitacion(HabitacionObj habitacion)
        {
            using (HttpClient client = new HttpClient())
            {

                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Habitacion/Leer_Habitacion";

                //Serializar --> System.Net.Http.Json;
                JsonContent contenido = JsonContent.Create(habitacion);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaHabitacionObj>().Result;
                }
                return null;
            }
        }

        public RespuestaHabitacionObj Habitaciones()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Habitacion/Habitaciones";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaHabitacionObj>().Result;
                }
                return null;
            }
        }

        public RespuestaHabitacionObj Modificar_Habitacion(HabitacionObj habitacion)
        {
            using (var con = new LaCabanaKNEntities())
            {


                var habitacionExistente = (from x in con.Habitacion where x.IDHabitacion == habitacion.IDHabitacion select x).SingleOrDefault();

                habitacionExistente.IDHabitacion = habitacion.IDHabitacion;
                habitacionExistente.Descripcion = habitacion.Descripcion;
                habitacionExistente.CantidadPersonas = habitacion.CantidadPersonas;
                habitacionExistente.Disponibilidad = habitacion.Disponibilidad;
                habitacionExistente.Nombre = habitacion.Nombre;
                habitacionExistente.Precio = habitacion.Precio;

                var resultado = con.SaveChanges();


                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Habitacion Actualizada Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción de manera exitosa";
                }

                return respuesta;
            }
        }
    }
}