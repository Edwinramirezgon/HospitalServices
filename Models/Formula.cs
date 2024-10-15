//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalServices.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class Formula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Formula()
        {
            this.DetallesFormulas = new HashSet<DetallesFormula>();
        }
    
        public int id_formula { get; set; }
        public int id_paciente { get; set; }
        public int id_medico { get; set; }
        public int id_evento { get; set; }
        public Nullable<System.DateTime> fecha_formula { get; set; }
        public string instrucciones { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

 
        public virtual ICollection<DetallesFormula> DetallesFormulas { get; set; }

        [JsonIgnore]
        public virtual EventosMedico EventosMedico { get; set; }

        [JsonIgnore]
        public virtual Medico Medico { get; set; }

        [JsonIgnore]
        public virtual Paciente Paciente { get; set; }
    }
}
