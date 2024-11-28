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
        [Route("GrabarFormula")]
        public string GrabarFormula([FromBody] Formula formula)
        {
            clsRegistroFormulas Formula = new clsRegistroFormulas();
            Formula.formula = formula;
            return Formula.GrabarFormula();
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