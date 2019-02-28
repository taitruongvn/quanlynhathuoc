-----------QuanLy----------------------------------------
create role G_QuanLy
go
grant select, insert, update on NHANVIEN to G_QuanLy
grant select, insert on QUIDINH to G_QuanLy
grant select, insert,Update on CTQD to G_QuanLy

grant EXECUTE on func_TaoMaNV to G_QuanLy
go
sp_addrolemember db_datareader,G_QuanLy


-----------KeToan----------------------------------------
go
create role G_KeToan
grant select, insert on BAOCAOHANGTON to G_KeToan


-----------NVBANHANG----------------------------------------
go
create role G_NVBanHang
grant select, insert,update on HoaDon to G_NVBanHang
grant select, insert,update on CTHD to G_NVBanHang
grant select,update on HANGHOA to G_NVBanHang
grant select,update,delete on DatHang to G_NVBanHang
grant select,delete on CTDH to G_NVBanHang
grant select,insert,update on KhachHang to G_NVBanHang



grant EXECUTE on sp_ChiTietDatHang to G_NVBanHang
grant EXECUTE on sp_ChiTietHoaDon to G_NVBanHang
grant EXECUTE on sp_HuyXacNhanDangGiao to G_NVBanHang
grant EXECUTE on sp_ListDatHangCanXacNhan to G_NVBanHang
grant EXECUTE on sp_ListDatHangDaXacNhan to G_NVBanHang
grant EXECUTE on sp_ListHoaDonOnline to G_NVBanHang
grant EXECUTE on sp_XacNhanDaGiao to G_NVBanHang
grant EXECUTE on sp_XacNhanDatHang to G_NVBanHang
grant EXECUTE on sp_ListHoaDonTaiQuay to G_NVBanHang

grant EXECUTE on func_TaoMaHoaDon to G_NVBanHang

create login NVBanHang	with password='123'

create user U_NVBanHang for login NVBanHang

Exec sp_addrolemember 'G_NVBanHang','U_NVBanHang';



-----------ThuKho----------------------------------------
go
create role G_ThuKho
grant select,update on HangHoa to G_ThuKho
grant select, insert,update on CTNHAPHANGHOA to G_ThuKho
grant select, insert,update on NHAPHANGHOA to G_ThuKho

grant EXECUTE on func_TaoMaNhapHangHoa to G_ThuKho
grant EXECUTE on sp_ListHangHoaCanNhap to G_ThuKho
grant EXECUTE on sp_NhapHangHoa to G_ThuKho
grant EXECUTE on sp_ListHangHoaCanNhap to G_ThuKho
grant EXECUTE on sp_ListNhapHang to G_ThuKho
create login NVThuKho	with password='123'

create user U_NVThuKho for login NVThuKho

Exec sp_addrolemember 'G_ThuKho','U_NVThuKho';


-----------KhachHang----------------------------------------
create role G_KhachHang
grant select, insert,update on KhachHang to G_KhachHang
grant select on HangHoa to G_KhachHang
grant select,insert,update on DatHang to G_KhachHang
grant select,insert,update on CTDH to G_KhachHang

grant EXECUTE on func_TaoMaKhachHang to G_KhachHang
grant EXECUTE on func_TaoMaDatHang to G_KhachHang
grant EXECUTE on func_LayMaDatHang to G_KhachHang

grant EXECUTE on sp_CheckDangNhapKhachHang to G_KhachHang
grant EXECUTE on sp_SuaKhachHang to G_KhachHang
grant EXECUTE on sp_ThemCTDH to G_KhachHang
grant EXECUTE on sp_ThemKhachHang to G_KhachHang
grant EXECUTE on sp_ThemDatHang to G_KhachHang

create login KhachHang	with password='123'

create user U_KhachHang for login KhachHang

Exec sp_addrolemember 'G_KhachHang','U_KhachHang';


