using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Test.Models;

namespace Test.Models
{
    public class Khachhang
    {
        public string MAKH { get; set; }
        public string TENKHACHHANG { get; set; }
        public int GIOITINH { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public string SODIENTHOAI { get; set; }
        public string EMAIL { get; set; }
        public string CMND { get; set; }
        public string ID { get; set; }
        public string PASS { get; set; }
        public DateTime NGAYLAP { get; set; }
    }
}