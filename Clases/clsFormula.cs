using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsFormula
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Formula formula { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Formulas.Add(formula);
                dbSuper.SaveChanges();
                return "Se grabó la formula ";
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
                dbSuper.Formulas.AddOrUpdate(formula);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de la formula con id: " + formula.id_formula;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Formula _formula = Consultar(formula.id_formula);
            if (_formula == null)
            {
                return "la formula no existe en la base de datos";
            }
            dbSuper.Formulas.Remove(_formula);
            dbSuper.SaveChanges();
            return "Se eliminó la formula: ";
        }
        public Formula Consultar(int id)
        {

            return dbSuper.Formulas.FirstOrDefault(c => c.id_formula == id);
        }
    }
}