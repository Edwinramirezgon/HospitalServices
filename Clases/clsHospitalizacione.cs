using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsHospitalizacione
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Hospitalizacione hospitalizacion { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Hospitalizaciones.Add(hospitalizacion);
                dbSuper.SaveChanges();
                return "Se grabó la hospitalizacion";
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
                Hospitalizacione _hospitalizacion = Consultar(hospitalizacion.id_hospitalizacion);
                if (_hospitalizacion != null)
                {
                    dbSuper.Hospitalizaciones.AddOrUpdate(hospitalizacion);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de la hospitalizacion con id: " + hospitalizacion.id_hospitalizacion;
                }
                else
                {
                    return "La hospitalizacion que se quiere actualizar, no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Hospitalizacione _hospitalizacion = Consultar(hospitalizacion.id_hospitalizacion);
            if (_hospitalizacion == null)
            {
                return "la hospitalizacion no existe en la base de datos";
            }
            dbSuper.Hospitalizaciones.Remove(_hospitalizacion);
            dbSuper.SaveChanges();
            return "Se eliminó la hospitalizacion: ";
        }
        public Hospitalizacione Consultar(int id)
        {

            return dbSuper.Hospitalizaciones.FirstOrDefault(c => c.id_hospitalizacion == id);
        }
    }
}