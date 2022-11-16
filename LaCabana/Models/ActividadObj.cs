using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaCabana.Models
{
    public class ActividadObj
    {
        public int IDActividad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Disponibilidad { get; set; }
        public string Lugar { get; set; }
        public float Precio { get; set; }

    }
    public class RespuestaActividadObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public ActividadObj objeto { get; set; }
        public List<ActividadObj> lista { get; set; }
    }

}