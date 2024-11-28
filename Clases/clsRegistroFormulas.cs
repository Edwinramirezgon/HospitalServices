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
    }
}