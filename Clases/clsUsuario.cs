using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsUsuario
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Usuario usuario { get; set; }


        public string Insertar()
        {
            try
            {

                dbSuper.Usuarios.Add(usuario);
                dbSuper.SaveChanges();
                return "Se grabó el usuario " + usuario.usuario1;
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
                dbSuper.Usuarios.AddOrUpdate(usuario);
                dbSuper.SaveChanges();
                return "Se actualizaron los datos de el usuario con id: " + usuario.id_usuario;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {

            Usuario _usuario = Consultar(usuario.id_usuario);
            if (_usuario == null)
            {
                return "el usuario no existe en la base de datos";
            }
            dbSuper.Usuarios.Remove(_usuario);
            dbSuper.SaveChanges();
            return "Se eliminó el usuario: " + _usuario.usuario1;
        }
        public Usuario Consultar(int id)
        {

            return dbSuper.Usuarios.FirstOrDefault(c => c.id_usuario == id);
        }
    }
}