namespace HeQuanTri.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTBAOCAOHANGTON")]
    public partial class CTBAOCAOHANGTON
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MABAOCAO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MAHANGHOA { get; set; }

        public int? TONDAU { get; set; }

        public int? PHATSINH { get; set; }

        public int? TONCUOI { get; set; }

        public virtual BAOCAOHANGTON BAOCAOHANGTON { get; set; }

        public virtual HANGHOA HANGHOA { get; set; }
    }
}
