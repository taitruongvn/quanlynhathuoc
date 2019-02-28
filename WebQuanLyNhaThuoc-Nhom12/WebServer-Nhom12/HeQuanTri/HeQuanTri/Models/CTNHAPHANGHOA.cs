namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTNHAPHANGHOA")]
    public partial class CTNHAPHANGHOA
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MANHAPHANGHOA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MAHANGHOA { get; set; }

        public int SOLUONGNHAP { get; set; }

        public int? DONGIANHAP { get; set; }

        public decimal? THANHTIEN { get; set; }

    }
}
