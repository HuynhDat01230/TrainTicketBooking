//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chuyen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chuyen()
        {
            this.Ves = new HashSet<Ve>();
        }
    
        public int MaChuyen { get; set; }
        public int MaTau { get; set; }
        public int SoGhe { get; set; }
        public string TenChuyen { get; set; }
        public string NoiDi { get; set; }
        public string NoiDen { get; set; }
        public System.DateTime TGKhoiHanh { get; set; }
    
        public virtual Tau Tau { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ve> Ves { get; set; }
    }
}
