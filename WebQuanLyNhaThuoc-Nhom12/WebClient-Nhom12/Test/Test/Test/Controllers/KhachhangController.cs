using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Test.Models;

namespace Test.Controllers
{
    public class KhachhangController : Controller
    {
        // GET: Demo
        dbQLNhaThuocDataContext data = new dbQLNhaThuocDataContext();
        database_access_layer.db dblayer = new database_access_layer.db();

        public ActionResult Add_record()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add_record(FormCollection fc)
        {
            if (data.KHACHHANGs.Any(ac => ac.ID.Equals(fc["cmnd"])))
            {
                ViewData["LoiTrungCmnd"] = "Số cmnd này đã tồn tại";
            }
            else if (data.KHACHHANGs.Any(ac => ac.ID.Equals(fc["id"])))
            {
                ViewData["LoiTrungID"] = "ID này đã tồn tại";
            }
            else if (data.KHACHHANGs.Any(ac => ac.EMAIL.Equals(fc["cmnd"])))
            {
                ViewData["LoiTrungEmail"] = "Email này đã tồn tại";
            }
            else
            {
                try
                {
                    Khachhang kh = new Khachhang();
                    kh.TENKHACHHANG = fc["hoten"];
                    kh.GIOITINH = Int32.Parse(fc["gioitinh"]);
                    kh.NGAYSINH = DateTime.Parse(fc["ngaysinh"]);
                    kh.DIACHI = fc["diachi"];
                    kh.SODIENTHOAI = fc["sdt"];
                    kh.EMAIL = fc["email"];
                    kh.CMND = fc["cmnd"];
                    kh.ID = fc["id"];
                    kh.PASS = fc["pass"];
                    dblayer.add_record(kh);
                    TempData["msg"] = "Dang ky thanh cong";
                    return RedirectToAction("Dangnhap", "Khachhang");
                }
                catch (Exception ex)
                {
                    @ViewBag.Error = ex.Message;
                    return this.Add_record();
                }
            }
            return this.Add_record();
        }

        public ActionResult Dangnhap()
        {
            if (Session["Show2"] != null)
            {
                return RedirectToAction("Index", "NhaThuoc");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(FormCollection fc)
        {
            int res = dblayer.user_login(fc["userid"], fc["password"]);
            if(res==1)
            {
                KHACHHANG kh = data.KHACHHANGs.SingleOrDefault(n=>n.ID == fc["userid"]);
                TempData["msg2"] = "Dang nhap thanh cong";
                Session["Taikhoan"] = kh;   
                Session["Show"] = "Xin chào "+ kh.TENKHACHHANG + "!";
                Session["Show2"] = kh.MAKH;
                return RedirectToAction("Index", "NhaThuoc");
            }
            else
            {
                TempData["msg2"] = "Sai tai khoan hoac mat khau";
                return this.Dangnhap();
            }
            return View();
        }
        public ActionResult Dangxuat()
        {
            Session.Clear();
            TempData.Remove("msg");
            TempData.Remove("msg2");
            return RedirectToAction("Index","NhaThuoc");
        }
    }
}