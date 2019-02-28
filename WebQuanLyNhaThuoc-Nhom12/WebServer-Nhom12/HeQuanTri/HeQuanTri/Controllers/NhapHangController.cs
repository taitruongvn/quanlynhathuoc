using HeQuanTri.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeQuanTri.Controllers
{
    public class NhapHangController : Controller
    {
        // GET: NhapHang
        public ActionResult Index()
        { 
            List<ViewCTNHAPHANGHOA> list =new List<ViewCTNHAPHANGHOA>();
            if(Session["Nhap"]!=null)
            {
                list = (List<ViewCTNHAPHANGHOA>)Session["Nhap"];
                return View(list);
            }
            return View(list);
        }

        public PartialViewResult ListHangCanNhap()
        {
            DataTable dt = SqlHelper.ExecuteDataset(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVThuKho;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_ListHangHoaCanNhap").Tables[0];
            List<HANGHOA> listDHXN = new List<HANGHOA>();
            listDHXN = Convert.ToList<HANGHOA>(dt);
            return PartialView(listDHXN);
        }

        public ActionResult ThemNhap([Bind(Include = "mahanghoa,soluongnhap,tenhanghoa")] ViewCTNHAPHANGHOA values)
        {
            List<ViewCTNHAPHANGHOA> list = new List<ViewCTNHAPHANGHOA>();
            if (Session["Nhap"] != null)
            {
                list = (List<ViewCTNHAPHANGHOA>)Session["Nhap"];
            }
            var value = list.SingleOrDefault(s => s.MAHANGHOA == values.MAHANGHOA);
            if (value == null)
            {
                list.Add(new ViewCTNHAPHANGHOA { MAHANGHOA = values.MAHANGHOA, SOLUONGNHAP = values.SOLUONGNHAP, TENHANGHOA = values.TENHANGHOA });
            }
            
            Session["Nhap"] = list;
            return RedirectToAction("Index");

        }
        public ActionResult XoaNhap([Bind(Include = "mahanghoa,soluongnhap")] ViewCTNHAPHANGHOA values)
        {
            List<ViewCTNHAPHANGHOA> list = new List<ViewCTNHAPHANGHOA>();
            if (Session["Nhap"] != null)
            {
                list = (List<ViewCTNHAPHANGHOA>)Session["Nhap"];
            }
            var value = list.SingleOrDefault(s => s.MAHANGHOA == values.MAHANGHOA);
            if (value != null)
            {
                list.Remove(value);
            }

            Session["Nhap"] = list;
            return RedirectToAction("Index");

        }

        public ActionResult XacNhanNhap()
        {
            List<ViewCTNHAPHANGHOA> list1 = new List<ViewCTNHAPHANGHOA>();
            if (Session["Nhap"] != null)
            {
                list1 = (List<ViewCTNHAPHANGHOA>)Session["Nhap"];
            }
            var list = list1.Select(e => new CTNHAPHANGHOA (){ MANHAPHANGHOA= e.MANHAPHANGHOA,MAHANGHOA= e.MAHANGHOA,SOLUONGNHAP= e.SOLUONGNHAP,THANHTIEN= e.THANHTIEN,DONGIANHAP= e.DONGIANHAP }).ToList();
            DataTable dt = new DataTable();
            dt = Convert.ToDataTable(list);
            using (SqlConnection conn = new SqlConnection("data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVThuKho;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))

                try
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_NhapHangHoa"; 
                    SqlParameter param = cmd.Parameters.AddWithValue("@listCTNH", dt);   
                    param = cmd.Parameters.AddWithValue("@manv", "NV00000001");
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Session["Nhap"] = null;
                    return RedirectToAction("ListNhapHang");
                }
                catch (Exception e)
                {
                    string[] s = e.Message.Split('/');
                    Session["Loi"] = s[0];
                    return RedirectToAction("Index");
                }
              
        }
        public ActionResult ListNhapHang()
        {
            DataTable dt = SqlHelper.ExecuteDataset(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVThuKho;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_ListNhapHang").Tables[0];
            List<NHAPHANGHOA> listDHXN = new List<NHAPHANGHOA>();
            listDHXN = Convert.ToList<NHAPHANGHOA>(dt);
            return PartialView(listDHXN);

        }
    }
}