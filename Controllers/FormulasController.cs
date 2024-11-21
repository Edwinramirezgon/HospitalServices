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
    [RoutePrefix("api/Formulas")]
    [Authorize]

    public class FormulasController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Formula formula)
        {

            clsFormula _formula = new clsFormula();
            _formula.formula = formula;
            return _formula.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Formula formula)
        {

            clsFormula _formula = new clsFormula();
            _formula.formula = formula;
            return _formula.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Formula formula)
        {
            clsFormula _formula = new clsFormula();
            _formula.formula = formula;
            return _formula.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Formula ConsultarXID(int id)
        {

            clsFormula _formula = new clsFormula();
            return _formula.Consultar(id);
        }
    }
}