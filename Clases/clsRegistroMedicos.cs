using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsRegistroMedicos
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();
        public Persona persona { get; set; }


        public string Insertar(int idpersona, string contacto, string alergias, string antecedentes)
        {
            try
            {

                dbSuper.Personas.Add(persona);
                dbSuper.SaveChanges();
                Paciente paciente = new Paciente();
                paciente.id_persona = idpersona;
                paciente.contacto_emergencia = contacto;
                paciente.alergias = alergias;
                paciente.antecedentes_medicos = antecedentes;
                dbSuper.Pacientes.Add(paciente);
                dbSuper.SaveChanges();
                return "Se grabó el medico " + persona.nombre + " " + persona.apellido + " Con id " + idpersona;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar(int idpersona, string contacto, string alergias, string antecedentes)
        {

            try
            {
                Persona _persona = Consultar(persona.id_persona);
                Usuario _usuario = Consultar2(persona.id_persona);
                if (_persona != null && _usuario != null)
                {
                    dbSuper.Personas.AddOrUpdate(persona);
                    dbSuper.SaveChanges();
                    Usuario usuario = new Usuario();
                    usuario.id_persona = _usuario.id_persona;
                   /* paciente.id_persona = idpersona;
                    paciente.contacto_emergencia = contacto;
                    paciente.alergias = alergias;
                    paciente.antecedentes_medicos = antecedentes;
                    dbSuper.Pacientes.AddOrUpdate(paciente);
                    dbSuper.SaveChanges();*/
                    return "Se actualizaron los datos de el medico " + persona.nombre + " " + persona.apellido + " Con id " + persona.id_persona;
                }
                else
                {
                    return "El medico que se quiere actualizar, no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            Persona _persona = Consultar(persona.id_persona);
            Usuario _usuario = Consultar2(persona.id_persona);
            if (_persona == null || _usuario == null)
            {
                return "El medico no existe en la base de datos";
            }
            dbSuper.Usuarios.Remove(_usuario);
            dbSuper.SaveChanges();
            dbSuper.Personas.Remove(_persona);
            dbSuper.SaveChanges();
            return "Se eliminó el medico: " + _persona.nombre + " " + _persona.apellido;
        }
        public Persona Consultar(long id)
        {

            return dbSuper.Personas.FirstOrDefault(c => c.id_persona == id);
        }

        public Usuario Consultar2(long id)
        {

            return dbSuper.Usuarios.FirstOrDefault(c => c.id_persona == id);
        }

        public IQueryable LLenarTabla()
        {

            return from us in dbSuper.Set<Usuario>()
                   join pe in dbSuper.Set<Persona>()
                   on us.id_persona equals pe.id_persona
                   join me in dbSuper.Set<Medico>()
                   on us.id_usuario equals me.id_usuario
                   orderby pe.nombre
                   select new
                   {
                       ID = pe.id_persona,
                       NOMBRES = pe.nombre,
                       APELLIDOS = pe.apellido,
                       FECHA_DE_NACIMIENTO = pe.fecha_nacimiento,
                       DIRECCION = pe.direccion,
                       TELEFONO = pe.telefono,
                       EMAIL = pe.email,
                       GENERO = pe.genero,
                       TIPO_DE_USUARIO = us.usuario1,
                       ROL = us.rol,
                       ESPECIALIDAD = me.especialidad,
                       HORARIO = me.horario,
                      CONTACTO_DE_EMERGENCIA = me.telefono_contacto

                   };


        }
    }
}