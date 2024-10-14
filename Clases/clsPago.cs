using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsPago
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Pago pago { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Pagos.Add(pago);
                dbSuper.SaveChanges();
                return "Se grabó el pago";
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
                dbSuper.Pagos.AddOrUpdate(pago);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de el pago con id: " + pago.id_pago;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Pago _pago = Consultar(pago.id_pago);
            if (_pago == null)
            {
                return "el pago no existe en la base de datos";
            }
            dbSuper.Pagos.Remove(_pago);
            dbSuper.SaveChanges();
            return "Se eliminó el pago ";
        }
        public Pago Consultar(int id)
        {

            return dbSuper.Pagos.FirstOrDefault(c => c.id_pago == id);
        }
    }
}