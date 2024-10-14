using HospitalServices.Clases;
using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HospitalServices.Controllers
{
    [EnableCors(origins: "https://localhost:44306", headers: "*", methods: "*")]
    [RoutePrefix("api/Usuarios")]
    public class UsuariosController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Usuario usuario)
        {

            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Usuario usuario)
        {

            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Usuario usuario)
        {
            clsUsuario _usuario = new clsUsuario();
            _usuario.usuario = usuario;
            return _usuario.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Usuario ConsultarXID(int id)
        {

            clsUsuario _usuario = new clsUsuario();
            return _usuario.Consultar(id);
        }
    }
}