using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsFacturacion
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Facturacione facturacion { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Facturaciones.Add(facturacion);
                dbSuper.SaveChanges();
                return "Se grabó la factura ";
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
                dbSuper.Facturaciones.AddOrUpdate(facturacion);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de la factura con id: " + facturacion.id_factura;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Facturacione _facturacion = Consultar(facturacion.id_factura);
            if (_facturacion == null)
            {
                return "la factura no existe en la base de datos";
            }
            dbSuper.Facturaciones.Remove(_facturacion);
            dbSuper.SaveChanges();
            return "Se eliminó la factura";
        }
        public Facturacione Consultar(int id)
        {

            return dbSuper.Facturaciones.FirstOrDefault(c => c.id_factura == id);
        }
    }
}