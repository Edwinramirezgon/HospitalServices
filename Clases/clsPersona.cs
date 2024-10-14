using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsPersona
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Persona persona { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Personas.Add(persona);
                dbSuper.SaveChanges();
                return "Se grabó la persona " + persona.nombre + " " + persona.apellido;
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
                dbSuper.Personas.AddOrUpdate(persona);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de la persona con id: " + persona.id_persona;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Persona _persona = Consultar(persona.id_persona);
            if (_persona == null)
            {
                return "la persona no existe en la base de datos";
            }
            dbSuper.Personas.Remove(_persona);
            dbSuper.SaveChanges();
            return "Se eliminó la persona: " + _persona.nombre + " " + _persona.apellido;
        }
        public Persona Consultar(long id)
        {

            return dbSuper.Personas.FirstOrDefault(c => c.id_persona == id);
        }
    }
}