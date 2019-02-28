namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LAPPHIEUTHUTIEN")]
    public partial class LAPPHIEUTHUTIEN
    {
        [Key]
        [StringLength(10)]
        public string MAPHIEUTHU { get; set; }

        [Required]
        [StringLength(10)]
        public string MAHD { get; set; }

        [Required]
        [StringLength(10)]
        public string MANV { get; set; }

        public DateTime? NGAYLAPPHIEU { get; set; }

        public decimal? SOTIENTHU { get; set; }
    }
}
