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
    
    public partial class ThanhToan
    {
        public int MaThanhToan { get; set; }
        public int MaVe { get; set; }
        public int MaTK { get; set; }
        public System.DateTime ThoiGianThanhToan { get; set; }
        public string MoTaThanhToan { get; set; }
        public Nullable<decimal> TongTien { get; set; }
    
        public virtual TaiKhoan TaiKhoan { get; set; }
        public virtual Ve Ve { get; set; }
    }
}
