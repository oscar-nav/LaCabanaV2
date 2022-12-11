using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaCabana.Models
{
    public class HabitacionObj
    {
        public int IDHabitacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Disponibilidad { get; set; }
        public int CantidadPersonas { get; set; }
        public float Precio { get; set; }
    }

    public class RespuestaHabitacionObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public HabitacionObj objeto { get; set; }
        public List<HabitacionObj> lista { get; set; }
    }
}