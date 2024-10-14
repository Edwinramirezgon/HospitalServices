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
    [RoutePrefix("api/Medicos")]
    public class MedicosController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Medico medico)
        {

            clsMedico _medico = new clsMedico();
            _medico.medico = medico;
            return _medico.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Medico medico)
        {


            clsMedico _medico = new clsMedico();
            _medico.medico = medico;
            return _medico.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Medico medico)
        {

            clsMedico _medico = new clsMedico();
            _medico.medico = medico;
            return _medico.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Medico ConsultarXID(int id)
        {

            clsMedico _medico = new clsMedico();
            return _medico.Consultar(id);
        }
    }
}