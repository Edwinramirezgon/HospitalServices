using HospitalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalServices.Clases
{
    public class clsRegistroFormulas
    {
        hospital_dbEntities dbSuper = new hospital_dbEntities();

        public Formula formula { get; set; }
        public DetallesFormula detallesFormula { get; set; }

        public string GrabarFormula()
        {
            if (formula.id_formula == 0) {
                return GrabarEncabezado();
            }
            return GrabarDetalle();
        }
        public string GrabarEncabezado() 
        {
            try
            {
                formula.id_formula = GenerarNumeroFormula();
                formula.fecha_formula = DateTime.Now;
                dbSuper.Formulas.Add(formula);
                dbSuper.SaveChanges();
                return formula.id_formula.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public int GenerarNumeroFormula()
        {
            return dbSuper.Formulas.Select(f => f.id_formula).DefaultIfEmpty(0).Max() + 1;
        }
        public string GrabarDetalle()
        {
            try
            {
                detallesFormula = formula.DetallesFormulas.FirstOrDefault();
                dbSuper.DetallesFormulas.Add(detallesFormula);
                dbSuper.SaveChanges();
                return formula.id_formula.ToString();
            }
            catch (Exception ex) 
            { 
                return ex.Message;
            }            
        }
        
        public IQueryable LlenarCombo()
        {
            return dbSuper.Medicamentos
                .OrderBy(t => t.nombre)
                .Select(t => new
                {
                    Codigo = t.id_medicamento,
                    Nombre = t.nombre
                });
        }

         public IQueryable LLenarTabla(string id)
        {

            long longId = Convert.ToInt64(id);
            return from ev in dbSuper.Set<EventosMedico>()
                   join ur in dbSuper.Set<Urgencia>()
                   on ev.id_evento equals ur.id_evento
                   join me in dbSuper.Set<Medico>()
                   on ev.id_medico equals me.id_medico
                   join us in dbSuper.Set<Usuario>()
                   on me.id_usuario equals us.id_usuario
                   join pe in dbSuper.Set<Persona>()
                   on us.id_persona equals pe.id_persona
                   join pa in dbSuper.Set<Paciente>()
                   on ev.id_paciente equals pa.id_paciente
                   join pe2 in dbSuper.Set<Persona>()
                   on pa.id_persona equals pe2.id_persona
                   orderby pe2.nombre + " " + pe2.apellido      
                   where pa.id_persona == longId
                   select new
                   {
                       ID_EVENTO = ev.id_evento,
                       PACIENTE = pe2.nombre + " " + pe2.apellido,
                       ID_PACIENTE = pe2.id_persona,
                       MEDICO = pe.nombre + " " + pe.apellido,
                       FECHA_DE_EVENTO = ev.fecha_evento.ToString().Substring(0, 10),
                       DESCRIPCION_DE_EVENTO = ev.descripcion,
                 

                       ASIGNAR_FORMULA = "<button type=\"button\" id=\"btnEditar\" class=\"btn-block btn-lg btn-success\" onclick=\"abrirModalAsignar('"
        + ev.id_evento + "', '"
        + pa.id_persona + "', '"
        + pe2.nombre + "', '"
        + pe2.apellido + "', '"
        + pe.nombre + "', '"
        + pe.apellido + "', '"      
        + ev.fecha_evento + "', '"    
        + ev.descripcion + "')\">ASIGNAR FORMULA</button>"

                   };


        }
    }
}