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
    
    public partial class Department_Karyakar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department_Karyakar()
        {
            this.Delivers = new HashSet<Deliver>();
            this.Packages = new HashSet<Package>();
        }
    
        public int Department_Karyakar_ID { get; set; }
        public int Department_ID { get; set; }
        public string Karyakar_Name { get; set; }
        public string Karyakar_Email { get; set; }
        public string Karyakar_Phone_Number { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public Nullable<int> Create_User { get; set; }
        public Nullable<int> Carrier_ID { get; set; }
        public string cc_Email { get; set; }
        public string cc_Cell { get; set; }
        public Nullable<int> cc_Cell_Carrier_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deliver> Delivers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package> Packages { get; set; }
    }
}
