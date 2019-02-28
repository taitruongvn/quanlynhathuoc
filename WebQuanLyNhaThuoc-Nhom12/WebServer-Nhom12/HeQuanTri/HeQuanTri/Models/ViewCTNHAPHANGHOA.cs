using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HeQuanTri.Models
{
    public class ViewCTNHAPHANGHOA
    {
        public string MANHAPHANGHOA { get; set; }
        public string MAHANGHOA { get; set; }
        public string TENHANGHOA { get; set; }

        public int SOLUONGNHAP { get; set; }

        public int? DONGIANHAP { get; set; }

        public decimal? THANHTIEN { get; set; }
    }
}