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
    
    public partial class Hospitalizacione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hospitalizacione()
        {
            this.Altas = new HashSet<Alta>();
            this.Urgencias = new HashSet<Urgencia>();
        }
    
        public int id_hospitalizacion { get; set; }
        public int id_evento { get; set; }
        public int habitacion { get; set; }
        public string estado_hospitalizacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]


        public virtual ICollection<Alta> Altas { get; set; }

        [JsonIgnore]
        public virtual EventosMedico EventosMedico { get; set; }

        [JsonIgnore]
        public virtual Habitacione Habitacione { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]


        public virtual ICollection<Urgencia> Urgencias { get; set; }
    }
}
