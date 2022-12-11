

using LaCabana.BD;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace LaCabana.Models
{
    public class UsuarioModel
    {
        public RespuestaUsuarioObj Validar_Usuario(UsuarioObj usuario)
        {
            using (var con = new LaCabanaKNEntities())
            {
                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                var resultado = (from x in con.Usuario where x.Contrasenna == usuario.Contrasenna select x).SingleOrDefault();

                if (resultado != null)
                {
                    UsuarioObj usuarioEncontrado = new UsuarioObj();

                    usuarioEncontrado.Cedula = resultado.Cedula;
                    usuarioEncontrado.Correo = resultado.Correo;
                    usuarioEncontrado.Nombre = resultado.Nombre;
                    usuarioEncontrado.ApePaterno = resultado.ApePaterno;
                    usuarioEncontrado.ApeMaterno = resultado.ApeMaterno;
                    usuarioEncontrado.Telefono = resultado.Telefono;
                    usuarioEncontrado.Token = CrearToken(usuario.Correo);

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.objeto = usuarioEncontrado;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }

                return respuesta;
            }
        }

        public RespuestaUsuarioObj Registrar_Usuario(UsuarioObj usuario)
        {
            using (var con = new LaCabanaKNEntities())
            {
                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                var existeCorreo = (from x in con.Usuario
                                    where x.Correo == usuario.Correo
                                    select x).FirstOrDefault();

                if (existeCorreo != null)
                {
                    respuesta.Codigo = 2;
                    respuesta.Mensaje = "El correo ya existe";
                    return respuesta;
                }

                var nuevoUsuario = new Usuario
                {
                    Nombre = usuario.Nombre,
                    Cedula = usuario.Cedula,
                    Contrasenna = usuario.Contrasenna,
                    ApePaterno = usuario.ApePaterno,
                    ApeMaterno = usuario.ApeMaterno,
                    Correo = usuario.Correo,
                    Telefono = usuario.Telefono,
                };

                con.Usuario.Add(nuevoUsuario);
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

        public RespuestaUsuarioObj Actualizar_Usuario(UsuarioObj usuario)
        {
            using (var con = new LaCabanaKNEntities())
            {
                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                var existeEmpleado = (from x in con.Usuario
                                      where x.Cedula == usuario.Cedula
                                      select x).FirstOrDefault();

                var nuevoEmpleado = new Usuario
                {
                    Nombre = usuario.Nombre,
                    Cedula = usuario.Cedula,
                    Contrasenna = usuario.Contrasenna,
                    ApePaterno = usuario.ApePaterno,
                    ApeMaterno = usuario.ApeMaterno,
                    Correo  = usuario.Correo,
                    Telefono = usuario.Telefono,
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



        private string CrearToken(string Correo)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, Correo)
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