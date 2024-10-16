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

        public IQueryable LLenarTabla()
        {

            return from pa in dbSuper.Set<Paciente>()
                   join pe in dbSuper.Set<Persona>()
                   on pa.id_persona equals pe.id_persona
                   orderby pe.nombre
                   select new
                   { 
                       ID = pe.id_persona,
                       NOMBRES = pe.nombre,
                       APELLIDOS = pe.apellido,
                       FECHA_DE_NACIMIENTO = pe.fecha_nacimiento,
                       DIRECCION = pe.direccion,
                       TELEFONO = pe.telefono,
                       EMAIL = pe.email,
                       GENERO = pe.genero,
                       CONTACTO_DE_EMERGEMCIA = pa.contacto_emergencia,
                       ALERGIAS = pa.alergias,
                       ANTECEDENTES = pa.antecedentes_medicos
                   
                   };

        }
    }
}