namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHOMHANG")]
    public partial class NHOMHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHOMHANG()
        {
            HANGHOAs = new HashSet<HANGHOA>();
        }

        [Key]
        [StringLength(10)]
        public string MANHOMHANG { get; set; }

        [Required]
        [StringLength(50)]
        public string TENNHOMHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HANGHOA> HANGHOAs { get; set; }
    }
}
