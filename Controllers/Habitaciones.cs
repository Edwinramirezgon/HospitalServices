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
    [RoutePrefix("api/Habitaciones")]
    public class HabitacionesController : ApiController
    {
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Habitacione habitacion)
        {

            clsHabitacione _habitacion = new clsHabitacione();
            _habitacion.habitacion = habitacion;
            return _habitacion.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Habitacione habitacion)
        {

            clsHabitacione _habitacion = new clsHabitacione();
            _habitacion.habitacion = habitacion;
            return _habitacion.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Habitacione habitacion)
        {
            clsHabitacione _habitacion = new clsHabitacione();
            _habitacion.habitacion = habitacion;
            return _habitacion.Eliminar();
        }
        [HttpGet]
        [Route("ConsultarXID")]
        public Habitacione ConsultarXID(int id)
        {

            clsHabitacione _habitacion = new clsHabitacione();
            return _habitacion.Consultar(id);
        }
    }
}