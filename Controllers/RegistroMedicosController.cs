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
    [RoutePrefix("api/RegistroMedicos")]
    public class RegistroMedicosController : ApiController
    {


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Persona persona, int id_persona, string usuario1, string rol, string especialidad, string horario, string contacto)
        {

            clsRegistroMedicos _persona = new clsRegistroMedicos();
            _persona.persona = persona;
            return _persona.Insertar(id_persona, usuario1, rol, especialidad, horario, contacto);
        }



        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Persona persona, int id_persona, string usuario1, string rol, string especialidad, string horario, string contacto)
        {

            clsRegistroMedicos _persona = new clsRegistroMedicos();
            _persona.persona = persona;
            return _persona.Actualizar(id_persona, usuario1, rol, especialidad, horario, contacto);
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
        public Usuario ConsultarXIDp(long id)
        {

            clsRegistroMedicos _medicos = new clsRegistroMedicos();
            return _medicos.Consultar2(id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsRegistroMedicos medicos = new clsRegistroMedicos();
            return medicos.LLenarTabla();
        }

    }
}