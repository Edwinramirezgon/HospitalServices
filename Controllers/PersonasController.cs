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
    [RoutePrefix("api/Personas")]
    public class PersonasController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Persona persona)
        {

            clsPersona _persona = new clsPersona();
            _persona.persona = persona;
            return _persona.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Persona persona)
        {

            clsPersona _persona = new clsPersona();
            _persona.persona = persona;
            return _persona.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Persona persona)
        {
            clsPersona _persona = new clsPersona();
            _persona.persona = persona;
            return _persona.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Persona ConsultarXID(long id)
        {

            clsPersona _persona = new clsPersona();
            return _persona.Consultar(id);
        }
       
    }
}