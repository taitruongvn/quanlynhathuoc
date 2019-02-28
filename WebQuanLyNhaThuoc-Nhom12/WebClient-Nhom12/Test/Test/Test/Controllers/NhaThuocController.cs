using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using PagedList;
using PagedList.Mvc;
using System.Data;

namespace Test.Controllers
{
    public class NhaThuocController : Controller
    {
        // GET: NhaThuoc

        dbQLNhaThuocDataContext data = new dbQLNhaThuocDataContext();
        database_access_layer.db dblayer = new database_access_layer.db();

        private List<CTQD> Layhanghoamoi(int count)
        {
            return data.CTQDs.OrderByDescending(a => a.MAHANGHOA).Where(b => b.MAQUIDINH == "B").Take(count).ToList();
        }

        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            var hanghoamoi = Layhanghoamoi(15);
            return View(hanghoamoi.ToPagedList(pageNum, pageSize));
        }

        public ActionResult Nhomhang()
        {
            var nhomhang = from nh in data.NHOMHANGs select nh;
            return PartialView(nhomhang);
        }

        public ActionResult Nhacungcap()
        {
            var nhacungcap = from ncc in data.NHACUNGCAPs select ncc;
            return PartialView(nhacungcap);
        }

        public ActionResult SPTheonhomhang(string id, int? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            var hanghoa = from hh in data.HANGHOAs
                          from qd in data.CTQDs
                          where hh.MANHOMHANG == id && qd.MAHANGHOA == hh.MAHANGHOA && qd.MAQUIDINH == "B"
                          select hh;
            return View(hanghoa.ToPagedList(pageNum, pageSize));
        }

        public ActionResult SPTheonhacungcap(string id, int? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            //var hanghoa = from hh in data.HANGHOAs where hh.MANHACUNGCAP == id select hh;
            var hanghoa = from hh in data.HANGHOAs
                          from qd in data.CTQDs
                          where hh.MANHACUNGCAP == id && qd.MAHANGHOA == hh.MAHANGHOA && qd.MAQUIDINH == "B"
                          select hh;
            return View(hanghoa.ToPagedList(pageNum, pageSize));
        }

        public ActionResult Details(string id)
        {
            var hanghoa = from hh in data.HANGHOAs
                          where hh.MAHANGHOA == id
                          select hh;
            return View(hanghoa.Single());
        }
        public ActionResult MenuLoginPartial()
        {
            return PartialView();
        }

        public ActionResult Search(string searchString, int? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            var hanghoa = from hh in data.HANGHOAs
                          select hh;

            if (!String.IsNullOrEmpty(searchString))
            {
                hanghoa = hanghoa.Where(s => s.TENHANGHOA.Contains(searchString));
            }
            return View(hanghoa.ToPagedList(pageNum, pageSize));
        }

        public ActionResult KhachhangDetails(String id)
        {
            KHACHHANG khachhang = data.KHACHHANGs.SingleOrDefault(n => n.MAKH == id);
            if (Session["Show2"] == null)
            {
                return RedirectToAction("Index", "NhaThuoc");
            }
            if (khachhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachhang);
        }

        [HttpGet]
        public ActionResult EditKhachhang(String id)
        {
            KHACHHANG khachhang = data.KHACHHANGs.SingleOrDefault(n => n.MAKH == id);
            if (khachhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(khachhang);
        }
        [HttpPost]
        public ActionResult EditKhachhang(KHACHHANG khachhang)
        {
            if (Session["Show2"] == null)
            {
                return RedirectToAction("Index", "NhaThuoc");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    database_access_layer.db db = new database_access_layer.db();
                    db.Suakhachhang(khachhang);
                    return RedirectToAction("KhachhangDetails", "NhaThuoc", new {id = Session["Show2"]});
                }
            }
            catch (Exception ex)
            {
                @ViewBag.Error = ex.Message;
                return View(khachhang);
            }
            return View(khachhang);
        }

        public ActionResult ListHD(String id)
        {
            KHACHHANG khachhang = data.KHACHHANGs.SingleOrDefault(n => n.MAKH == id);
            var hoadon = data.HOADONs.OrderByDescending(s => s.NGAYLAP).Where(x => x.MAKH == id);
            return View(hoadon.Take(7).ToList());
        }

        public ActionResult DetailsHD(string id)
        {
            HOADON hoadon = data.HOADONs.SingleOrDefault(n => n.MAHD == id);
            var chitiethoadon = data.CTHDs.OrderByDescending(s => s.MAHD).Where(x => x.MAHD == id);
            return View(chitiethoadon.ToList());
        }

        public ActionResult SPlienquan(string nh, string id, int? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            var hanghoa = from hh in data.HANGHOAs
                          from qd in data.CTQDs
                          where hh.MANHOMHANG == nh && qd.MAHANGHOA == hh.MAHANGHOA && qd.MAQUIDINH == "B" && hh.MAHANGHOA != id
                          select hh;
            return View(hanghoa.ToPagedList(pageNum, pageSize));
        }

        public ActionResult showbanchay(int? page)
        {
            int pageSize = 5;
            int pageNum = (page ?? 1);
            var items = data.HANGHOAs.OrderByDescending(u => u.CTHDs.Count(a => a.MAHD.StartsWith("DH"))).Take(15);
            return View(items.ToPagedList(pageNum, pageSize));
        }
    }
}