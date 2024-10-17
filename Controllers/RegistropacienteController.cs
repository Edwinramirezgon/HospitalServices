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
    [RoutePrefix("api/RegistroPacientes")]
    public class RegistropacienteController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Persona persona, int idpersona, string contacto, string alergias, string antecedentes)
        {

            clsRegistroPaciente _persona = new clsRegistroPaciente();
            _persona.persona = persona;
            return _persona.Insertar(idpersona, contacto, alergias, antecedentes);
        }

       

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Persona persona, int idpersona, string contacto, string alergias, string antecedentes)
        {

            clsRegistroPaciente _persona = new clsRegistroPaciente();
            _persona.persona = persona;
            return _persona.Actualizar(idpersona, contacto, alergias, antecedentes);
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Persona persona)
        {
            clsRegistroPaciente _persona = new clsRegistroPaciente();
            _persona.persona = persona;
            return _persona.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Persona ConsultarXID(long id)
        {

            clsRegistroPaciente _persona = new clsRegistroPaciente();
            return _persona.Consultar(id);
        }

        [HttpGet]
        [Route("ConsultarXIDp")]
        public Paciente ConsultarXIDp(long id)
        {

            clsRegistroPaciente _paciente = new clsRegistroPaciente();
            return _paciente.Consultar2(id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsRegistroPaciente paciente = new clsRegistroPaciente();
            return paciente.LLenarTabla();
        }

    }
}