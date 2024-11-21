using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsLogin
    {

        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        hospital_dbEntities dbSuper = new hospital_dbEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        public bool ValidarUsuario()
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                Usuario usuario = dbSuper.Usuarios.FirstOrDefault(u => u.id_persona == login.Usuario);
                if (usuario == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
                byte[] arrBytesSalt = Convert.FromBase64String(usuario.Salt);
                string ClaveCifrada = cifrar.HashPassword(login.Clave, arrBytesSalt);
                login.Clave = ClaveCifrada;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario.ToString());
                return from U in dbSuper.Set<Usuario>()
                       join pe in dbSuper.Set<Persona>()
                       on U.id_persona equals pe.id_persona                       
                       where U.id_persona == login.Usuario &&
                             U.Password == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.id_persona,
                           Autenticado = true,
                           Perfil = pe.nombre + " " + pe.apellido,
                           PaginaInicio = "HOME.html",
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                //return (IQueryable<LoginRespuesta>)loginRespuesta;
                return null;
            }
        }
    }
}