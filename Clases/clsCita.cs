using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsCita
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Cita cita { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Citas.Add(cita);
                dbSuper.SaveChanges();
                return "Se grabó la cita";
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
                Cita _cita = Consultar(cita.id_cita);
                if (_cita != null)
                {
                    dbSuper.Citas.AddOrUpdate(cita);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de la cita con id: " + cita.id_cita;
                }
                else
                {
      
                    return "La cita que se quiere actualizar, no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Cita _cita = Consultar(cita.id_cita);
            if (_cita == null)
            {
                return "la cita no existe en la base de datos";
            }
            dbSuper.Citas.Remove(_cita);
            dbSuper.SaveChanges();
            return "Se eliminó la cita";
        }
        public Cita Consultar(int id)
        {

            return dbSuper.Citas.FirstOrDefault(c => c.id_cita == id);
        }
    }
}