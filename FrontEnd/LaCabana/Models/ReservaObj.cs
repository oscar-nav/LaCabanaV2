using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaCabana.Models
{
    public class ReservaObj
    {
        public int IdReserva { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public float PrecioTotal{ get; set; }
        public float PrecioActividad { get; set; }
        public float PrecioHabitacion { get; set; }
        public int Descuento { get; set; }
        public int CedulaUsuario { get; set; }
        public int CedulaEmpleado { get; set; }
        public int IdActividad { get; set; }
        public int IdHabitacion { get; set; }

    }

    public class RespuestaReservaObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public ReservaObj objeto { get; set; }
        public List<ReservaObj> lista { get; set; }
    }
}