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
    
    public partial class Habitacione
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Habitacione()
        {
            this.Hospitalizaciones = new HashSet<Hospitalizacione>();
        }
    
        public int id_habitacion { get; set; }
        public int numero_habitacion { get; set; }
        public string tipo_habitacion { get; set; }
        public string estado_habitacion { get; set; }
        public string descripcion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hospitalizacione> Hospitalizaciones { get; set; }
    }
}
