namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACUNGCAP")]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            HANGHOAs = new HashSet<HANGHOA>();
        }

        [Key]
        [StringLength(10)]
        public string MANHACUNGCAP { get; set; }

        [Required]
        [StringLength(50)]
        public string TENNHACUNGCAP { get; set; }

        [Required]
        [StringLength(50)]
        public string DIACHI { get; set; }

        [Required]
        [StringLength(11)]
        public string SODIENTHOAI { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HANGHOA> HANGHOAs { get; set; }
    }
}
