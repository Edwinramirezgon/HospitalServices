using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsRegistroPaciente
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
                return "Se grabó el paciente " + persona.nombre + " " + persona.apellido + " Con id " + idpersona;
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
                Paciente _paciente = Consultar2(persona.id_persona);
                if (_persona != null && _paciente != null)
                {
                    dbSuper.Personas.AddOrUpdate(persona);
                    dbSuper.SaveChanges();
                    Paciente paciente = new Paciente();
                    paciente.id_paciente = _paciente.id_paciente;
                    paciente.id_persona = idpersona;
                    paciente.contacto_emergencia = contacto;
                    paciente.alergias = alergias;
                    paciente.antecedentes_medicos = antecedentes;
                    dbSuper.Pacientes.AddOrUpdate(paciente);
                    dbSuper.SaveChanges();
                    return "Se actualizaron los datos de el paciente " + persona.nombre + " " + persona.apellido + " Con id " + persona.id_persona;
                }
                else
                {
                    return "El paciente que se quiere actualizar, no existe en la base de datos";
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
            Paciente _paciente = Consultar2(persona.id_persona); 
            if (_persona == null && _paciente == null)
            {
                return "El paciente no existe en la base de datos";
            }
            dbSuper.Pacientes.Remove(_paciente);
            dbSuper.SaveChanges();
            dbSuper.Personas.Remove(_persona);
            dbSuper.SaveChanges();
            return "Se eliminó el paciente: " + _persona.nombre + " " + _persona.apellido;
        }
        public Persona Consultar(long id)
        {

            return dbSuper.Personas.FirstOrDefault(c => c.id_persona == id);
        }

        public Paciente Consultar2(long id)
        {

            return dbSuper.Pacientes.FirstOrDefault(c => c.id_persona == id);
        }

        public IQueryable LLenarTabla()
        {

            return from pa in dbSuper.Set<Paciente>()
                   join pe in dbSuper.Set<Persona>()
                   on pa.id_persona equals pe.id_persona
                   join pai in dbSuper.Set<Pais>()
                   on pe.id_pais equals pai.id_pais
                   orderby pe.nombre
                   select new
                   
                   {
                       ID = pe.id_persona,
                       PAIS = pai.nombre,
                       NOMBRES = pe.nombre,
                       APELLIDOS = pe.apellido,
                       FECHA_DE_NACIMIENTO = pe.fecha_nacimiento.ToString().Substring(0, 10),
                       DIRECCION = pe.direccion,
                       TELEFONO = pe.telefono,
                       EMAIL = pe.email,
                       GENERO = pe.genero,
                       CONTACTO_DE_EMERGENCIA = pa.contacto_emergencia,
                       ALERGIAS = pa.alergias,
                       ANTECEDENTES = pa.antecedentes_medicos,

                       EDITAR = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-lg btn-warning\" onclick=\"Editar('"
        + pe.id_persona + "', '"
        + pai.id_pais + "', '"
        + pe.nombre + "', '"
        + pe.apellido + "', '"
        + pe.fecha_nacimiento + "', '"
        + pe.direccion + "', '"
        + pe.telefono + "', '"
        + pe.email + "', '"
        + pe.genero + "', '"
        + pa.contacto_emergencia + "', '"
        + pa.alergias.Substring(0,50) + "', '"
        + pa.antecedentes_medicos.Substring(0,50) + "')\">EDITAR</button>",

                     

                       ELIMINAR = "<button type=\"button\" id=\"btnEliminar\" class=\"btn-block btn-lg btn-danger\" onclick=\"Eliminar('"
        + pe.id_persona + "')\">ELIMINAR</button>"

                   };


        }

        public IQueryable LlenarCombo()
        {
            return dbSuper.Paises
                .OrderBy(t => t.nombre)
                .Select(t => new
                {
                    Codigo = t.id_pais,
                    Nombre = t.nombre
                });
        }
    }
}