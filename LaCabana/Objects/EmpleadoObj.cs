using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaCabana.Models
{
    public class EmpleadoObj
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Contrasenna { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string HorarioDia { get; set; }
        public string HorarioHora { get; set; }
        public string Token { get; set; }
    }

    public class RespuestaEmpleadoObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public EmpleadoObj objeto { get; set; }
        public List<EmpleadoObj> lista { get; set; }
    }
}