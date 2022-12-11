

using LaCabana.BD;
using System.Collections.Generic;
using System.Linq;

namespace LaCabana.Models
{
    public class HabitacionModel
    {

        public RespuestaHabitacionObj Crear_Habitacion(HabitacionObj habitacion)
        {
            using (var con = new LaCabanaKNEntities())
            {
                Habitacion nuevaHabitacion = new Habitacion { IDHabitacion = habitacion.IDHabitacion, 
                    Descripcion = habitacion.Descripcion, Disponibilidad = habitacion.Disponibilidad,
                    Nombre = habitacion.Nombre, Precio = habitacion.Precio,
                    CantidadPersonas = habitacion.CantidadPersonas };

                con.Habitacion.Add(nuevaHabitacion);
                var resultado = con.SaveChanges();

                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Habitacion Registrada Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción";
                }

                return respuesta;
            }
        }

        public RespuestaHabitacionObj Eliminar_Habitacion(HabitacionObj habitacion)
        {
            using (var con = new LaCabanaKNEntities())
            {


                var habitacionExistente = (from x in con.Habitacion where x.IDHabitacion == habitacion.IDHabitacion select x).SingleOrDefault();
                con.Habitacion.Remove(habitacionExistente);
                var resultado = con.SaveChanges();

                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Habitacion Eliminada Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción de manera exitosa";
                }

                return respuesta;
            }
        }


        public RespuestaHabitacionObj Leer_Habitacion(HabitacionObj habitacion)
            {
                using (var con = new LaCabanaKNEntities())
                {


                    var resultado = (from x in con.Habitacion where x.IDHabitacion == habitacion.IDHabitacion select x).SingleOrDefault();
                    

                    RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();

                if (resultado != null)
                {
                    var list = new List<HabitacionObj>();
                    list.Add(habitacion);
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Habitacion Obtenida Correctamente";
                    respuesta.lista = list;
                    }
                    else
                    {
                        respuesta.Codigo = 0;
                        respuesta.Mensaje = "No se realizó la transacción de manera exitosa";
                    }

                    return respuesta;
                }
            }

        public RespuestaHabitacionObj Habitaciones()
        {
            using (var con = new LaCabanaKNEntities())
            {


                var resultado = (from x in con.Habitacion select x).ToList();


                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();


                if (resultado != null)
                {

                    List<HabitacionObj> habitaciones = new List<HabitacionObj>();

                    foreach (var r in resultado)
                    {
                        habitaciones.Add(new HabitacionObj
                        {
                            IDHabitacion = (int)r.IDHabitacion,
                            CantidadPersonas = r.CantidadPersonas,
                            Descripcion = r.Descripcion,
                            Nombre = r.Nombre,
                            Precio = (int)r.Precio,
                            Disponibilidad = r.Disponibilidad

                        });
                    }
                   
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Habitaciones Obtenidas Correctamente";
                    respuesta.lista = habitaciones;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción de manera exitosa";
                }

                return respuesta;
            }
        }

        public RespuestaHabitacionObj Modificar_Habitacion(HabitacionObj habitacion)
        {
            using (var con = new LaCabanaKNEntities())
            {


                var habitacionExistente = (from x in con.Habitacion where x.IDHabitacion == habitacion.IDHabitacion select x).SingleOrDefault();

                habitacionExistente.IDHabitacion = habitacion.IDHabitacion;
                habitacionExistente.Descripcion = habitacion.Descripcion;
                habitacionExistente.CantidadPersonas = habitacion.CantidadPersonas;
                habitacionExistente.Disponibilidad= habitacion.Disponibilidad;
                habitacionExistente.Nombre = habitacion.Nombre;
                habitacionExistente.Precio = habitacion.Precio;

                var resultado = con.SaveChanges();


                RespuestaHabitacionObj respuesta = new RespuestaHabitacionObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Habitacion Actualizada Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción de manera exitosa";
                }

                return respuesta;
            }
        }


    }
}