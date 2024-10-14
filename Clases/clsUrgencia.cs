using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsUrgencia
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Urgencia urgencia { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Urgencias.Add(urgencia);
                dbSuper.SaveChanges();
                return "Se grabó la urgencia";
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
                dbSuper.Urgencias.AddOrUpdate(urgencia);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de la urgencia con id: " + urgencia.id_urgencia;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Urgencia _urgencia = Consultar(urgencia.id_urgencia);
            if (_urgencia == null)
            {
                return "la urgencia no existe en la base de datos";
            }
            dbSuper.Urgencias.Remove(_urgencia);
            dbSuper.SaveChanges();
            return "Se eliminó la urgencia: ";
        }
        public Urgencia Consultar(int id)
        {

            return dbSuper.Urgencias.FirstOrDefault(c => c.id_urgencia == id);
        }
    }
}