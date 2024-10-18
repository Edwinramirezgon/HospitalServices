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
            public string Insertar([FromBody] EventosMedico urgencia, string estado_urgencia)
            {

                clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            _urgencia.evento = urgencia;
                return _urgencia.Insertar(estado_urgencia);
            }



            [HttpPut]
            [Route("Actualizar")]
            public string Actualizar([FromBody] EventosMedico urgencia, string estado_urgencia)
            {

            clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            _urgencia.evento = urgencia;
            return _urgencia.Actualizar(estado_urgencia);
            }
            [HttpDelete]
            [Route("Eliminar")]
            public string Eliminar([FromBody] EventosMedico urgencia)
            {
            clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            _urgencia.evento = urgencia;
            return _urgencia.Eliminar();
            }
            [HttpGet]
            [Route("ConsultarXID")]
            public EventosMedico ConsultarXID(int id)
            {

            clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            return _urgencia.Consultar(id);
            }

            [HttpGet]
            [Route("ConsultarXID2")]
            public Urgencia ConsultarXID2(int id)
            {

            clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            return _urgencia.Consultar2(id);
            }


        [HttpGet]
        [Route("ConsultarXID3")]
        public Persona ConsultarXID3(int id)
        {

            clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            return _urgencia.Consultar3(id);
        }

        [HttpGet]
        [Route("ConsultarXID4")]
        public Usuario ConsultarXID4(int id)
        {

            clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            return _urgencia.Consultar4(id);
        }



        [HttpGet]
            [Route("LlenarTabla")]
            public IQueryable LlenarTabla()
            {
            clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            return _urgencia.LLenarTabla();
            }

            [HttpGet]
            [Route("LlenarCombo")]
            public IQueryable LlenarCombo()
            {
            clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            return _urgencia.LlenarCombo();
            }

        [HttpGet]
        [Route("LlenarCombo2")]
        public IQueryable LlenarCombo2()
        {
            clsRegistroUrgencias _urgencia = new clsRegistroUrgencias();
            return _urgencia.LlenarCombo2();
        }
    }
    }