using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaCabana.Models
{
    public class BitacoraObj
    {
        public int IDError { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; } 
    }

    public class RespuestaBitacoraObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public BitacoraObj objeto { get; set; }
        public List<BitacoraObj> lista { get; set; }
    }
}