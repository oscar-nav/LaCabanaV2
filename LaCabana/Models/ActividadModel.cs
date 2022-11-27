using LaCabana.BD;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace LaCabana.Models
{
    public class ActividadModel
    {

        public RespuestaActividadObj Crear_Actividad(ActividadObj actividad)
        {
            using (var con = new LaCabanaKNEntities())
            {
                var nuevaActividad = new Actividad
                {
                    IDActividad = actividad.IDActividad,
                    Nombre = actividad.Nombre,
                    Descripcion = actividad.Descripcion,
                    Lugar = actividad.Lugar,
                    Precio = actividad.Precio
                };

                con.Actividad.Add(nuevaActividad);
                var resultado = con.SaveChanges();

                RespuestaActividadObj respuesta = new RespuestaActividadObj();

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

        public RespuestaActividadObj Validar_Actividad(ActividadObj activdad)
        {
            using (var con = new LaCabanaKNEntities())
            {
                var resultado = new Actividad();

                resultado = (from x in con.Actividad where x.Nombre == activdad.Nombre select x).SingleOrDefault();

                RespuestaActividadObj respuesta = new RespuestaActividadObj();

                if (resultado != null)
                {
                    ActividadObj actividadExistente = new ActividadObj();

                    actividadExistente.IDActividad = resultado.IDActividad;
                    actividadExistente.Nombre = resultado.Nombre;
                    actividadExistente.Descripcion = resultado.Descripcion;
                    actividadExistente.Disponibilidad = resultado.Disponibilidad;
                    actividadExistente.Lugar = resultado.Lugar;
                    actividadExistente.Precio = (float)resultado.Precio;

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.objeto = actividadExistente;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }

                return respuesta;
            }
        }

        public RespuestaActividadObj Registrar_Actividad(ActividadObj actividad)

        {
            using (var con = new LaCabanaKNEntities())
            {
                var nuevaActividad = new Actividad { Nombre = actividad.Nombre, Descripcion = actividad.Descripcion, Disponibilidad = actividad.Disponibilidad, Lugar = actividad.Lugar, Precio = actividad.Precio };
                con.Actividad.Add(nuevaActividad);
                var resultado = con.SaveChanges();

                RespuestaActividadObj respuesta = new RespuestaActividadObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Actividad Registrada Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción";
                }

                return respuesta;
            }
        }

        public RespuestaActividadObj Eliminar_Actividad(ActividadObj actividad)
        {
            using (var con = new LaCabanaKNEntities())
            {


                var actividadExistente = (from x in con.Actividad where x.IDActividad == actividad.IDActividad select x).SingleOrDefault();
                con.Actividad.Remove(actividadExistente);
                var resultado = con.SaveChanges();

                RespuestaActividadObj respuesta = new RespuestaActividadObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Actividad Eliminada Correctamente";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción de manera exitosa";
                }

                return respuesta;
            }
        }

        public RespuestaActividadObj Actividades(ActividadObj actividad)
        {
            using (var con = new LaCabanaKNEntities())
            {


                var resultado = (from x in con.Actividad select x).ToList();


                RespuestaActividadObj respuesta = new RespuestaActividadObj();


                if (resultado != null)
                {

                    List<ActividadObj> actividades = new List<ActividadObj>();

                    foreach (var r in resultado)
                    {
                        actividades.Add(new ActividadObj
                        {
                            IDActividad = (int)r.IDActividad,
                            Nombre = r.Nombre,
                            Descripcion = r.Descripcion,
                            Disponibilidad = r.Disponibilidad,
                            Precio = (float)r.Precio,
                            Lugar = r.Lugar
                        });
                    }

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Actividades Obtenidas Correctamente";
                    respuesta.lista = actividades;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción de manera exitosa";
                }

                return respuesta;
            }
        }

        public RespuestaActividadObj Modificar_Actividad(ActividadObj actividad)
        {
            using (var con = new LaCabanaKNEntities())
            {


                var actividadExistente = (from x in con.Actividad where x.IDActividad == actividad.IDActividad select x).SingleOrDefault();

                actividadExistente.IDActividad = actividad.IDActividad;
                actividadExistente.Nombre = actividad.Nombre;
                actividadExistente.Descripcion = actividad.Descripcion;
                actividadExistente.Disponibilidad = actividad.Disponibilidad;
                actividadExistente.Precio = actividad.Precio;
                actividadExistente.Lugar = actividad.Lugar;


                var resultado = con.SaveChanges();


                RespuestaActividadObj respuesta = new RespuestaActividadObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Actividad Actualizada Correctamente";
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