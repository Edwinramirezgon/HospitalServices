using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsDetallesFormula
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public DetallesFormula detalle { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.DetallesFormulas.Add(detalle);
                dbSuper.SaveChanges();
                return null;
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
                DetallesFormula _detalle = Consultar(detalle.id_detalle_formula);
                if (_detalle != null)
                {
                    dbSuper.DetallesFormulas.AddOrUpdate(detalle);
                dbSuper.SaveChanges();
                return "Se actualizaron los detalles de la formula con id: " + detalle.id_detalle_formula;
                }
                else
                {
                    return "El Detalle de la formula que se quiere actualizar, no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            DetallesFormula _detalle = Consultar(detalle.id_detalle_formula);
            if (_detalle == null)
            {
                return "el detalle de la formula no existe en la base de datos";
            }
            dbSuper.DetallesFormulas.Remove(_detalle);
            dbSuper.SaveChanges();
            return "Se eliminó el detalle de la formula";
        }
        public DetallesFormula Consultar(int id)
        {

            return dbSuper.DetallesFormulas.FirstOrDefault(c => c.id_detalle_formula == id);
        }
    }
}