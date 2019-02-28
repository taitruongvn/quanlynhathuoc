use master
go
if exists(select * from sysdatabases where name='QuanLyNhaThuoc')
	drop database QuanLyNhaThuoc
--create table
create database QuanLyNhaThuoc
GO
use QuanLyNhaThuoc
go
----------------------------------------------------
--- NhanVien---
create FUNCTION func_TaoMaNV()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10), @nextmaNV varchar (10),@maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='NV'
	set @size=10
	set @maCuoi = (select TOP 1 manv from NHANVIEN order by MANV desc)
	if @maCuoi is null
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- NhomHang ---
create FUNCTION func_TaoMaNhomHang()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10),@nextmaNV varchar (10),@maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='NH'
	set @size=10
	set @maCuoi = (select TOP 1 MANHOMHANG from NHOMHANG order by MANHOMHANG desc)
	if @maCuoi is null
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- NhaCungCap ---
create FUNCTION func_TaoMaNhaCungCap()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10),@nextmaNV varchar (10), @maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='NC'
	set @size=10
	set @maCuoi = (select TOP 1 MANHACUNGCAP from NHACUNGCAP order by MANHACUNGCAP desc)
	if @maCuoi is null
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- DONVITINH ---
create FUNCTION func_TaoMaDonViTinh()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10),@nextmaNV varchar (10),@maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='DV'
	set @size=10
	set @maCuoi = (select TOP 1 MADONVITINH from DONVITINH order by MADONVITINH desc)
	if @maCuoi is null
		
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- TUCHUA ---
create FUNCTION func_TaoMaTuChua()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10),@nextmaNV varchar (10), @maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='TC'
	set @size=10
	set @maCuoi = (select TOP 1 MATUCHUA from TUCHUA order by MATUCHUA desc)
	if @maCuoi is null
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- HANGHOA ---
create FUNCTION func_TaoMaHangHoa()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10),@nextmaNV varchar (10),@maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='HH'
	set @size=10
	set @maCuoi = (select TOP 1 MAHANGHOA from HANGHOA order by MAHANGHOA desc)
	if @maCuoi is null
		
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- QUYEN ---
create FUNCTION func_TaoMaQuyen()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10),@maKiTu varchar(2),@size int,@num_nextmaNV int,@tam int
	set @maKiTu='MQ'
	set @size=10
	declare @nextmaNV varchar (10)
	set @maCuoi = (select TOP 1 MAQUYEN from QUYEN order by MAQUYEN desc)
	IF @maCuoi is null
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @tam = LEN(@maKiTu)
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- NHAPHANGHOA ---
create FUNCTION func_TaoMaNhapHangHoa()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10), @nextmaNV varchar (10),@maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='PN'
	set @size=10
	set @maCuoi = (select TOP 1 MANHAPHANGHOA from NHAPHANGHOA order by MANHAPHANGHOA desc)
	if @maCuoi is null
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- KHACHHANG ---
create FUNCTION func_TaoMaKhachHang()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10), @nextmaNV varchar (10), @maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='KH'
	set @size=10
	set @maCuoi = (select TOP 1 MAKH from KHACHHANG order by MAKH desc)
	if @maCuoi is null
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- HOADON ---
create FUNCTION func_TaoMaHoaDon()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10),@nextmaNV varchar (10), @maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='HD'
	set @size=10
	set @maCuoi = (select TOP 1 MAHD from HOADON where MAHD like 'HD%' order by MAHD desc)
	if @maCuoi is null
		
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- DATHANG ---
create FUNCTION func_LayMaDatHang()
returns varchar(10)
as
begin
	declare @ma varchar(10)
	select top 1 @ma = cast(dum.DH as varchar(10)) from (select MADH as DH,1 sortby from DATHANG dh where MADH like 'DH%' union select MAHD as DH,2 sortby from HOADON hd where MAHD like 'DH%') dum order by dum.DH desc 
	return @Ma
end
go
create FUNCTION func_TaoMaDatHang()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10),@nextmaNV varchar (10), @maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='DH'
	set @size=10
	set @maCuoi = dbo.func_LayMaDatHang()
	if @maCuoi is null
		
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
---- BAOCAOHANGTON ---
create FUNCTION func_TaoMaBCHangTon()
returns varchar (10)
as
BEGIN
	declare @maCuoi varchar (10),@nextmaNV varchar (10),@maKiTu varchar(2),@size int,@num_nextmaNV int
	set @maKiTu='BT'
	set @size=10
	set @maCuoi = (select TOP 1 MABAOCAO from BAOCAOHANGTON order by MABAOCAO desc)
	if @maCuoi is null
		set @maCuoi = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @maCuoi = LTRIM(RTRIM(@maCuoi))
		set @num_nextmaNV = REPLACE (@maCuoi , @maKiTu , '')+1
		set @size = @size - LEN(@maKiTu)
		set @nextmaNV = @maKiTu + REPLICATE (0,@size-LEN(@maKiTu))
		set @nextmaNV = @maKiTu + RIGHT (REPLICATE(0,@size) + CONVERT(Varchar(max),@num_nextmaNV),@size) 
		return @nextmaNV
END
GO
----------------------------------------------------
go
--1. Loai Thuoc
create table NHOMHANG
(
	MANHOMHANG CHAR(10) DEFAULT DBO.func_TaoMaNhomHang(),
	TENNHOMHANG NVARCHAR(50) NOT NULL,
	constraint PK_LOAITHUOC_MANHOMHANG primary key (MANHOMHANG)
)
go

--2. Nhà Cung Cấp
create table NHACUNGCAP
(
	MANHACUNGCAP CHAR(10) default dbo.func_TaoMaNhaCungCap(),
	TENNHACUNGCAP NVARCHAR(50) NOT NULL,
	DIACHI NVARCHAR(50) NOT NULL,
	SODIENTHOAI varchar(11) NOT NULL,
	EMAIL VARCHAR(50)	NOT NULL,
	constraint PK_NHACUNGCAP_MANHACUNGCAP PRIMARY KEY (MANHACUNGCAP)

)
GO


--3. Đơn Vị Tính
create table DONVITINH
(
	MADONVITINH CHAR(10) default dbo.func_TaoMaDonViTinh(),
	TENDONVITINH NVARCHAR(30) not null,
	constraint PK_DONVITINH_MADONVITINH primary key (MADONVITINH)
)
go

--4. Tủ Chứa
create table TUCHUA
(
	MATUCHUA CHAR(10) default dbo.func_TaoMaTuChua(),
	TENTUCHUA nvarchar(50) not null,
	constraint PK_TUCHUATHUOC_MATUCHUA primary key (MATUCHUA)
)
go

--5. Hàng Hóa
create table HANGHOA
(
	MAHANGHOA CHAR(10) default dbo.func_TaoMaHangHoa(),
	TENHANGHOA nvarchar(50) not null,
	DONGIANHAP decimal check (DONGIANHAP > 0),
	DONGIABAN decimal check (DONGIABAN > 0),
	MANHOMHANG CHAR(10) NOT NULL,
	MANHACUNGCAP CHAR(10) NOT NULL,
	MADONVITINH CHAR(10) NOT NULL,
	ANHHANGHOA VARCHAR(50),
	SOLUONGTON INT,
	MATUCHUA CHAR(10) NOT NULL,
	constraint PK_THUOC_MAHANGHOA primary key (MAHANGHOA),
	constraint FK_THUOC_MANHOMHANG FOREIGN KEY(MANHOMHANG) REFERENCES NHOMHANG(MANHOMHANG),
	constraint FK_THUOC_MANHACUNGCAP FOREIGN KEY(MANHACUNGCAP) REFERENCES NHACUNGCAP(MANHACUNGCAP),
	constraint FK_THUOC_MADONVITINH FOREIGN KEY(MADONVITINH) REFERENCES DONVITINH(MADONVITINH),
	constraint FK_THUOC_MATUCHUA FOREIGN KEY(MATUCHUA) REFERENCES TUCHUA(MATUCHUA)
)
go

--- 10.Quy Định
create table QUIDINH
(
	MAQUIDINH nvarchar(10),
	TENQUIDINH nvarchar(50) not null,
	constraint PK_QUIDINH_MAQUIDINH primary key (MAQUIDINH),
	
)
GO

--- 11.CHI TIẾT QUI ĐỊNH
create table CTQD
(
	MAHANGHOA CHAR(10),
	MAQUIDINH nvarchar(10),
	SOLUONGQUIDINH INT DEFAULT (0) not null,
	constraint PK_QUIDINH_HANGHOA primary key (MAQUIDINH,MAHANGHOA),
	constraint FK_CTQD_MAHANGHOA foreign key (MAHANGHOA) references HANGHOA(MAHANGHOA),
	constraint FK_CTQD_MAQUIDINH foreign key (MAQUIDINH) references QUIDINH(MAQUIDINH)
)

--.6. Quyền
create table QUYEN
(
	MAQUYEN char(10) default dbo.func_TaoMaQuyen(),
	TENQUYEN nvarchar(30) NOT NULL,
	constraint PK_QUYEN_MAQUYEN primary key (MAQUYEN)
)

--7. Nhân Viên
create table NHANVIEN
(
	MANV CHAR(10) primary key constraint PK_NHANVIEN_MANV DEFAULT DBO.func_TaoMaNV(),
	TENNV nvarchar(50) not null,
	GIOITINH bit NOT NULL,
	NGAYSINH DATE NOT NULL,
	SODIENTHOAI varchar(11) not null,
	EMAIL VARCHAR(50) NOT NULL,
	DIACHI nvarchar(50) not null,
	MAQUYEN CHAR(10) not null,
	ID varchar(30) not null,
	PASS varbinary (256)
	constraint FK_TAIKHOAN_MAQUYEN foreign key (MAQUYEN) references QUYEN (MAQUYEN)
)

go

--8. Nhập Kho 
create table NHAPHANGHOA
(
	MANHAPHANGHOA CHAR(10) default dbo.func_TaoMaNhapHangHoa(),
	MANV CHAR(10) NOT NULL,
	NGAYNHAP Datetime DEFAULT GETDATE(),
	--MAKHO CHAR(10),
	TONGSOTIEN DECIMAL DEFAULT(0),
	TINHTRANG bit DEFAULT(0)
	CONSTRAINT PK_NHAPHANGHOA_MANHAPKHO PRIMARY KEY(MANHAPHANGHOA)
	--constraint FK_NHAPHANGHOA_MAKHO foreign key (MAKHO) references KHO(MAKHO)
)

--9. Chi Tiết Nhập Kho
create table CTNHAPHANGHOA
(
	MANHAPHANGHOA CHAR(10) NOT NULL,
	MAHANGHOA CHAR(10) NOT NULL,
	SOLUONGNHAP INT DEFAULT(0) not null,
	DONGIANHAP int check (DONGIANHAP>0) null,
	THANHTIEN DECIMAL CHECK (THANHTIEN>0)
	constraint PK_CHITIETNHAPKHO_MANHAPKHO_MATHUOC primary key (MANHAPHANGHOA, MAHANGHOA)
	constraint FK_CHITIETNHAPKHO_MANHAPKHO foreign key (MANHAPHANGHOA) references NHAPHANGHOA(MANHAPHANGHOA),
	constraint FK_CHITIETNHAPKHO_MAHANGHOC foreign key (MAHANGHOA) references HANGHOA(MAHANGHOA)
)
go

--10. Khách Hàng
CREATE TABLE KHACHHANG
(
	MAKH CHAR(10) default dbo.func_TaoMaKhachHang(),
	TENKHACHHANG NVarChar(50) NOT NULL,
	GIOITINH bit NOT NULL,
	NGAYSINH DATE NOT NULL,
	DIACHI NVarChar(100) NOT NULL,
	SODIENTHOAI VarChar(11) NOT NULL,
	EMAIL NVarChar(50) NOT NULL,
	CMND VarChar(11) NOT NULL,
	ID varchar(30) NOT NULL,
	PASS varbinary(256) NOT NULL,
	NGAYLAP Datetime DEFAULT GETDATE(),
	CONSTRAINT PK_KHACHHANG PRIMARY KEY (MAKH)
)
GO
--11.  Đặt hàng
create table DATHANG
(
	MADH CHAR(10) default dbo.func_TaoMaDatHang(),
	NGAYLAP Datetime DEFAULT GETDATE(),
	MANV CHAR(10) NULL,
	MAKH CHAR(10) NOT NULL,
	TONGTIEN Decimal(8,0) DEFAULT(0),
	TIENTHANHTOAN Decimal(8,0) DEFAULT(0),
	TIENTHUA Decimal(8,0) DEFAULT(0),
	TRANGTHAI bit DEFAULT(0)
	constraint PK_DATHANG_MADH primary key (MADH),
	constraint FK_DATHANG_MANV foreign key (MANV) references NHANVIEN (MANV),
	constraint FK_DATHANG_MAKH foreign key (MAKH) references KHACHHANG (MAKH)
)
go


--12.  Chi tiết đặt hàng
create table CTDH
(
	MADH CHAR(10) NOT NULL,
	MAHANGHOA CHAR(10) NOT NULL,
	SOLUONG int check (SOLUONG > 0) NOT NULL,
	DONGIA DECIMAL check (DONGIA > 0) NULL,
	THANHTIEN decimal NULL, 
	constraint PK_CTDH_MADH_MATHUOC primary key (MADH, MAHANGHOA),
	constraint FK_CTDH_MADH foreign key (MADH) references DATHANG (MADH),
	constraint FK_CTDH_MAHANGHOA foreign key (MAHANGHOA) references HANGHOA (MAHANGHOA)
)
go


--13. Hóa Đơn
create table HOADON
(
	MAHD CHAR(10) default dbo.func_TaoMaHoaDon(),
	NGAYLAP Datetime DEFAULT GETDATE(),
	MANV CHAR(10) NULL,
	MAKH CHAR(10) NULL,
	TONGTIEN Decimal(8,0) DEFAULT(0),
	TIENTHANHTOAN Decimal(8,0) DEFAULT(0),
	TIENTHUA Decimal(8,0) DEFAULT(0),
	TRANGTHAI bit DEFAULT(0),
	constraint PK_HOADON_MAHD primary key (MAHD),
	constraint FK_HOADON_MANV foreign key (MANV) references NHANVIEN (MANV),
	constraint FK_HOADON_MAKH foreign key (MAKH) references KHACHHANG (MAKH)
)
go


--14.  Chi tiết hóa đơn
create table CTHD
(
	MAHD CHAR(10) NOT NULL,
	MAHANGHOA CHAR(10) NOT NULL,
	SOLUONG int check (SOLUONG > 0) NOT NULL,
	DONGIA DECIMAL check (DONGIA > 0) NULL,
	THANHTIEN decimal NULL, 
	constraint PK_CTHD_MAHD_MATHUOC primary key (MAHD, MAHANGHOA),
	constraint FK_CTHD_MAHD foreign key (MAHD) references HOADON (MAHD),
	constraint FK_CTHD_MAHANGHOA foreign key (MAHANGHOA) references HANGHOA (MAHANGHOA)
)
go



--16. Báo Cáo Thuốc Tồn
create table BAOCAOHANGTON
(
	MABAOCAO CHAR(10) default dbo.func_TaoMaBCHangTon(),
	NGAYLAPBAOCAO Datetime DEFAULT GETDATE(),
	constraint PK_BAOCAOHANGTON_MABAOCAO primary key (MABAOCAO)
)
go

--17. Chi Tiết Báo Cáo Thuốc Tồn
create table CTBAOCAOHANGTON
(
	MABAOCAO CHAR(10) NOT NULL,
	MAHANGHOA CHAR(10) NOT NULL,
	TONDAU int,
	PHATSINH int,
	TONCUOI int, 
	constraint PK_HANGTON primary key (MABAOCAO, MAHANGHOA),
	constraint FK_HANGTON_MABAOCAO foreign key (MABAOCAO) references BAOCAOHANGTON(MABAOCAO),
	constraint FK_HANGTON_MAHANGHOA foreign key (MAHANGHOA) references HANGHOA(MAHANGHOA)
)
go
