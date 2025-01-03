﻿using HospitalServices.Clases;
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
    [Authorize]

    public class RegistroMedicosController : ApiController
    {


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Persona persona, int id_persona, string Tipo, string rol, string Mensaje, string Pagina, string especialidad, string horario, string contacto, string password)
        {

            clsRegistroMedicos _persona = new clsRegistroMedicos();
            _persona.persona = persona;
            return _persona.Insertar(id_persona, Tipo, rol, Mensaje, Pagina, especialidad, horario, contacto, password);
        }
 


        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Persona persona, int id_persona, string Tipo, string rol, string Mensaje, string Pagina, string especialidad, string horario, string contacto, string password)
        {

            clsRegistroMedicos _persona = new clsRegistroMedicos();
            _persona.persona = persona;
            return _persona.Actualizar(id_persona, Tipo, rol, Mensaje, Pagina, especialidad, horario, contacto, password);
        }


        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Persona persona)
        {
            clsRegistroMedicos _persona = new clsRegistroMedicos();
            _persona.persona = persona;
            return _persona.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Persona ConsultarXID(long id)
        {

            clsRegistroMedicos _persona = new clsRegistroMedicos();
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

        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsRegistroMedicos medico = new clsRegistroMedicos();
            return medico.LlenarCombo();
        }
    }

}
