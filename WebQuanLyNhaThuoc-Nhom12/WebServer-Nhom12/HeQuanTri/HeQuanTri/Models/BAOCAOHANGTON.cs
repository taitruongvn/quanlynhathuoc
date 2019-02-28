namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOCAOHANGTON")]
    public partial class BAOCAOHANGTON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BAOCAOHANGTON()
        {
            CTBAOCAOHANGTONs = new HashSet<CTBAOCAOHANGTON>();
        }

        [Key]
        [StringLength(10)]
        public string MABAOCAO { get; set; }

        public DateTime? NGAYLAPBAOCAO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBAOCAOHANGTON> CTBAOCAOHANGTONs { get; set; }
    }
}
