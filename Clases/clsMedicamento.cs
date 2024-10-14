using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsMedicamento
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Medicamento medicamento { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Medicamentos.Add(medicamento);
                dbSuper.SaveChanges();
                return "Se grabó el medicamento";
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
                dbSuper.Medicamentos.AddOrUpdate(medicamento);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de el medicamento con id: " + medicamento.id_medicamento;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Medicamento _medicamento = Consultar(medicamento.id_medicamento);
            if (_medicamento == null)
            {
                return "el medicamento no existe en la base de datos";
            }
            dbSuper.Medicamentos.Remove(_medicamento);
            dbSuper.SaveChanges();
            return "Se eliminó el medicamento ";
        }
        public Medicamento Consultar(int id)
        {

            return dbSuper.Medicamentos.FirstOrDefault(c => c.id_medicamento == id);
        }
    }
}