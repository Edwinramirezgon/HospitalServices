using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsHabitacione
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Habitacione habitacion { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Habitaciones.Add(habitacion);
                dbSuper.SaveChanges();
                return "Se grabó la habitacion";
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
                Habitacione _habitacion = Consultar(habitacion.id_habitacion);
                if (_habitacion != null)
                {
                    dbSuper.Habitaciones.AddOrUpdate(habitacion);
                    dbSuper.SaveChanges();
                    return "Se actualizaron los datos de la habitacion con id: " + habitacion.id_habitacion;
                }
                else
                {
                    return "La habitacion que se quiere actualizar, no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Habitacione _habitacion = Consultar(habitacion.id_habitacion);
            if (_habitacion == null)
            {
                return "la habitacion no existe en la base de datos";
            }
            dbSuper.Habitaciones.Remove(_habitacion);
            dbSuper.SaveChanges();
            return "Se eliminó la habitacion: ";
        }
        public Habitacione Consultar(int id)
        {

            return dbSuper.Habitaciones.FirstOrDefault(c => c.id_habitacion == id);
        }

        public IQueryable LLenarTabla()
        {

            return from ha in dbSuper.Set<Habitacione>()
                   join th in dbSuper.Set<TipoHabitacione>()
                   on ha.id_tipo_habitacion equals th.id_tipo_habitacion              
                   orderby th.nombre
                   select new
                   {
                       ID = ha.id_habitacion,
                       NUMERO_HABITACION = ha.numero_habitacion,
                       ESTADO = ha.estado_habitacion,
                       DESCRIPCION = ha.descripcion,
                       TIPO_DE_HABITACION = th.nombre

                   };


        }

        public IQueryable LlenarCombo()
        {
            return dbSuper.TipoHabitaciones
                .OrderBy(t => t.nombre)
                .Select(t => new
                {
                    Codigo = t.id_tipo_habitacion,
                    Nombre = t.nombre
                });
        }
    }
}