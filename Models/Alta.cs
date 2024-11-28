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

    public partial class Alta
    {
        public int id_alta { get; set; }
        public int id_hospitalizacion { get; set; }
        public int id_medico { get; set; }
        public Nullable<System.DateTime> fecha_alta { get; set; }
        public string descripcion_alta { get; set; }
        public string recomendaciones { get; set; }


        [JsonIgnore]
        public virtual Hospitalizacione Hospitalizacione { get; set; }

        [JsonIgnore]
        public virtual Medico Medico { get; set; }
    }
}
