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
    public class HoaDonController : Controller
    {
        // GET: HoaDon
        public ActionResult ListHoaDonOnline()
        {
            DataTable dt = SqlHelper.ExecuteDataset(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVBanHang;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_ListHoaDonOnline").Tables[0];
            List<HOADON> listDHXN = new List<HOADON>();
            listDHXN = Convert.ToList<HOADON>(dt);
            return View(listDHXN);
        }

        public ActionResult ListHoaDonTaiQuay()
        {
            DataTable dt = SqlHelper.ExecuteDataset(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVBanHang;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_ListHoaDonTaiQuay").Tables[0];
            List<HOADON> listDHXN = new List<HOADON>();
            listDHXN = Convert.ToList<HOADON>(dt);
            return View(listDHXN);
        }

        public ActionResult ChiTiet(string id)
        {
            DataTable dt = SqlHelper.ExecuteDataset(@"data source=.;initial catalog=QuanLyNhaThuoc;User ID=NVBanHang;Password=123;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "sp_ChiTietHoaDon", id).Tables[0];
            List<CTHD> listDHXN = new List<CTHD>();
            listDHXN = Convert.ToList<CTHD>(dt);
            @ViewBag.MaDH = id;
            return View(listDHXN);
        }

        public ActionResult Test()
        {
            List<CTHD> a = new List<CTHD> {
                new CTHD{ MAHD="HD00000001",MAHANGHOA="HH00000001",SOLUONG=1},
                new CTHD{ MAHD="HD00000001",MAHANGHOA="HH00000002",SOLUONG=1},
            };
            //int dt = SqlHelper.ExecuteNonQuery(@"data source=.;initial catalog=QuanLyNhaThuoc;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework", "Sp_Test", a);
            DataTable dt = new DataTable();
            dt = Convert.ToDataTable(a);
            using (SqlConnection conn = new SqlConnection("data source=.;initial catalog=QuanLyNhaThuoc;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework"))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Sp_Test"; //The name of the above mentioned stored procedure.  
                SqlParameter param = cmd.Parameters.AddWithValue("@listCTHD", dt); //Here"@MyUDTableType" is the User-defined Table Type as a parameter.  
                param.SqlDbType = SqlDbType.Structured;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            return View();
        }
    }
}