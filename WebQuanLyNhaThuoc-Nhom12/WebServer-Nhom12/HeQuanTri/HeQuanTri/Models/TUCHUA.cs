namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TUCHUA")]
    public partial class TUCHUA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TUCHUA()
        {
            HANGHOAs = new HashSet<HANGHOA>();
        }

        [Key]
        [StringLength(10)]
        public string MATUCHUA { get; set; }

        [Required]
        [StringLength(50)]
        public string TENTUCHUA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HANGHOA> HANGHOAs { get; set; }
    }
}
