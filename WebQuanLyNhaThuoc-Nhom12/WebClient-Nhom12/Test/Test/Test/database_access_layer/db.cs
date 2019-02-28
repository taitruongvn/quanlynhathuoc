using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Test.Models;

namespace Test.database_access_layer
{
    public class db
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public void add_record(Khachhang kh)
        {
            SqlCommand com = new SqlCommand("sp_ThemKhachHang",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@TENKHACHHANG",kh.TENKHACHHANG);
            com.Parameters.AddWithValue("@GIOITINH",kh.GIOITINH);
            com.Parameters.AddWithValue("@NGAYSINH",kh.NGAYSINH);
            com.Parameters.AddWithValue("@DIACHI",kh.DIACHI);
            com.Parameters.AddWithValue("@SODIENTHOAI",kh.SODIENTHOAI);
            com.Parameters.AddWithValue("@EMAIL",kh.EMAIL);
            com.Parameters.AddWithValue("@CMND",kh.CMND);
            com.Parameters.AddWithValue("@ID",kh.ID);
            com.Parameters.AddWithValue("@PASS",kh.PASS);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

       public int user_login(string userid, string password)
        {
            int res = 0;
            SqlCommand com = new SqlCommand("sp_CheckDangNhapKhachHang", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", userid);
            com.Parameters.AddWithValue("@PASS", password);

            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@RES";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            res = Convert.ToInt32(oblogin.Value);
            return res;
        }

        public void add_dh(DATHANG dh)
        {
            SqlCommand com = new SqlCommand("sp_ThemDatHang", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@NGAYLAP", dh.NGAYLAP);
            com.Parameters.AddWithValue("@MAKH", dh.MAKH);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void add_ctdh(CTDH ctdh)
        {
            SqlCommand com = new SqlCommand("sp_ThemCTDH", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MADH", ctdh.MADH);
            com.Parameters.AddWithValue("@MAHANGHOA", ctdh.MAHANGHOA);
            com.Parameters.AddWithValue("@SOLUONG", ctdh.SOLUONG);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Suakhachhang(KHACHHANG kh)
        {
            SqlCommand com = new SqlCommand("sp_SuaKhachHang", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@MAKH", kh.MAKH);
            com.Parameters.AddWithValue("@TENKHACHHANG", kh.TENKHACHHANG);
            com.Parameters.AddWithValue("@GIOITINH", kh.GIOITINH);
            com.Parameters.AddWithValue("@NGAYSINH", kh.NGAYSINH);
            com.Parameters.AddWithValue("@DIACHI", kh.DIACHI);
            com.Parameters.AddWithValue("@SODIENTHOAI", kh.SODIENTHOAI);
            com.Parameters.AddWithValue("@EMAIL", kh.EMAIL);
            com.Parameters.AddWithValue("@CMND", kh.CMND);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}