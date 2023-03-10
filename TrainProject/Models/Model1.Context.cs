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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class qltrainEntities : DbContext
    {
        public qltrainEntities()
            : base("name=qltrainEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Chuyen> Chuyens { get; set; }
        public virtual DbSet<HanhKhach> HanhKhaches { get; set; }
        public virtual DbSet<LoaiVe> LoaiVes { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<Tau> Taus { get; set; }
        public virtual DbSet<ThanhToan> ThanhToans { get; set; }
        public virtual DbSet<Toa> Toas { get; set; }
        public virtual DbSet<Ve> Ves { get; set; }
    
        public virtual int sp_BookingTicket(Nullable<int> soGheDat, Nullable<int> mave, Nullable<int> mataikhoan, string motathanhtoan)
        {
            var soGheDatParameter = soGheDat.HasValue ?
                new ObjectParameter("SoGheDat", soGheDat) :
                new ObjectParameter("SoGheDat", typeof(int));
    
            var maveParameter = mave.HasValue ?
                new ObjectParameter("mave", mave) :
                new ObjectParameter("mave", typeof(int));
    
            var mataikhoanParameter = mataikhoan.HasValue ?
                new ObjectParameter("mataikhoan", mataikhoan) :
                new ObjectParameter("mataikhoan", typeof(int));
    
            var motathanhtoanParameter = motathanhtoan != null ?
                new ObjectParameter("motathanhtoan", motathanhtoan) :
                new ObjectParameter("motathanhtoan", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_BookingTicket", soGheDatParameter, maveParameter, mataikhoanParameter, motathanhtoanParameter);
        }
    
        public virtual ObjectResult<sp_Login_Result> sp_Login(string uname, string pass)
        {
            var unameParameter = uname != null ?
                new ObjectParameter("uname", uname) :
                new ObjectParameter("uname", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Login_Result>("sp_Login", unameParameter, passParameter);
        }
    
        public virtual int sp_register(string uname, string emailtaikhoan, string sodienthoai, string pass, string xacnhanpass)
        {
            var unameParameter = uname != null ?
                new ObjectParameter("uname", uname) :
                new ObjectParameter("uname", typeof(string));
    
            var emailtaikhoanParameter = emailtaikhoan != null ?
                new ObjectParameter("emailtaikhoan", emailtaikhoan) :
                new ObjectParameter("emailtaikhoan", typeof(string));
    
            var sodienthoaiParameter = sodienthoai != null ?
                new ObjectParameter("sodienthoai", sodienthoai) :
                new ObjectParameter("sodienthoai", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var xacnhanpassParameter = xacnhanpass != null ?
                new ObjectParameter("xacnhanpass", xacnhanpass) :
                new ObjectParameter("xacnhanpass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_register", unameParameter, emailtaikhoanParameter, sodienthoaiParameter, passParameter, xacnhanpassParameter);
        }
    
        public virtual ObjectResult<sp_TimKiemVe_Result> sp_TimKiemVe(string gadi, string gaden, Nullable<System.DateTime> thoigiandi)
        {
            var gadiParameter = gadi != null ?
                new ObjectParameter("gadi", gadi) :
                new ObjectParameter("gadi", typeof(string));
    
            var gadenParameter = gaden != null ?
                new ObjectParameter("gaden", gaden) :
                new ObjectParameter("gaden", typeof(string));
    
            var thoigiandiParameter = thoigiandi.HasValue ?
                new ObjectParameter("thoigiandi", thoigiandi) :
                new ObjectParameter("thoigiandi", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_TimKiemVe_Result>("sp_TimKiemVe", gadiParameter, gadenParameter, thoigiandiParameter);
        }
    
        public virtual int sp_ThemChuyen(Nullable<int> matau, string tenchuyen, string gadi, string gaden, Nullable<System.DateTime> thoigiandi)
        {
            var matauParameter = matau.HasValue ?
                new ObjectParameter("matau", matau) :
                new ObjectParameter("matau", typeof(int));
    
            var tenchuyenParameter = tenchuyen != null ?
                new ObjectParameter("tenchuyen", tenchuyen) :
                new ObjectParameter("tenchuyen", typeof(string));
    
            var gadiParameter = gadi != null ?
                new ObjectParameter("gadi", gadi) :
                new ObjectParameter("gadi", typeof(string));
    
            var gadenParameter = gaden != null ?
                new ObjectParameter("gaden", gaden) :
                new ObjectParameter("gaden", typeof(string));
    
            var thoigiandiParameter = thoigiandi.HasValue ?
                new ObjectParameter("thoigiandi", thoigiandi) :
                new ObjectParameter("thoigiandi", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemChuyen", matauParameter, tenchuyenParameter, gadiParameter, gadenParameter, thoigiandiParameter);
        }
    
        public virtual int sp_ThemHanhKhach(Nullable<int> mataikhoan, string tenhk, string diachihk)
        {
            var mataikhoanParameter = mataikhoan.HasValue ?
                new ObjectParameter("mataikhoan", mataikhoan) :
                new ObjectParameter("mataikhoan", typeof(int));
    
            var tenhkParameter = tenhk != null ?
                new ObjectParameter("tenhk", tenhk) :
                new ObjectParameter("tenhk", typeof(string));
    
            var diachihkParameter = diachihk != null ?
                new ObjectParameter("diachihk", diachihk) :
                new ObjectParameter("diachihk", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemHanhKhach", mataikhoanParameter, tenhkParameter, diachihkParameter);
        }
    
        public virtual int sp_ThemLoaiVe(string motaloaive)
        {
            var motaloaiveParameter = motaloaive != null ?
                new ObjectParameter("motaloaive", motaloaive) :
                new ObjectParameter("motaloaive", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemLoaiVe", motaloaiveParameter);
        }
    
        public virtual int sp_ThemQuyen(string motaquyen)
        {
            var motaquyenParameter = motaquyen != null ?
                new ObjectParameter("motaquyen", motaquyen) :
                new ObjectParameter("motaquyen", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemQuyen", motaquyenParameter);
        }
    
        public virtual int sp_ThemTau(string tentau, Nullable<int> sotoa)
        {
            var tentauParameter = tentau != null ?
                new ObjectParameter("tentau", tentau) :
                new ObjectParameter("tentau", typeof(string));
    
            var sotoaParameter = sotoa.HasValue ?
                new ObjectParameter("sotoa", sotoa) :
                new ObjectParameter("sotoa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemTau", tentauParameter, sotoaParameter);
        }
    
        public virtual int sp_ThemToa(Nullable<int> matau, Nullable<int> soghe, string loaighe)
        {
            var matauParameter = matau.HasValue ?
                new ObjectParameter("matau", matau) :
                new ObjectParameter("matau", typeof(int));
    
            var sogheParameter = soghe.HasValue ?
                new ObjectParameter("soghe", soghe) :
                new ObjectParameter("soghe", typeof(int));
    
            var loaigheParameter = loaighe != null ?
                new ObjectParameter("loaighe", loaighe) :
                new ObjectParameter("loaighe", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemToa", matauParameter, sogheParameter, loaigheParameter);
        }
    
        public virtual int sp_ThemVe(Nullable<int> machuyen, Nullable<int> maloaive, Nullable<decimal> giave)
        {
            var machuyenParameter = machuyen.HasValue ?
                new ObjectParameter("machuyen", machuyen) :
                new ObjectParameter("machuyen", typeof(int));
    
            var maloaiveParameter = maloaive.HasValue ?
                new ObjectParameter("maloaive", maloaive) :
                new ObjectParameter("maloaive", typeof(int));
    
            var giaveParameter = giave.HasValue ?
                new ObjectParameter("giave", giave) :
                new ObjectParameter("giave", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_ThemVe", machuyenParameter, maloaiveParameter, giaveParameter);
        }
    
        public virtual ObjectResult<sp_ThongtinChuyen_Result> sp_ThongtinChuyen(Nullable<int> machuyen)
        {
            var machuyenParameter = machuyen.HasValue ?
                new ObjectParameter("machuyen", machuyen) :
                new ObjectParameter("machuyen", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_ThongtinChuyen_Result>("sp_ThongtinChuyen", machuyenParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_ThongtinTau(Nullable<int> matau)
        {
            var matauParameter = matau.HasValue ?
                new ObjectParameter("matau", matau) :
                new ObjectParameter("matau", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_ThongtinTau", matauParameter);
        }
    
        public virtual int sp_XoaChuyen(Nullable<int> machuyen)
        {
            var machuyenParameter = machuyen.HasValue ?
                new ObjectParameter("machuyen", machuyen) :
                new ObjectParameter("machuyen", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_XoaChuyen", machuyenParameter);
        }
    
        public virtual int sp_XoaLoaiVe(Nullable<int> maloaive)
        {
            var maloaiveParameter = maloaive.HasValue ?
                new ObjectParameter("maloaive", maloaive) :
                new ObjectParameter("maloaive", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_XoaLoaiVe", maloaiveParameter);
        }
    
        public virtual int sp_XoaQuyen(Nullable<int> maquyen)
        {
            var maquyenParameter = maquyen.HasValue ?
                new ObjectParameter("maquyen", maquyen) :
                new ObjectParameter("maquyen", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_XoaQuyen", maquyenParameter);
        }
    
        public virtual int sp_XoaTau(Nullable<int> matau)
        {
            var matauParameter = matau.HasValue ?
                new ObjectParameter("matau", matau) :
                new ObjectParameter("matau", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_XoaTau", matauParameter);
        }
    
        public virtual int sp_XoaToa(Nullable<int> matoa)
        {
            var matoaParameter = matoa.HasValue ?
                new ObjectParameter("matoa", matoa) :
                new ObjectParameter("matoa", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_XoaToa", matoaParameter);
        }
    }
}
