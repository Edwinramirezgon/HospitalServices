using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace HospitalServices.Clases
{
    public class clsRegistroMedicos
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();
        public Persona persona { get; set; }


        public string Insertar(int id_persona, string usuario1, string rol, string especialidad, string horario, string contacto, string password)
        {
            try
            {
                clsCypher cifrar = new clsCypher();
                cifrar.Password = password;
                if (cifrar.CifrarClave())
                {
                    dbSuper.Personas.Add(persona);
                    dbSuper.SaveChanges();
                    Usuario user = new Usuario();
                    user.Salt = cifrar.Salt;
                    user.Password = cifrar.PasswordCifrado;
                    user.id_persona = id_persona;
                    user.usuario1 = usuario1;
                    user.rol = rol;
                    dbSuper.Usuarios.Add(user);
                    dbSuper.SaveChanges();
                    Medico medico = new Medico();
                    medico.id_usuario = user.id_usuario;
                    medico.especialidad = especialidad;
                    medico.horario = horario;
                    medico.telefono_contacto = contacto;

                    dbSuper.Medicos.Add(medico);
                    dbSuper.SaveChanges();
                    return "Se grabó el medico " + persona.nombre + " " + persona.apellido + " Con id " + id_persona;
                }
                else
                {
                    return "No  se pudo cifrar la clave.";
                }
            }
            catch (DbEntityValidationException e)
            {
                // Captura los errores de validación y construye un mensaje detallado
                var errorMessages = e.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.PropertyName + ": " + x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(e.Message, " Los errores de validación son: ", fullErrorMessage);

                return exceptionMessage; // Retorna los detalles de validación fallidos
            }
            catch (Exception ex)
            {
                return "Error general al actualizar los datos: " + ex.Message;
            }
        }
        public string Actualizar(int id_persona, string usuario1, string rol, string especialidad, string horario, string contacto, string password)
        {

            try
            {
                Persona _persona = Consultar(persona.id_persona);
                Usuario _usuario = Consultar2(persona.id_persona);
                Medico _medico = Consultar3(_usuario.id_usuario);
                if (_persona != null && _usuario != null && _medico != null)
                {

                    clsCypher cifrar = new clsCypher();
                    cifrar.Password = password;
                    if (cifrar.CifrarClave())
                    {
                        dbSuper.Personas.AddOrUpdate(persona);
                        dbSuper.SaveChanges();
                        Usuario user = new Usuario();
                        user.id_usuario = _usuario.id_usuario;
                        user.id_persona = id_persona;
                        user.Salt = cifrar.Salt;
                        user.Password = cifrar.PasswordCifrado;
                        user.usuario1 = usuario1;
                        user.rol = rol;
                        dbSuper.Usuarios.AddOrUpdate(user);
                        dbSuper.SaveChanges();
                        Medico medico = new Medico();
                        medico.id_medico = _medico.id_medico;
                        medico.id_usuario = _medico.id_usuario;
                        medico.especialidad = especialidad;
                        medico.horario = horario;
                        medico.telefono_contacto = contacto;
                        dbSuper.Medicos.AddOrUpdate(medico);
                        dbSuper.SaveChanges();
                        return "Se actualizaron los datos de el medico " + persona.nombre + " " + persona.apellido + " Con id " + persona.id_persona;
                    }
                    else
                    {
                        return "No  se pudo cifrar la clave.";
                    }
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
            Medico _medico = Consultar3(_usuario.id_usuario);
            if (_persona == null && _usuario == null && _medico == null)
            {
                return "El medico no existe en la base de datos";
            }
            dbSuper.Medicos.Remove(_medico);
            dbSuper.SaveChanges();
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
        public Medico Consultar3(int id)
        {

            return dbSuper.Medicos.FirstOrDefault(c => c.id_usuario == id);
        }

        public IQueryable LLenarTabla()
        {

            return from us in dbSuper.Set<Usuario>()
                   join pe in dbSuper.Set<Persona>()
                   on us.id_persona equals pe.id_persona
                   join me in dbSuper.Set<Medico>()
                   on us.id_usuario equals me.id_usuario
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
                       TIPO_DE_USUARIO = us.usuario1,
                       ROL = us.rol,
                       ESPECIALIDAD = me.especialidad,
                       HORARIO = me.horario,
                       CONTACTO_DE_EMERGENCIA = me.telefono_contacto,

                       EDITAR = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-lg btn-warning\" onclick=\"abrirModalEditar('"
        + pe.id_persona + "', '"
        + pai.id_pais + "', '"
        + pe.nombre + "', '"
        + pe.apellido + "', '"
        + pe.fecha_nacimiento + "', '"
        + pe.direccion + "', '"
        + pe.telefono + "', '"
        + pe.email + "', '"
        + pe.genero + "', '"
        + us.usuario1 + "', '"
        + us.rol + "', '"
        + me.especialidad + "', '"
        + me.horario + "', '"
        + me.telefono_contacto + "')\">EDITAR</button>",

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