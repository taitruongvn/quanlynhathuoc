namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYDINH")]
    public partial class QUYDINH
    {
        [Key]
        [StringLength(10)]
        public string MAQUYDINH { get; set; }

        [Required]
        [StringLength(50)]
        public string TENQUYDINH { get; set; }

        public int? GIATRI { get; set; }
    }
}
