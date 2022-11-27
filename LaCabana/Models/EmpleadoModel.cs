using LaCabana.BD;
using System.Linq;

namespace LaCabana.Models
{
    public class EmpleadoModel
    {
        public RespuestaEmpleadoObj Validar_Empleado(EmpleadoObj empleado)
        {
            using (var con = new LaCabanaKNEntities())
            {
                var resultado = new Empleado();

                resultado = (from x in con.Empleado where x.Contrasenna == empleado.Contrasenna where x.Cedula == empleado.Cedula select x).SingleOrDefault();

                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();

                if (resultado != null)
                {
                    EmpleadoObj empleadoExistente = new EmpleadoObj();

                    empleadoExistente.Cedula = resultado.Cedula;
                    empleadoExistente.Nombre = resultado.Nombre;
                    empleadoExistente.ApePaterno = resultado.ApePaterno;
                    empleadoExistente.ApeMaterno = resultado.ApeMaterno;
                    empleadoExistente.HorarioDia = resultado.HorarioDia;
                    empleadoExistente.HorarioHora = resultado.HorarioHora;
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.objeto = empleadoExistente;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }

                return respuesta;
            }
        }

        public RespuestaEmpleadoObj Registrar_Empleado(EmpleadoObj empleado)
        {
            using (var con = new LaCabanaKNEntities())
            {
                var nuevoEmpleado = new Empleado 
                {
                    Nombre = empleado.Nombre,
                    Cedula = empleado.Cedula, Contrasenna = empleado.Contrasenna,
                    ApePaterno = empleado.ApePaterno, ApeMaterno = empleado.ApeMaterno,
                    HorarioDia= empleado.HorarioDia, HorarioHora = empleado.HorarioHora
                };

                con.Empleado.Add(nuevoEmpleado);
                var resultado = con.SaveChanges();

                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Empleado Registrado Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción";
                }

                return respuesta;
            }
        }
    }
}