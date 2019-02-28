namespace HeQuanTri.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<BAOCAOHANGTON> BAOCAOHANGTONs { get; set; }
        public virtual DbSet<CTBAOCAOHANGTON> CTBAOCAOHANGTONs { get; set; }
        public virtual DbSet<CTDH> CTDHs { get; set; }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<CTNHAPHANGHOA> CTNHAPHANGHOAs { get; set; }
        public virtual DbSet<DATHANG> DATHANGs { get; set; }
        public virtual DbSet<DONVITINH> DONVITINHs { get; set; }
        public virtual DbSet<HANGHOA> HANGHOAs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<LAPPHIEUTHUTIEN> LAPPHIEUTHUTIENs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHAPHANGHOA> NHAPHANGHOAs { get; set; }
        public virtual DbSet<NHOMHANG> NHOMHANGs { get; set; }
        public virtual DbSet<QUYDINH> QUYDINHs { get; set; }
        public virtual DbSet<QUYEN> QUYENs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TUCHUA> TUCHUAs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BAOCAOHANGTON>()
                .Property(e => e.MABAOCAO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAOCAOHANGTON>()
                .HasMany(e => e.CTBAOCAOHANGTONs)
                .WithRequired(e => e.BAOCAOHANGTON)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CTBAOCAOHANGTON>()
                .Property(e => e.MABAOCAO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTBAOCAOHANGTON>()
                .Property(e => e.MAHANGHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTDH>()
                .Property(e => e.MADH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTDH>()
                .Property(e => e.MAHANGHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTDH>()
                .Property(e => e.DONGIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTDH>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MAHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MAHANGHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.DONGIA)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTNHAPHANGHOA>()
                .Property(e => e.MANHAPHANGHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTNHAPHANGHOA>()
                .Property(e => e.MAHANGHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTNHAPHANGHOA>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.MADH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.MANV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.MAKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(8, 0);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.TIENTHANHTOAN)
                .HasPrecision(8, 0);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.TIENTHUA)
                .HasPrecision(8, 0);

            modelBuilder.Entity<DATHANG>()
                .HasMany(e => e.CTDHs)
                .WithRequired(e => e.DATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONVITINH>()
                .Property(e => e.MADONVITINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DONVITINH>()
                .Property(e => e.TENDONVITINH)
                .IsUnicode(false);

            modelBuilder.Entity<DONVITINH>()
                .HasMany(e => e.HANGHOAs)
                .WithRequired(e => e.DONVITINH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.MAHANGHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.DONGIANHAP)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.DONGIABAN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.MANHOMHANG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.MANHACUNGCAP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.MADONVITINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.MATUCHUA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGHOA>()
                .HasMany(e => e.CTBAOCAOHANGTONs)
                .WithRequired(e => e.HANGHOA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HANGHOA>()
                .HasMany(e => e.CTDHs)
                .WithRequired(e => e.HANGHOA)
                .WillCascadeOnDelete(false);

   


            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MANV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MAKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TONGTIEN)
                .HasPrecision(8, 0);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TIENTHANHTOAN)
                .HasPrecision(8, 0);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.TIENTHUA)
                .HasPrecision(8, 0);


            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MAKH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SODIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SOTIENNO)
                .HasPrecision(9, 0);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.DATHANGs)
                .WithRequired(e => e.KHACHHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LAPPHIEUTHUTIEN>()
                .Property(e => e.MAPHIEUTHU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LAPPHIEUTHUTIEN>()
                .Property(e => e.MAHD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LAPPHIEUTHUTIEN>()
                .Property(e => e.MANV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LAPPHIEUTHUTIEN>()
                .Property(e => e.SOTIENTHU)
                .HasPrecision(9, 0);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MANHACUNGCAP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SODIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.HANGHOAs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MANV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.SODIENTHOAI)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MAQUYEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<NHAPHANGHOA>()
                .Property(e => e.MANHAPHANGHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHAPHANGHOA>()
                .Property(e => e.MANV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHAPHANGHOA>()
                .Property(e => e.TONGSOTIEN)
                .HasPrecision(18, 0);

          
            modelBuilder.Entity<NHOMHANG>()
                .Property(e => e.MANHOMHANG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHOMHANG>()
                .Property(e => e.TENNHOMHANG)
                .IsUnicode(false);

            modelBuilder.Entity<NHOMHANG>()
                .HasMany(e => e.HANGHOAs)
                .WithRequired(e => e.NHOMHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUYDINH>()
                .Property(e => e.MAQUYDINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QUYEN>()
                .Property(e => e.MAQUYEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QUYEN>()
                .HasMany(e => e.NHANVIENs)
                .WithRequired(e => e.QUYEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TUCHUA>()
                .Property(e => e.MATUCHUA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TUCHUA>()
                .HasMany(e => e.HANGHOAs)
                .WithRequired(e => e.TUCHUA)
                .WillCascadeOnDelete(false);
        }
    }
}
