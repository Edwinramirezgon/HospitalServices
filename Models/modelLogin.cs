using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices
{
    public class Login
    {
        public long Usuario { get; set; }
        public string Clave { get; set; }
        public string PaginaSolicitud { get; set; }
    }
    public class LoginRespuesta
    {
        public long Usuario { get; set; }
        public string Perfil { get; set; }
        public string PaginaInicio { get; set; }
        public string Tipo { get; set; }
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public string Mensaje { get; set; }
    }
}