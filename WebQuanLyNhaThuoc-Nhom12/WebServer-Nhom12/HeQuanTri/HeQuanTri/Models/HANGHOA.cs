namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HANGHOA")]
    public partial class HANGHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HANGHOA()
        {
            CTBAOCAOHANGTONs = new HashSet<CTBAOCAOHANGTON>();
            CTDHs = new HashSet<CTDH>();
            CTHDs = new HashSet<CTHD>();
            CTNHAPHANGHOAs = new HashSet<CTNHAPHANGHOA>();
        }

        [Key]
        [StringLength(10)]
        public string MAHANGHOA { get; set; }

        [Required]
        [StringLength(50)]
        public string TENHANGHOA { get; set; }

        public decimal? DONGIANHAP { get; set; }

        public decimal? DONGIABAN { get; set; }

        [Required]
        [StringLength(10)]
        public string MANHOMHANG { get; set; }

        [Required]
        [StringLength(10)]
        public string MANHACUNGCAP { get; set; }

        [Required]
        [StringLength(10)]
        public string MADONVITINH { get; set; }

        public int? SOLUONGTON { get; set; }

        [Required]
        [StringLength(10)]
        public string MATUCHUA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBAOCAOHANGTON> CTBAOCAOHANGTONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDH> CTDHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTNHAPHANGHOA> CTNHAPHANGHOAs { get; set; }

        public virtual DONVITINH DONVITINH { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHOMHANG NHOMHANG { get; set; }

        public virtual TUCHUA TUCHUA { get; set; }
    }
}
