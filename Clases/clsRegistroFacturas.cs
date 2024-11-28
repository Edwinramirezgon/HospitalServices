using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsRegistroFacturas
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Facturacione factura { get; set; }

        public string Insertar()
        {
            try
            {
                dbSuper.Facturaciones.Add(factura);
                dbSuper.SaveChanges();
                return "Se grabó la factura ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public int obtenerIDFactura()
        {
            return dbSuper.Facturaciones.Select(f => f.id_factura).DefaultIfEmpty(0).Max() + 1;
        }

        public IQueryable LLenarTabla(string id)
        {

            long longId = Convert.ToInt64(id);
            return from ev in dbSuper.Set<EventosMedico>()
                   join ur in dbSuper.Set<Urgencia>()
                   on ev.id_evento equals ur.id_evento
                   join me in dbSuper.Set<Medico>()
                   on ev.id_medico equals me.id_medico
                   join us in dbSuper.Set<Usuario>()
                   on me.id_usuario equals us.id_usuario
                   join pe in dbSuper.Set<Persona>()
                   on us.id_persona equals pe.id_persona
                   join pa in dbSuper.Set<Paciente>()
                   on ev.id_paciente equals pa.id_paciente
                   join pe2 in dbSuper.Set<Persona>()
                   on pa.id_persona equals pe2.id_persona
                   orderby pe2.nombre + " " + pe2.apellido
                   where pa.id_persona == longId
                   select new
                   {
                       ID_EVENTO = ev.id_evento,
                       PACIENTE = pe2.nombre + " " + pe2.apellido,
                       ID_PACIENTE = pe2.id_persona,
                       MEDICO = pe.nombre + " " + pe.apellido,
                       FECHA_DE_EVENTO = ev.fecha_evento.ToString().Substring(0, 10),
                       DESCRIPCION_DE_EVENTO = ev.descripcion,


                       COTIZAR_FACTURA = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-lg btn-success\" onclick=\"abrirModalAsignar('"
        + ev.id_evento + "', '"
        + pa.id_persona + "', '"
        + pa.id_paciente + "', '"
        + pe2.nombre + "', '"
        + pe2.apellido + "', '"
        + me.id_medico + "', '"
        + pe.nombre + "', '"
        + pe.apellido + "', '"
        + ev.fecha_evento + "', '"
        + ev.descripcion + "')\">COTIZAR FACTURA</button>"

                   };
        }
    }
}