//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PackageTrackerAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deliver
    {
        public int Karyakar_ID { get; set; }
        public int Package_ID { get; set; }
        public string Karyakar_Name { get; set; }
        public string Karyakar_Signature { get; set; }
        public Nullable<System.DateTime> Delivery_Date { get; set; }
        public string Comments { get; set; }
        public string Recipient_Signature { get; set; }
    
        public virtual Department_Karyakar Department_Karyakar { get; set; }
        public virtual Package Package { get; set; }
    }
}