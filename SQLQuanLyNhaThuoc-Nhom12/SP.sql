use QuanLyNhaThuoc
go

--------------- KHACH HANG ------------------
--SP Thêm Thông Tin Khách Hàng
create proc sp_ThemKhachHang(
	@TENKHACHHANG NVarChar(50),
	@GIOITINH int,
	@NGAYSINH varchar(20) ,
	@DIACHI NVarChar(100) ,
	@SODIENTHOAI VarChar(11) ,
	@EMAIL NVarChar(50) ,
	@CMND VarChar(11) ,
	@ID varchar(30) ,
	@PASS varchar(30))
as
begin
	if not exists (select MAKH from KHACHHANG where ID = @ID)
		begin
			if ((DATEDIFF(year,@NGAYSINH,GETDATE())>18))
			begin
				INSERT INTO KHACHHANG(TENKHACHHANG,GIOITINH,NGAYSINH,DIACHI,SODIENTHOAI,EMAIL,CMND,ID,PASS)
				VALUES(@TENKHACHHANG,@GIOITINH,CAST(@NGAYSINH as DATE),@DIACHI,@SODIENTHOAI,@EMAIL,@CMND,@ID,EncryptByPassPhrase('key',@PASS))
			end
			else
			begin
				raiserror('Phải trên 18 tuổi',16,1)
				rollback tran
			end
		end
	else
		begin
			raiserror('ID của bạn đã bị trùng',16,1)
		end
end
go

--SP Sửa Thông Tin Khách Hàng
create proc sp_SuaKhachHang(
	@MAKH char(10),
	@TENKHACHHANG NVarChar(50),
	@GIOITINH int,
	@NGAYSINH varchar(20) ,
	@DIACHI NVarChar(100) ,
	@SODIENTHOAI VarChar(11) ,
	@EMAIL NVarChar(50) ,
	@CMND VarChar(11) 
	)
as
begin
	if ((DATEDIFF(year,@NGAYSINH,GETDATE())>18))
		update KHACHHANG set 
		TENKHACHHANG = @TENKHACHHANG, GIOITINH = @GIOITINH, NGAYSINH=CAST(@NGAYSINH as DATE),DIACHI=@DIACHI,SODIENTHOAI=@SODIENTHOAI,EMAIL= @EMAIL,CMND = @CMND
		where MAKH = @MAKH
	else
		begin
			raiserror('Phải trên 18 tuổi',16,1)
			rollback tran
		end
end
go

--SP Check Đăng Nhập Khách Hàng
create proc sp_CheckDangNhapKhachHang(@ID varchar(30),@PASS varchar(30), @RES bit out)
as
begin
	set @RES = (select count(ID) from KHACHHANG where ID = @ID and CAST(DECRYPTBYPASSPHRASE('key',PASS) AS VARCHAR(30)) = @PASS)
	
end
go

--------------- NHAN VIEN ------------------
--SP Thêm Thông Tin Nhân Viên
create proc sp_ThemNhanVien(
	@TENNV nvarchar(50),
	@GIOITINH bit ,
	@NGAYSINH DATE ,
	@SODIENTHOAI varchar(11) ,
	@EMAIL VARCHAR(50) ,
	@DIACHI nvarchar(50) ,
	@MAQUYEN CHAR(10) ,
	@ID varchar(30),
	@PASS varchar(30))
as
	begin
	if not exists (select MANV from NHANVIEN where ID = @ID)
		begin
		INSERT INTO NHANVIEN(TENNV,GIOITINH,NGAYSINH,DIACHI,SODIENTHOAI,EMAIL,MAQUYEN,ID,PASS)
		VALUES(@TENNV,@GIOITINH,CAST(@NGAYSINH as DATE),@DIACHI,@SODIENTHOAI,@EMAIL,@MAQUYEN,@ID,EncryptByPassPhrase('key',@PASS))
		end
		else
		begin
			raiserror('ID của bạn đã bị trùng',16,1)
		end
	end
go

--SP Check Đăng Nhập Nhân Viên
create proc sp_CheckDangNhapNhanVien(@ID varchar(30),@PASS varchar(30))
as
begin
	if exists(select MANV from NHANVIEN where ID = @ID and CAST(DECRYPTBYPASSPHRASE('key',PASS) AS VARCHAR(30)) = @PASS)
		select 'True' as KQ
		else
		select 'False' as KQ
end
go

--------------- HOA DON ------------------
--SP Xác Nhận Đã Giao
alter proc sp_XacNhanDaGiao @madh varchar(10)
as
begin
	SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	begin tran
	update DATHANG set TIENTHANHTOAN=TONGTIEN where MADH=@madh
	Delete DATHANG where MADH = @madh
	commit tran
end
go

--SP Xác Nhận Đặt Hàng
create proc sp_XacNhanDatHang @madh varchar(10), @manv varchar(10)
as
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
begin tran
	Update DATHANG set Trangthai = 1,MANV=@manv where MADH=@madh
commit
go

--SP Hủy Xác Nhận Đang Giao
create proc sp_HuyXacNhanDangGiao @madh varchar(10)
as
begin
	begin tran
	Update DATHANG set Trangthai = 0 where MADH=@madh
	Delete DATHANG where MADH = @madh
	commit tran
end
go

--SP List Đặt Hàng Cần Xác Nhận
create proc sp_ListDatHangCanXacNhan
as
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
begin tran
	select * from DATHANG where TRANGTHAI=0
commit
go

--SP Chi Tiết Đặt Hàng
create proc sp_ChiTietDatHang @madh varchar(10)
as
begin
	select hh.TENHANGHOA as MAHANGHOA,ct.SOLUONG,ct.DONGIA,ct.THANHTIEN from CTDH ct,HANGHOA hh where MADH=@madh and hh.MAHANGHOA = ct.MAHANGHOA
end
go

--SP Chi Tiết Hóa Đơn
create proc sp_ChiTietHoaDon @madh varchar(10)
as
begin
	select hh.TENHANGHOA as MAHANGHOA,ct.SOLUONG,ct.DONGIA,ct.THANHTIEN from CTHD ct,HANGHOA hh where MAHD=@madh and hh.MAHANGHOA = ct.MAHANGHOA
end
go

--SP List Đặt Hàng Đã Xác Nhận
create proc sp_ListDatHangDaXacNhan
as
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
begin tran
	select * from DATHANG where TRANGTHAI=1
commit
go

--SP List Hóa Đơn Online
create proc sp_ListHoaDonOnline
as
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
begin tran
	select MAHD, kh.TENKHACHHANG as MAKH,  nv.TENNV as MANV, hd.NGAYLAP, TONGTIEN,TIENTHANHTOAN,TIENTHUA
	from HOADON hd,KHACHHANG kh,NHANVIEN nv where TRANGTHAI=1 and MAHD like 'DH%' and hd.MAKH = kh.MAKH and hd.MANV = nv.MANV
commit
go

--SP Thêm Chi Tiết Đặt Hàng
create	proc sp_ThemCTDH(
	@MADH char(10),
	@MAHANGHOA char(10),
	@SOLUONG int
	)
as
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	begin tran
		set @MADH = (Select top 1 MADH From  DATHANG order by MADH desc)
		INSERT INTO CTDH(MADH,MAHANGHOA, SOLUONG)
		VALUES(@MADH,@MAHANGHOA, @SOLUONG)
	commit 
go

--SP Thêm Đặt Hàng
create proc sp_ThemDatHang(
	@NGAYLAP datetime,
	@MAKH CHAR(10))
as
	begin tran
		INSERT INTO DATHANG(NGAYLAP, MAKH)
		VALUES(@NGAYLAP,@MAKH)
	commit tran
go

--SP List Hóa Đơn tại quầy
create proc sp_ListHoaDonTaiQuay
as
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
begin tran
	select MAHD, kh.TENKHACHHANG as MAKH,  nv.TENNV as MANV, hd.NGAYLAP, TONGTIEN,TIENTHANHTOAN,TIENTHUA
	from HOADON hd,KHACHHANG kh,NHANVIEN nv where TRANGTHAI=1 and MAHD like 'HD%' and hd.MAKH = kh.MAKH and hd.MANV = nv.MANV
commit
go

--SP List Hàng Hóa Cần Nhập
create proc sp_ListHangHoaCanNhap
as
	select * from HANGHOA where SOLUONGTON<50
go

--SP List Chi Tiết Nhập Hàng
create type ListCTNH as Table(
	MANHAPHANGHOA char(10),
	MAHANGHOA char(10),
	SOLUONGNHAP int,
	DONGIANHAP int,
	THANHTIEN int
)
go

--SP Nhập Hàng Hóa
create PROCEDURE sp_NhapHangHoa (@listCTNH ListCTNH READONLY,@manv varchar(10))
AS  
BEGIN Tran
	declare @manhaphang varchar(10)
	insert into NHAPHANGHOA(MANV) values(@manv)
	select TOP 1 @manhaphang = MANHAPHANGHOA from NHAPHANGHOA order by MANHAPHANGHOA desc
	declare @mahh varchar(10), @soluongnhap int
	declare cur cursor for (select MAHANGHOA,SOLUONGNHAP from @listCTNH)
	open cur
	fetch next from cur into @mahh,@soluongnhap
	WHILE @@FETCH_STATUS = 0  
BEGIN  
	INSERT INTO CTNHAPHANGHOA(MANHAPHANGHOA,MAHANGHOA,SOLUONGNHAP) values (@manhaphang,@mahh,@soluongnhap)
    fetch next from cur into @mahh,@soluongnhap
END   
	CLOSE cur;  
	DEALLOCATE cur;  
   UPDATE  NHAPHANGHOA set TINHTRANG=1 Where MANHAPHANGHOA=@manhaphang
Commit Tran

go

--SP List Nhập Hàng
create proc sp_ListNhapHang
as
	select * From NHAPHANGHOA order by NGAYNHAP Desc