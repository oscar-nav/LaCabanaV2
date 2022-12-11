using LaCabana.BD;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Linq;
using System.Security.Claims;
using System.Data.Entity.Migrations;

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
                    empleadoExistente.Token = CrearToken(resultado.Cedula.ToString());
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

        public RespuestaEmpleadoObj Actualizar_Empleado(EmpleadoObj empleado)
        {
            using (var con = new LaCabanaKNEntities())
            {
                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();

                var existeEmpleado = (from x in con.Empleado
                                    where x.Cedula == empleado.Cedula
                                    select x).FirstOrDefault();

                var nuevoEmpleado = new Empleado
                {
                    Nombre = empleado.Nombre,
                    Cedula = empleado.Cedula,
                    Contrasenna = empleado.Contrasenna,
                    ApePaterno = empleado.ApePaterno,
                    ApeMaterno = empleado.ApeMaterno,
                    HorarioDia = empleado.HorarioDia,
                    HorarioHora = empleado.HorarioHora,
                };
                existeEmpleado = nuevoEmpleado;
                var resultado = con.SaveChanges();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción";
                }

                return respuesta;
            }
        }

        public RespuestaEmpleadoObj Consultar_Empleado_Id(long id)
        {
            using (var con = new LaCabanaKNEntities())
            {
                var resultado = (from x in con.Empleado
                                 where x.Cedula == id
                                 select x).FirstOrDefault();

                RespuestaEmpleadoObj respuesta = new RespuestaEmpleadoObj();

                if (resultado != null)
                {
                    EmpleadoObj datos = new EmpleadoObj();

                    datos.Nombre = resultado.Nombre;
                    datos.Cedula = resultado.Cedula;
                    datos.ApePaterno = resultado.ApePaterno;
                    datos.ApeMaterno = resultado.ApeMaterno;
                    datos.HorarioDia = resultado.HorarioDia;
                    datos.HorarioHora = resultado.HorarioHora;

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.objeto = datos;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }

                return respuesta;
            }
        }

        private string CrearToken(string cadena)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, cadena)
            };

            var llave = "lacabaña118150407@";
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(llave));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}