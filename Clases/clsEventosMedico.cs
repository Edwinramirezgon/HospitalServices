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
    }
}