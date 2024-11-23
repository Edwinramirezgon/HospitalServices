using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace HospitalServices.Clases
{
    public class clsRegistroUrgencias
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();
        public EventosMedico evento { get; set; }


        public string Insertar(string estado_urgencia)
        {
            try
            {

                dbSuper.EventosMedicos.Add(evento);
                dbSuper.SaveChanges();
                Urgencia urgencia = new Urgencia();
                urgencia.id_evento = evento.id_evento;
                urgencia.estado_urgencia = estado_urgencia;
                dbSuper.Urgencias.Add(urgencia);
                dbSuper.SaveChanges();
                return "Se grabó la urgencia ";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar(string estado_urgencia)
        {

            try
            {
                EventosMedico _evento = Consultar(evento.id_evento);
                Urgencia _urgencia = Consultar2(_evento.id_evento);
                if (_evento != null && _urgencia != null)
                {
                    dbSuper.EventosMedicos.AddOrUpdate(evento);
                    dbSuper.SaveChanges();
                    _urgencia.estado_urgencia = estado_urgencia;
                    dbSuper.Urgencias.AddOrUpdate(_urgencia);
                    dbSuper.SaveChanges();
                    return "Se actualizaron los datos de la urgencia";
                }
                else
                {
                    return "la urgencia que se quiere actualizar, no existe en la base de datos";
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
            Urgencia _urgencia = Consultar2(evento.id_evento);
            if (_evento == null && _urgencia == null)
            {
                return "La urgencia no existe en la base de datos";
            }
            dbSuper.Urgencias.Remove(_urgencia);
            dbSuper.EventosMedicos.Remove(_evento);
            dbSuper.SaveChanges();
          
            dbSuper.SaveChanges();
            return "Se eliminó la urgencia " ;
        }
        public EventosMedico Consultar(int id)
        {

            return dbSuper.EventosMedicos.FirstOrDefault(c => c.id_evento == id);
        }

        public Urgencia Consultar2(int id)
        {

            return dbSuper.Urgencias.FirstOrDefault(c => c.id_evento == id);
        }
        public Persona Consultar3(long id)
        {

            return dbSuper.Personas.FirstOrDefault(c => c.id_persona == id);
        }
        public Usuario Consultar4(int id)
        {

            return dbSuper.Usuarios.FirstOrDefault(c => c.id_usuario == id);
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
                       PACIENTE = pe2.nombre +" "+ pe2.apellido,
                       ID_PACIENTE = pe2.id_persona,                     
                       MEDICO = pe.nombre +" " + pe.apellido,
                       FECHA_DE_URGENCIA = ev.fecha_evento.ToString().Substring(0, 10),
                       DESCRIPCION_DE_URGENCIA = ev.descripcion,
                       ESTADO_DE_URGENCIA = ur.estado_urgencia,

                         EDITAR = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-lg btn-warning\" onclick=\"abrirModalEditar('"
        + ur.id_urgencia + "', '"
        + ev.id_paciente + "', '"
         + ev.id_medico + "', '"
        + ev.fecha_evento + "', '"       
        + ev.descripcion.Substring(0,500) + "', '"    
        + ur.estado_urgencia + "')\">EDITAR</button>",

                       ELIMINAR = "<button type=\"button\" id=\"btnEliminar\" class=\"btn-block btn-lg btn-danger\" onclick=\"Eliminar('"
        + ur.id_urgencia + "')\">ELIMINAR</button>"

                   };


        }



        public IQueryable LlenarCombo()
        {
            return (from paciente in dbSuper.Pacientes
                    join persona in dbSuper.Personas on paciente.id_persona equals persona.id_persona
                    orderby paciente.id_paciente
                    select new
                    {
                        Codigo = paciente.id_paciente,
                        Nombre = persona.nombre + " " + persona.apellido + " ID " + persona.id_persona
                    });
        }

        public IQueryable LlenarCombo2()
        {
            return (from medico in dbSuper.Medicos
                    join usuario in dbSuper.Usuarios on medico.id_usuario equals usuario.id_usuario
                    join persona in dbSuper.Personas on usuario.id_persona equals persona.id_persona
                    orderby medico.id_medico
                    select new
                    {
                        Codigo = medico.id_medico,
                        Nombre = persona.nombre +" " + persona.apellido + " ID " + persona.id_persona
                    });
        }
       


    }
}