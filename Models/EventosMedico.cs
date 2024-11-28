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
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class EventosMedico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EventosMedico()
        {
            this.Citas = new HashSet<Cita>();
            this.Facturaciones = new HashSet<Facturacione>();
            this.Formulas = new HashSet<Formula>();
            this.Hospitalizaciones = new HashSet<Hospitalizacione>();
            this.Urgencias = new HashSet<Urgencia>();
        }
    
        public int id_evento { get; set; }
        public int id_paciente { get; set; }
        public int id_medico { get; set; }
        public Nullable<System.DateTime> fecha_evento { get; set; }
        public string descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cita> Citas { get; set; }


        [JsonIgnore]
        public virtual Medico Medico { get; set; }


        [JsonIgnore]
        public virtual Paciente Paciente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Facturacione> Facturaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Formula> Formulas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hospitalizacione> Hospitalizaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urgencia> Urgencias { get; set; }
    }
}
