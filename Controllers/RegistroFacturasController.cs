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
    [RoutePrefix("api/RegistroFacturas")]
    [Authorize]
    public class RegistroFacturasController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Facturacione factura)
        {

            clsRegistroFacturas _factura = new clsRegistroFacturas();
            _factura.factura = factura;
            return _factura.Insertar();
        }


        [HttpGet]
        [Route("NFactura")]
        public int obtenerIDFac()
        {

            clsRegistroFacturas _alta = new clsRegistroFacturas();


            int nuevoIdFormula = _alta.obtenerIDFactura();


            return nuevoIdFormula;
        }


        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla(string id)
        {
            clsRegistroFacturas evento = new clsRegistroFacturas();
            return evento.LLenarTabla(id);
        }
    }

    
}