using HeQuanTri.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeQuanTri.Controllers
{
    public class DatHangController : Controller
    {
        // GET: DatHang
        public ActionResult ListChuaXacNhan()
        {
            DataTable dt = SqlHelper.ExecuteDataset(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVBanHang;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_ListDatHangCanXacNhan").Tables[0];
            List<DATHANG> listDHXN = new List<DATHANG>();
            listDHXN = Convert.ToList<DATHANG>(dt);
            return View(listDHXN);
        }
        public ActionResult ChiTiet(string id)
        {
            DataTable dt = SqlHelper.ExecuteDataset(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVBanHang;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_ChiTietDatHang", id).Tables[0];
            List<CTDH> listDHXN = new List<CTDH>();
            listDHXN = Convert.ToList<CTDH>(dt);
            @ViewBag.MaDH = id;
            return View(listDHXN);
        }

        public ActionResult ListXacNhan()
        {
            DataTable dt = SqlHelper.ExecuteDataset(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVBanHang;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_ListDatHangDaXacNhan").Tables[0];
            List<DATHANG> listDHXN = new List<DATHANG>();
            listDHXN = Convert.ToList<DATHANG>(dt);
            return View(listDHXN);
        }

        public ActionResult XacNhanDatHang(string id)
        { 
            try
        {
            int dt = SqlHelper.ExecuteNonQuery(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVBanHang;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_XacNhanDatHang", id, "NV00000001");
            return RedirectToAction("ListXacNhan");
            }
            catch
            {
                return RedirectToAction("ListChuaXacNhan");
            }
           
        }

        public ActionResult XacNhanDaGiao(string id)
        {
            try
            {
                int dt = SqlHelper.ExecuteNonQuery(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVBanHang;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_XacNhanDaGiao", id);
                return RedirectToAction("ListHoaDonOnline", "HoaDon");
            }
            catch
            {
                return RedirectToAction("XacNhan");
            }
        }

        public ActionResult HuyDatHang(string id)
        {
            try
            {
                int dt = SqlHelper.ExecuteNonQuery(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVBanHang;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_HuyXacNhanDangGiao", id);
                return RedirectToAction("ListHoaDonOnline", "HoaDon");
            }
            catch
            {
                return RedirectToAction("XacNhan");
            }
        }

    }
}