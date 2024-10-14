using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsPaciente
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Paciente paciente { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Pacientes.Add(paciente);
                dbSuper.SaveChanges();
                return "Se grabó el paciente";
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
                dbSuper.Pacientes.AddOrUpdate(paciente);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de el paciente con id: " + paciente.id_paciente;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Paciente _paciente = Consultar(paciente.id_paciente);
            if (_paciente == null)
            {
                return "el paciente no existe en la base de datos";
            }
            dbSuper.Pacientes.Remove(_paciente);
            dbSuper.SaveChanges();
            return "Se eliminó el paciente ";
        }
        public Paciente Consultar(int id)
        {

            return dbSuper.Pacientes.FirstOrDefault(c => c.id_paciente == id);
        }
    }
}