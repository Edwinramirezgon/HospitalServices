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

    public partial class DetallesFormula
    {
        public int id_detalle_formula { get; set; }
        public int id_formula { get; set; }
        public int id_medicamento { get; set; }
        public Nullable<int> cantidad { get; set; }
        public string dosis { get; set; }


        [JsonIgnore]
        public virtual Formula Formula { get; set; }

        [JsonIgnore]
        public virtual Medicamento Medicamento { get; set; }
    }
}
