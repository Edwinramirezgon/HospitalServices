using HospitalServices.Clases;
using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Http;

namespace HospitalServices.Controllers
{
    [EnableCors(origins: "https://localhost:44306", headers: "*", methods: "*")]
    [RoutePrefix("api/RegistroUrgencias")]
    public class RegistroUrgenciasController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] EventosMedico evento, int idevento, string estado, int idhospitalizacion)
        {

            clsRegistroUrgencias _evento = new clsRegistroUrgencias();
            _evento.evento = evento;
            return _evento.Insertar(idevento, estado, idhospitalizacion);
        }



        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] EventosMedico evento, int idevento, string estado, int idhospitalizacion)
        {

            clsRegistroUrgencias _evento = new clsRegistroUrgencias();
            _evento.evento = evento;
            return _evento.Actualizar(idevento, estado, idhospitalizacion);
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] EventosMedico evento)
        {
            clsRegistroUrgencias _evento = new clsRegistroUrgencias();
            _evento.evento = evento;
            return _evento.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public EventosMedico ConsultarXID(long id)
        {

            clsRegistroUrgencias _evento = new clsRegistroUrgencias();
            return _evento.Consultar(id);
        }

        [HttpGet]
        [Route("ConsultarXIDp")]
        public Urgencia ConsultarXIDp(long id)
        {

            clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            return _urgencia.Consultar2(id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
            clsRegistroUrgencias urgencia = new clsRegistroUrgencias();
            return urgencia.LLenarTabla();
        }
    }
}