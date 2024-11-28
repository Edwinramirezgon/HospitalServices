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
    [RoutePrefix("api/RegistroFormulas")]
    [Authorize]
    public class RegistroFormulasController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Formula formula)
        {

            clsRegistroFormulas _formula = new clsRegistroFormulas();
            _formula.formula = formula;
            return _formula.Insertar();
        }


        [HttpGet]
        [Route("NFormula")]
        public int GenerarNumeroFormula()
        {

            clsRegistroFormulas _alta = new clsRegistroFormulas();


            int nuevoIdFormula = _alta.GenerarNumeroFormula();


            return nuevoIdFormula;
        }

        [HttpGet]
        [Route("LlenarCombo")]
        public IQueryable LlenarCombo()
        {
            clsRegistroFormulas medicamento = new clsRegistroFormulas();
            return medicamento.LlenarCombo();
        }

        [HttpGet]
        [Route("LlenarTabla")]
        public IQueryable LlenarTabla(string id)
        {
            clsRegistroFormulas evento = new clsRegistroFormulas();
            return evento.LLenarTabla(id);
        }
    }
}