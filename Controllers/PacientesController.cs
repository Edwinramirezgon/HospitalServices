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
    [RoutePrefix("api/Pacientes")]
    public class PacientesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Paciente paciente)
        {

            clsPaciente _paciente = new clsPaciente();
            _paciente.paciente = paciente;
            return _paciente.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Paciente paciente)
        {

            clsPaciente _paciente = new clsPaciente();
            _paciente.paciente = paciente;
            return _paciente.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Paciente paciente)
        {
            clsPaciente _paciente = new clsPaciente();
            _paciente.paciente = paciente;
            return _paciente.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Paciente ConsultarXID(int id)
        {

            clsPaciente _paciente = new clsPaciente();
            return _paciente.Consultar(id);
        }


        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsPaciente paciente = new clsPaciente();
            return paciente.LLenarTabla();
        }
    }
}