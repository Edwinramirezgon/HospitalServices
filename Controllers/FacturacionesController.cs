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
    [RoutePrefix("api/Facturaciones")]
    public class FacturacionesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Facturacione facturacion)
        {

            clsFacturacion _facturacion = new clsFacturacion();
            _facturacion.facturacion = facturacion;
            return _facturacion.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Facturacione facturacion)
        {

            clsFacturacion _facturacion = new clsFacturacion();
            _facturacion.facturacion = facturacion;
            return _facturacion.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Facturacione facturacion)
        {
            clsFacturacion _facturacion = new clsFacturacion();
            _facturacion.facturacion = facturacion;
            return _facturacion.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Facturacione ConsultarXID(int id)
        {

            clsFacturacion _facturacion = new clsFacturacion();
            return _facturacion.Consultar(id);
        }
    }
}