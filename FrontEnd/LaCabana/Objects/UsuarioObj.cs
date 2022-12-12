    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaCabana.Models
{
    public class UsuarioObj
    {
        //Atributos o Propiedades de una clase

        public int Cedula { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public string Nombre { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Telefono { get; set; }
        public string Token { get; set; }

    }

    public class RespuestaUsuarioObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public UsuarioObj objeto { get; set; }
        public List<UsuarioObj> lista { get; set; }
    }
}