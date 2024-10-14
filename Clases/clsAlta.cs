using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsAlta
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Alta alta { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Altas.Add(alta);
                dbSuper.SaveChanges();
                return "Se grabó el alta";
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
                dbSuper.Altas.AddOrUpdate(alta);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de el alta con id: " + alta.id_alta;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Alta _alta = Consultar(alta.id_alta);
            if (_alta == null)
            {
                return "el alta no existe en la base de datos";
            }
            dbSuper.Altas.Remove(_alta);
            dbSuper.SaveChanges();
            return "Se eliminó el alta ";
        }
        public Alta Consultar(int id)
        {

            return dbSuper.Altas.FirstOrDefault(c => c.id_alta == id);
        }
    }
}