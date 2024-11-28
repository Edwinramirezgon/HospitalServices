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
    [RoutePrefix("api/Medicamentos")]
    [Authorize]

    public class MedicamentosController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Medicamento medicamento)
        {

            clsMedicamento _medicamento = new clsMedicamento();
            _medicamento.medicamento = medicamento;
            return _medicamento.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Medicamento medicamento)
        {

            clsMedicamento _medicamento = new clsMedicamento();
            _medicamento.medicamento = medicamento;
            return _medicamento.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Medicamento medicamento)
        {
            clsMedicamento _medicamento = new clsMedicamento();
            _medicamento.medicamento = medicamento;
            return _medicamento.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Medicamento ConsultarXID(int id)
        {

            clsMedicamento _medicamento = new clsMedicamento();
            return _medicamento.Consultar(id);
        }        
    }
}