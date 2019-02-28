using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeQuanTri.Models
{
    public class HangHoaes
    {
        public string MAHANGHOA { get; set; }

     
        public string TENHANGHOA { get; set; }

        public decimal? DONGIANHAP { get; set; }

        public decimal? DONGIABAN { get; set; }

      
        public string MANHOMHANG { get; set; }

        public string MANHACUNGCAP { get; set; }

     
        public string MADONVITINH { get; set; }

        public int? SOLUONGTON { get; set; }

      
        public string MATUCHUA { get; set; }
        public virtual DONVITINH DONVITINH { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHOMHANG NHOMHANG { get; set; }

        public virtual TUCHUA TUCHUA { get; set; }
    }
}