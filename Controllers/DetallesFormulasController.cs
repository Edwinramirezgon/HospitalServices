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
    [RoutePrefix("api/DetallesFormulas")]
    public class DetallesFormulasController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] DetallesFormula detalle)
        {

            clsDetallesFormula _detalle = new clsDetallesFormula();
            _detalle.detalle = detalle;
            return _detalle.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] DetallesFormula detalle)
        {

            clsDetallesFormula _detalle = new clsDetallesFormula();
            _detalle.detalle = detalle;
            return _detalle.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] DetallesFormula detalle)
        {
            clsDetallesFormula _detalle = new clsDetallesFormula();
            _detalle.detalle = detalle;
            return _detalle.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public DetallesFormula ConsultarXID(int id)
        {

            clsDetallesFormula _detalle = new clsDetallesFormula();
            return _detalle.Consultar(id);
        }
    }
}