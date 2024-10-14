using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsMedico
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Medico medico { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Medicos.Add(medico);
                dbSuper.SaveChanges();
                return "Se grabó el medico";
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
                dbSuper.Medicos.AddOrUpdate(medico);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de el medico con id: " + medico.id_medico;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Medico _medico = Consultar(medico.id_medico);
            if (_medico == null)
            {
                return "el medico no existe en la base de datos";
            }
            dbSuper.Medicos.Remove(_medico);
            dbSuper.SaveChanges();
            return "Se eliminó el medico ";
        }
        public Medico Consultar(int id)
        {

            return dbSuper.Medicos.FirstOrDefault(c => c.id_medico == id);
        }
    }
}