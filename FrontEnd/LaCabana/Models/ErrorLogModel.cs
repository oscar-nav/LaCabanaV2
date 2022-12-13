

using LaCabana.BD;
using System;


namespace LaCabana.Models
{
    public class ErrorLogModel
    {

        public void Registrar_Bitacora(string correo, Exception ex, string origen)
        {
            using (var con = new LaCabanaKNEntities())
            {
                var registro = new ErrorLogs { Fecha = DateTime.Now, IDError = 0, Nombre = correo, Descripcion = ex.Message };
                con.ErrorLogs.Add(registro);
                con.SaveChangesAsync();
            }
        }

    }
}