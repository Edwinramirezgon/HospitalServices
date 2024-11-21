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
    [RoutePrefix("api/Altas")]
    [Authorize]

    public class AltasController : ApiController
    {


        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Alta alta)
        {

            clsAlta _alta = new clsAlta();
            _alta.alta = alta;
            return _alta.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Alta alta)
        {

            clsAlta _alta = new clsAlta();
            _alta.alta = alta;
            return _alta.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Alta alta)
        {
            clsAlta _alta = new clsAlta();
            _alta.alta = alta;
            return _alta.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Alta ConsultarXID(int id)
        {

            clsAlta _alta = new clsAlta();
            return _alta.Consultar(id);
        }
    }
}