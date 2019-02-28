namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAPHANGHOA")]
    public partial class NHAPHANGHOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAPHANGHOA()
        {
            CTNHAPHANGHOAs = new HashSet<CTNHAPHANGHOA>();
        }

        [Key]
        [StringLength(10)]
        public string MANHAPHANGHOA { get; set; }

        [Required]
        [StringLength(10)]
        public string MANV { get; set; }

        public DateTime? NGAYNHAP { get; set; }

        public decimal? TONGSOTIEN { get; set; }

        public bool? TINHTRANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTNHAPHANGHOA> CTNHAPHANGHOAs { get; set; }
    }
}
