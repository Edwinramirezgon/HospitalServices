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
    [RoutePrefix("api/EventosMedicos")]
    [Authorize]

    public class EventosMedicosController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] EventosMedico evento)
        {

            clsEventosMedico _evento = new clsEventosMedico();
            _evento.evento = evento;
            return _evento.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] EventosMedico evento)
        {
            clsEventosMedico _evento = new clsEventosMedico();
            _evento.evento = evento;
            return _evento.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] EventosMedico evento)
        {
            clsEventosMedico _evento = new clsEventosMedico();
            _evento.evento = evento;
            return _evento.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public EventosMedico ConsultarXID(int id)
        {

            clsEventosMedico _evento = new clsEventosMedico();
            return _evento.Consultar(id);
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla()
        {
           clsEventosMedico evento = new clsEventosMedico();
            return evento.LLenarTabla();
        }
        
    }


}