using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaCabana.Models
{
    public class ErrorLogObj
    {
        public int IDError { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; } 
    }

    public class RespuestaErrorLogObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public ErrorLogObj objeto { get; set; }
        public List<ErrorLogObj> lista { get; set; }
    }
}