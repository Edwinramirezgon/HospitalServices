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
    [RoutePrefix("api/Pagos")]
    [Authorize]

    public class PagosController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Pago pago)
        {

            clsPago _pago = new clsPago();
            _pago.pago = pago;
            return _pago.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Pago pago)
        {

            clsPago _pago = new clsPago();
            _pago.pago = pago;
            return _pago.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Pago pago)
        {
            clsPago _pago = new clsPago();
            _pago.pago = pago;
            return _pago.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Pago ConsultarXID(int id)
        {

            clsPago _pago = new clsPago();
            return _pago.Consultar(id);
        }
    }
}