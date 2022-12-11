

using LaCabana.BD;
using System;


namespace LaCabana.Models
{
    public class ErrorLogModel
    {

        public void Registrar_ErrorLog(string correo, Exception ex, string metodo)
        {
            using (var con = new LaCabanaKNEntities())
            {
                var registro = new ErrorLogs { Fecha = DateTime.Now, IDError = 0, Nombre = correo, Descripcion = "Method: "+ metodo+ ",\nMessage: " + ex.Message };
                con.ErrorLogs.Add(registro);
                con.SaveChangesAsync();
            }
        }

    }
}