

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
                var resultado = new Usuario();

                resultado = (from x in con.Usuario where x.Contrasenna == usuario.Contrasenna select x).SingleOrDefault();

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                if (resultado != null)
                {
                    UsuarioObj usuarioExistente = new UsuarioObj();

                    usuarioExistente.Cedula = resultado.Cedula;
                    usuarioExistente.Correo = resultado.Correo;
                    usuarioExistente.Nombre = resultado.Nombre;
                    usuarioExistente.ApePaterno = resultado.ApePaterno;
                    usuarioExistente.ApeMaterno = resultado.ApeMaterno;
                    usuarioExistente.Telefono = resultado.Telefono;
                    usuarioExistente.Token = CrearToken(usuario.Correo);

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.objeto = usuarioExistente;
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
                var nuevoUsuario = new Usuario { Nombre = usuario.Nombre, Correo = usuario.Correo, Cedula = usuario.Cedula, Contrasenna = usuario.Contrasenna, ApePaterno = usuario.ApePaterno, ApeMaterno = usuario.ApeMaterno, Telefono = usuario.Telefono };
                con.Usuario.Add(nuevoUsuario);
                var resultado = con.SaveChanges();

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Usuario Registrado Correctamente";
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

            var llave = "laCabanaRemix2022";
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