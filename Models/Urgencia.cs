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
    
    public partial class Urgencia
    {
        public int id_urgencia { get; set; }
        public int id_evento { get; set; }
        public string estado_urgencia { get; set; }
        public Nullable<int> id_hospitalizacion { get; set; }


        [JsonIgnore]
        public virtual EventosMedico EventosMedico { get; set; }

        [JsonIgnore]
        public virtual Hospitalizacione Hospitalizacione { get; set; }
    }
}
