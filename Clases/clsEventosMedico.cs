using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsEventosMedico
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public EventosMedico evento { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.EventosMedicos.Add(evento);
                dbSuper.SaveChanges();
                return "Se grabó el evento medico";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar()
        {

            try
            {
                EventosMedico _evento = Consultar(evento.id_evento);
                if (_evento != null)
                {
                    dbSuper.EventosMedicos.AddOrUpdate(evento);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de el evento medico: " + evento.id_evento;
                }
                else
                {
                    return "El evento medico que se quiere actualizar, no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            EventosMedico _evento = Consultar(evento.id_evento);
            if (_evento == null)
            {
                return "el evento medico no existe en la base de datos";
            }
            dbSuper.EventosMedicos.Remove(_evento);
            dbSuper.SaveChanges();
            return "Se eliminó el evento medico";
        }
        public EventosMedico Consultar(int id)
        {

            return dbSuper.EventosMedicos.FirstOrDefault(c => c.id_evento == id);
        }


        public IQueryable LLenarTabla()
        {

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
                   select new
                   {
                       ID_URGENCIA = ur.id_urgencia,
                       PACIENTE = pe2.nombre + " " + pe2.apellido,
                       ID_PACIENTE = pe2.id_persona,
                       MEDICO = pe.nombre + " " + pe.apellido,
                       FECHA_DE_URGENCIA = ev.fecha_evento.ToString().Substring(0, 10),
                       DESCRIPCION_DE_URGENCIA = ev.descripcion,
                       ESTADO_DE_URGENCIA = ur.estado_urgencia,

                       ASIGNAR = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-lg btn-success\" onclick=\"abrirModalAsignar('"
        + ev.id_evento + "', '"
        + ev.id_paciente + "', '"
         + ev.id_medico + "', '"
        + ev.fecha_evento + "', '"
        + ev.descripcion.Substring(0, 500) + "', '"
        + ur.estado_urgencia + "')\">ASIGNAR</button>",

                       ELIMINAR = "<button type=\"button\" id=\"btnEliminar\" class=\"btn-block btn-lg btn-danger\" onclick=\"Eliminar('"
        + ur.id_urgencia + "')\">ELIMINAR</button>"

                   };


        }

    }
    }
