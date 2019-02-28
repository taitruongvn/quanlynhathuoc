using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class GioHangController : Controller
    {
        dbQLNhaThuocDataContext data = new dbQLNhaThuocDataContext();
        database_access_layer.db dblayer = new database_access_layer.db();
        // GET: GioHang
        public List<Giohang> Laygiohang()
        {
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang == null)
            {
                lstGiohang = new List<Giohang>();
                Session["Giohang"] = lstGiohang;
            }
            return lstGiohang;
        }

        public ActionResult ThemGiohang(string iMAHANGHOA, string strURL)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.Find(n => n.iMAHANGHOA == iMAHANGHOA);
            if (sanpham == null)
            {
                sanpham = new Giohang(iMAHANGHOA);
                lstGiohang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSOLUONG++;
                return Redirect(strURL);
            }
        }
        private int TongSoLuong()
        {
            int iTONGSOLUONG = 0;
            List<Giohang> lstGiohang = Session["Giohang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTONGSOLUONG = lstGiohang.Sum(n => n.iSOLUONG);
            }
            return iTONGSOLUONG;
        }

        private double TongTien()
        {
            double iTONGTIEN = 0;
            List<Giohang> lstGiohang = Session["GioHang"] as List<Giohang>;
            if (lstGiohang != null)
            {
                iTONGTIEN = lstGiohang.Sum(n => n.dTHANHTIEN);
            }
            return iTONGTIEN;
        }
        public ActionResult GioHang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "NhaThuoc");
            }
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return View(lstGiohang);
        }

        public ActionResult GiohangPartial()
        {
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            return PartialView();
        }
        public ActionResult XoaGiohang(string iMASP)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.iMAHANGHOA == iMASP);
            if (sanpham != null)
            {
                lstGiohang.RemoveAll(n => n.iMAHANGHOA == iMASP);
                return RedirectToAction("GioHang");
            }
            if (lstGiohang.Count == 0)
            {
                return RedirectToAction("Index", "NhaThuoc");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult CapnhatGiohang(string iMASP, FormCollection f)
        {
            List<Giohang> lstGiohang = Laygiohang();
            Giohang sanpham = lstGiohang.SingleOrDefault(n => n.iMAHANGHOA == iMASP);
            if (sanpham != null)
            {
                sanpham.iSOLUONG = int.Parse(f["txtSoluong"].ToString());
            }
            return RedirectToAction("Giohang");
        }
        public ActionResult XoaTatcaGiohang()
        {
            List<Giohang> lstGiohang = Laygiohang();
            lstGiohang.Clear();
            return RedirectToAction("Index", "NhaThuoc");
        }

        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Khachhang");
            }
            if (Session["Giohang"] == null)
            {
                return RedirectToAction("Index", "NhaThuoc");
            }

            List<Giohang> lstGiohang = Laygiohang();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();

            return View(lstGiohang);
        }

        public ActionResult DatHang(FormCollection collection)
        {
            DATHANG dh = new DATHANG();
            KHACHHANG kh = (KHACHHANG)Session["Taikhoan"];
            List<Giohang> gh = Laygiohang();

            try
            {
                dh.NGAYLAP = DateTime.Now;
                dh.MAKH = kh.MAKH;
                dblayer.add_dh(dh);

                foreach (var item in gh)
                {
                    CTDH ctdh = new CTDH();
                    ctdh.MADH = "1";
                    ctdh.MAHANGHOA = item.iMAHANGHOA;
                    ctdh.SOLUONG = item.iSOLUONG;
                    ctdh.DONGIA = (decimal)item.dDONGIABAN;
                    ctdh.THANHTIEN = (decimal)item.dTHANHTIEN;
                    dblayer.add_ctdh(ctdh);
                }
            }
            catch (Exception ex)
            {
                @ViewBag.Error = ex.Message;
                return this.DatHang();
            }
            Session["Giohang"] = null;
            return RedirectToAction("Xacnhandonhang", "Giohang");
        }

        public ActionResult Xacnhandonhang()
        {
            return View();
        }
    }
}