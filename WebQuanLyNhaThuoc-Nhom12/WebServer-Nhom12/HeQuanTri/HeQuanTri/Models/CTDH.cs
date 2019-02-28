namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDH")]
    public partial class CTDH
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MADH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MAHANGHOA { get; set; }

        public int SOLUONG { get; set; }

        public decimal? DONGIA { get; set; }

        public decimal? THANHTIEN { get; set; }

        public virtual DATHANG DATHANG { get; set; }

        public virtual HANGHOA HANGHOA { get; set; }
    }
}
