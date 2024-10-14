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
    [RoutePrefix("api/Urgencias")]
    public class UrgenciasController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Urgencia urgencia)
        {

            clsUrgencia _urgencia = new clsUrgencia();
            _urgencia.urgencia = urgencia;
            return _urgencia.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Urgencia urgencia)
        {

            clsUrgencia _urgencia = new clsUrgencia();
            _urgencia.urgencia = urgencia;
            return _urgencia.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Urgencia urgencia)
        {
            clsUrgencia _urgencia = new clsUrgencia();
            _urgencia.urgencia = urgencia;
            return _urgencia.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Urgencia ConsultarXID(int id)
        {

            clsUrgencia _urgencia = new clsUrgencia();
            return _urgencia.Consultar(id);
        }
    }
}