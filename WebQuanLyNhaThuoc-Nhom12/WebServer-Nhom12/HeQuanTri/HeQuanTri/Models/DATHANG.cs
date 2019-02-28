namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DATHANG")]
    public partial class DATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATHANG()
        {
            CTDHs = new HashSet<CTDH>();
        }

        [Key]
        [StringLength(10)]
        public string MADH { get; set; }

        public DateTime? NGAYLAP { get; set; }

        [StringLength(10)]
        public string MANV { get; set; }

        [Required]
        [StringLength(10)]
        public string MAKH { get; set; }

        public decimal? TONGTIEN { get; set; }

        public decimal? TIENTHANHTOAN { get; set; }

        public decimal? TIENTHUA { get; set; }

        public bool? TRANGTHAI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDH> CTDHs { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
