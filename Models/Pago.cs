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
    
    public partial class Pago
    {
        public int id_pago { get; set; }
        public string metodo_pago { get; set; }
        public double monto_pagado { get; set; }
        public Nullable<System.DateTime> fecha_pago { get; set; }
    
        public virtual Facturacione Facturacione { get; set; }
    }
}
