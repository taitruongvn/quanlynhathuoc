namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            DATHANGs = new HashSet<DATHANG>();
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(10)]
        public string MANV { get; set; }

        [Required]
        [StringLength(50)]
        public string TENNV { get; set; }

        public bool GIOITINH { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYSINH { get; set; }

        [Required]
        [StringLength(11)]
        public string SODIENTHOAI { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string DIACHI { get; set; }

        [Required]
        [StringLength(10)]
        public string MAQUYEN { get; set; }

        [Required]
        [StringLength(30)]
        public string ID { get; set; }

        [MaxLength(256)]
        public byte[] PASS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATHANG> DATHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }

        public virtual QUYEN QUYEN { get; set; }
    }
}
