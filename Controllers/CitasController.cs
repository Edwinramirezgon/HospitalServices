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
    [RoutePrefix("api/Citas")]
    [Authorize]

    public class CitasController : ApiController
    {

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cita cita)
        {

            clsCita _cita = new clsCita();
            _cita.cita = cita;
            return _cita.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Cita cita)
        {

            clsCita _cita = new clsCita();
            _cita.cita = cita;
            return _cita.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Cita cita)
        {
            clsCita _cita = new clsCita();
            _cita.cita = cita;
            return _cita.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Cita ConsultarXID(int id)
        {

            clsCita _cita = new clsCita();
            return _cita.Consultar(id);
        }
    }
}