using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Giohang
    {
        dbQLNhaThuocDataContext data = new dbQLNhaThuocDataContext();
        public string iMAHANGHOA { get; set; }
        public string sTENHANGHOA { get; set; }
        public string sDONVITINH { get; set; }
        public Double dDONGIABAN { get; set; }
        public int iSOLUONG { get; set; }
        public Double dTHANHTIEN
        {
            get { return iSOLUONG * dDONGIABAN; }
        }

        public Giohang(string MAHANGHOA)
        {
            iMAHANGHOA = MAHANGHOA;
            HANGHOA hanghoa = data.HANGHOAs.Single(n => n.MAHANGHOA == iMAHANGHOA);
            DONVITINH donvitinh = data.DONVITINHs.Single(n => n.MADONVITINH == hanghoa.MADONVITINH);
            sDONVITINH = donvitinh.TENDONVITINH;
            sTENHANGHOA = hanghoa.TENHANGHOA;
            dDONGIABAN = double.Parse(hanghoa.DONGIABAN.ToString());
            iSOLUONG = 1;
        }
    }
}