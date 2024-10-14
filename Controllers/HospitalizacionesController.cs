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
    [RoutePrefix("api/Hospitalizaciones")]
    public class HospitalizacionesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Hospitalizacione hozpitalizacion)
        {

            clsHospitalizacione _hozpitalizacion = new clsHospitalizacione();
            _hozpitalizacion.hospitalizacion = hozpitalizacion;
            return _hozpitalizacion.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Hospitalizacione hozpitalizacion)
        {

            clsHospitalizacione _hozpitalizacion = new clsHospitalizacione();
            _hozpitalizacion.hospitalizacion = hozpitalizacion;
            return _hozpitalizacion.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Hospitalizacione hozpitalizacion)
        {
            clsHospitalizacione _hozpitalizacion = new clsHospitalizacione();
            _hozpitalizacion.hospitalizacion = hozpitalizacion;
            return _hozpitalizacion.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Hospitalizacione ConsultarXID(int id)
        {

            clsHospitalizacione _hozpitalizacion = new clsHospitalizacione();
            return _hozpitalizacion.Consultar(id);
        }
    }
}