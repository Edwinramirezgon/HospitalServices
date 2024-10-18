using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsRegistroUrgencias
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();
        public EventosMedico evento { get; set; }

        public string Insertar(int idevento, string estado, int idhospitalizacion)
        {
            try
            {
                dbSuper.EventosMedicos.Add(evento);
                dbSuper.SaveChanges();
                Urgencia urgencia = new Urgencia();
                urgencia.id_evento = idevento;
                urgencia.estado_urgencia = estado;
                urgencia.id_hospitalizacion = idhospitalizacion;
                dbSuper.Urgencias.Add(urgencia);
                dbSuper.SaveChanges();
                return "Se grabó la urgencia del parciente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar(int idevento, string estado, int idhospitalizacion)
        {

            try
            {
                EventosMedico _evento = Consultar(evento.id_evento);
                Urgencia _urgencia = Consultar2(evento.id_evento);
                if (_evento != null && _urgencia != null)
                {
                    dbSuper.EventosMedicos.AddOrUpdate(evento);
                    dbSuper.SaveChanges();
                    Urgencia urgencia = new Urgencia();
                    urgencia.id_evento = idevento;
                    urgencia.estado_urgencia = estado;
                    urgencia.id_hospitalizacion = idhospitalizacion;
                    dbSuper.Urgencias.AddOrUpdate(urgencia);
                    dbSuper.SaveChanges();
                    return "Se actualizaron los datos de la urgencia";
                }
                else
                {
                    return "La urgencia que se quiere actualizar, no existe en la base de datos";
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
            dbSuper.SaveChanges();
            dbSuper.EventosMedicos.Remove(_evento);
            dbSuper.SaveChanges();
            return "Se eliminó la urgencia";
        }
        public EventosMedico Consultar(long id)
        {

            return dbSuper.EventosMedicos.FirstOrDefault(ev => ev.id_evento == id);
        }

        public Urgencia Consultar2(long id)
        {

            return dbSuper.Urgencias.FirstOrDefault(u => u.id_evento == id);
        }

        public IQueryable LLenarTabla()
        {

            return from u in dbSuper.Set<Urgencia>()
                   join em in dbSuper.Set<EventosMedico>()
                   on u.id_evento equals em.id_evento
                   join pa in dbSuper.Set<Paciente>()
                   on em.id_paciente equals pa.id_paciente
                   join m in dbSuper.Set<Medico>()
                   on em.id_medico equals m.id_medico
                   join pe in dbSuper.Set<Persona>()
                   on pa.id_persona equals pe.id_persona
                   join us in dbSuper.Set<Usuario>()
                   on m.id_usuario equals us.id_usuario
                   join per in dbSuper.Set<Persona>()
                   on us.id_persona equals per.id_persona
                   orderby pe.nombre
                   select new
                   {
                       ID_URGENCIA = u.id_urgencia,
                       ID_PACIENTE = pe.id_persona,
                       NOMBRES = pe.nombre,
                       APELLIDOS = pe.apellido,
                       FECHA_URGENCIA = em.fecha_evento,
                       MEDICO_TRATANTE = per.nombre,
                       CONTACTO_DE_EMERGENCIA = pa.contacto_emergencia,
                       ALERGIAS = pa.alergias,
                       ANTECEDENTES = pa.antecedentes_medicos,
                       DESCRIPCION_URGENCIA = em.descripcion
                   };


        }
    }
}