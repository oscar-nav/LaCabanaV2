

using LaCabana.BD;
using System.Collections.Generic;
using System.Linq;

namespace LaCabana.Models
{
    public class ReservaModel
    {

        public RespuestaReservaObj Crear_Reserva(ReservaObj reserva)
        {
            using (var con = new LaCabanaKNEntities())
            {
                var nuevaReserva = new Reserva { IDActividad = reserva.IdActividad, CedulaEmpleado = null, CedulaUsuario = reserva.CedulaUsuario,
                    Descuento = reserva.Descuento, FechaCreacion = reserva.FechaCreacion, FechaFinal = reserva.FechaFinal, IDHabitacion = reserva.IdHabitacion,
                    FechaInicio = reserva.FechaInicio, IDReserva =  0 , PrecioActividades = reserva.PrecioActividad , PrecioTotal = reserva.PrecioTotal };

                con.Reserva.Add(nuevaReserva);
                var resultado = con.SaveChanges();

                RespuestaReservaObj respuesta = new RespuestaReservaObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Reserva Registrada Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción";
                }

                return respuesta;
            }
        }

        public RespuestaReservaObj Eliminar_Reserva(ReservaObj reserva)
        {
            using (var con = new LaCabanaKNEntities())
            {


                var reservaExistente = (from x in con.Reserva where x.IDReserva == reserva.IdReserva select x).SingleOrDefault();
                con.Reserva.Remove(reservaExistente);
                var resultado = con.SaveChanges();

                RespuestaReservaObj respuesta = new RespuestaReservaObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Reserva Eliminada Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción de manera exitosa";
                }

                return respuesta;
            }
        }


        public RespuestaReservaObj Leer_Reserva(ReservaObj reserva)
            {
                using (var con = new LaCabanaKNEntities())
                {


                    var resultado = (from x in con.Reserva where x.IDReserva == reserva.IdReserva select x).SingleOrDefault();
                    

                    RespuestaReservaObj respuesta = new RespuestaReservaObj();

                if (resultado != null)
                {
                    var list = new List<ReservaObj>();
                    list.Add(reserva);
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Reserva Obtenida Correctamente";
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

        public RespuestaReservaObj Reservas(ReservaObj reserva)
        {
            using (var con = new LaCabanaKNEntities())
            {


                var resultado = (from x in con.Reserva select x).ToList();


                RespuestaReservaObj respuesta = new RespuestaReservaObj();


                if (resultado != null)
                {

                    List<ReservaObj> reservas = new List<ReservaObj>();

                    foreach (var r in resultado)
                    {
                        reservas.Add(new ReservaObj
                        {
                            IdActividad = (int)r.IDActividad,
                            CedulaEmpleado = (int)r.CedulaEmpleado,
                            CedulaUsuario = r.CedulaUsuario,
                            Descuento = (int)r.Descuento,
                            FechaCreacion = r.FechaCreacion,
                            FechaFinal = r.FechaFinal,
                            IdHabitacion = r.IDHabitacion,
                            FechaInicio = r.FechaInicio,
                            IdReserva = r.IDReserva,
                            PrecioActividad = (float)r.PrecioActividades,
                            PrecioTotal = (float)r.PrecioTotal
                        });
                    }
                   
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Reservas Obtenidas Correctamente";
                    respuesta.lista = reservas;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción de manera exitosa";
                }

                return respuesta;
            }
        }

        public RespuestaReservaObj Modificar_Reserva(ReservaObj reserva)
        {
            using (var con = new LaCabanaKNEntities())
            {


                var reservaExistente = (from x in con.Reserva where x.IDReserva == reserva.IdReserva select x).SingleOrDefault();

                reservaExistente.IDHabitacion = reserva.IdHabitacion;
                reservaExistente.IDActividad = reserva.IdActividad;
                reservaExistente.CedulaEmpleado = reserva.CedulaEmpleado;
                reservaExistente.CedulaUsuario = reserva.CedulaUsuario;
                reservaExistente.Descuento = reserva.Descuento;
                reservaExistente.FechaCreacion = reserva.FechaCreacion;
                reservaExistente.FechaFinal = reserva.FechaFinal;
                reservaExistente.IDHabitacion = reserva.IdHabitacion;
                reservaExistente.FechaInicio = reserva.FechaInicio;
                reservaExistente.PrecioActividades = reserva.PrecioActividad;
                reservaExistente.PrecioTotal = reserva.PrecioTotal;

                var resultado = con.SaveChanges();


                RespuestaReservaObj respuesta = new RespuestaReservaObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Reserva Actualizada Correctamente";
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