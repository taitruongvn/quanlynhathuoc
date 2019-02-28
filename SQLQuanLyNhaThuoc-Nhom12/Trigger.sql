use QuanLyNhaThuoc
go

--------------- CTHD -----------------------
--Trg Kiểm Tra Số Lượng Tồn Hóa Đơn
create trigger trg_KiemTraSoLuongTonHD
on CTHD
for insert,update
as
	begin
	declare @mahh varchar(10),@soluongdat int
	select  @mahh = mahanghoa,@soluongdat=SOLUONG from inserted
	if(@soluongdat>(select SOLUONGTON from HANGHOA where MAHANGHOA= @mahh))
			begin
				raiserror('Tạm hết hàng',16,1)
				rollback tran
			end	
	end
go

--Trg Kiểm Tra Hóa Đơn Xác Nhận Thì Không Được Xóa
create trigger trg_KiemTraHoaDonXacNhanThiKhongDuocXoa
on CTHD
for insert,update, delete
as
	begin
	declare @mahd varchar(10)
	select  @mahd = MAHD from inserted
	if exists (select MaHd from HOADON where (MAHD = @mahd and TRANGTHAI=1 and MAHD like 'HD%') or (MAHD = @mahd and TRANGTHAI=1 and MAHD like 'DH%'))
			begin
				raiserror('Không được phép chỉnh',16,1)
				rollback tran
			end

	declare @mahd2 varchar(10)
	select  @mahd2 = MAHD from deleted
	if exists (select MAHD from HOADON where (MAHD = @mahd2 and TRANGTHAI=1 and MAHD like 'HD%') or (MAHD = @mahd2 and TRANGTHAI=1 and MAHD like 'DH%'))
			begin
				raiserror('Không được phép chỉnh',16,1)
				rollback tran
			end
	end
go

--Trg Tự Động Trừ Hàng Tồn Và Tình Tổng Tiền Hóa Đơn
create trigger trg_TuDongTruHangTonvaTinhTongTienHoaDon
on CTHD
for insert
as
	begin
	declare @mahd varchar(10),@mahh varchar(10),@dongiaban int,@soluongdat int
	select @mahd = MAHD, @mahh = mahanghoa, @dongiaban=DONGIA,@soluongdat=SOLUONG from inserted
	select @dongiaban = dongiaban from HANGHOA where MAHANGHOA = @mahh
	if exists (select MaHd from HOADON where MAHD = @mahd and MAHD like 'HD%')
	begin
	update CTHD set DONGIA = @dongiaban, THANHTIEN = @dongiaban*SOLUONG where MAHD=@mahd and MAHANGHOA=@mahh
	update HOADON set TONGTIEN = (select SUM(THANHTIEN) from CTHD where MAHD = @mahd) where MAHD =@mahd
	update HANGHOA set SOLUONGTON = SOLUONGTON - @soluongdat where MAHANGHOA = @mahh
	end
	end
go


------------ CTDH -----------------------
--Trg Kiểm Tra Số Lượng Đặt Hàng
create trigger trg_KiemTraSoLuongTonDH
on CTDH
for insert,update
as
	begin
	declare @mahh varchar(10),@soluongdat int
	select  @mahh = mahanghoa,@soluongdat=SOLUONG from inserted
	if(@soluongdat>(select SOLUONGTON from HANGHOA where MAHANGHOA= @mahh))
			begin
				raiserror('Tạm hết hàng',16,1)
				rollback tran
			end	
	end
go

--Trg Kiểm Tra Số Lượng Đặt Tối Đa
create trigger trg_KiemTraSoLuongDatToiDa
on CTDH
for insert,update
as
	begin
	declare @mahh varchar(10),@soluongdat int
	select  @mahh = mahanghoa,@soluongdat=SOLUONG from inserted
	if(@soluongdat>50)
			begin
			raiserror('Số lượng đặt tối đa 50',16,1)
			rollback tran
			end	
	end
go

--Trg Kiểm Tra Số Lượng Đặt Tối Đa Của Đơn Đặt
create trigger trg_KiemTraSoLuongDatToiDaCuaDonDat
on CTDH
for insert,update
as
	begin
	declare @madh varchar(10)
	select @madh=MADH from inserted
	if((select count(*) from CTDH where MADH=@madh)>10)
		begin
			raiserror('Chỉ Đặt tối đa 10 mặt hàng',16,1)
			rollback tran 
		end
	end
go

--Trg Tự Động Trừ Hàng và Tính Tổng Tiền Đặt Hàng
create trigger trg_TuDongTruHangTonvaTinhTongTienDatHang
on CTDH
for insert
as
	begin
	declare @madh varchar(10),@mahh varchar(10),@dongiaban int,@soluongdat int
	select @madh = MADH, @mahh = mahanghoa, @dongiaban=DONGIA,@soluongdat=SOLUONG from inserted
	select @dongiaban = dongiaban from HANGHOA where MAHANGHOA = @mahh
	update CTDH set DONGIA = @dongiaban, THANHTIEN = @dongiaban*SOLUONG where MADH=@madh and MAHANGHOA=@mahh
	update DATHANG set TONGTIEN = (select SUM(THANHTIEN) from CTDH where MADH = @madh) where MADH=@madh
	update HANGHOA set SOLUONGTON = SOLUONGTON - @soluongdat where MAHANGHOA = @mahh
	end
go

------- DATHANG ----------
--Trg Tự Động Kiểm Tra Xóa Phù Hợp
create trigger trg_TuDongKiemTraXoaPhuHop
on DATHANG
instead of delete
as
	begin
	  declare @trangthai bit,@madh varchar(10),@ngaylap datetime, @manv varchar(10),@makh varchar(10),@tongtien decimal(8,0),@tienthanhtoan decimal(8,0), @tienthua decimal(8,0)
	  declare  @mahh varchar(10),@soluong int,@dongia int, @thanhtien int
	  select @trangthai =TRANGTHAI,@madh=MADH,@ngaylap=NGAYLAP,@manv=MANV,@makh=MAKH,@tongtien=TONGTIEN,@tienthanhtoan=TIENTHANHTOAN,@tienthua=TIENTHUA from deleted d
	  if (@trangthai =0)
	  begin
		DECLARE cur_CTDH cursor for (select MAHANGHOA,SOLUONG from CTDH where MADH = @madh)
		open cur_CTDH
		fetch next from cur_CTDH into @mahh,@soluong
		while @@FETCH_STATUS=0
		begin
			update HANGHOA set SOLUONGTON=SOLUONGTON+@soluong
		end
		CLOSE cur_CTDH
		DEALLOCATE cur_CTDH
		delete CTDH where MADH=@madh
		delete DATHANG where MADH=@madh
	  end
	  else
	  SET XACT_ABORT ON
	  begin tran
	  	insert into HOADON(MAHD,NGAYLAP,MANV,MAKH,TONGTIEN,TIENTHANHTOAN,TIENTHUA,TRANGTHAI)
		values(@madh,@ngaylap,@manv,@makh,@tongtien,@tienthanhtoan,@tienthua,@trangthai)

		update HOADON
		set TRANGTHAI = 0
		where MAHD = @madh

		DECLARE cur_CTDH cursor for (select MAHANGHOA,SOLUONG,DONGIA,THANHTIEN from CTDH where MADH = @madh)
		open cur_CTDH
		fetch next from cur_CTDH into @mahh,@soluong,@dongia,@thanhtien
		while @@FETCH_STATUS=0
		begin
			insert into CTHD(MAHD,MAHANGHOA,SOLUONG,DONGIA,THANHTIEN) 
			values (@madh,@mahh,@soluong,@dongia,@thanhtien)
			fetch next from cur_CTDH into @mahh,@soluong,@dongia,@thanhtien
		end
		CLOSE cur_CTDH
		DEALLOCATE cur_CTDH
		delete CTDH where MADH=@madh
		delete DATHANG where MADH=@madh

		update HOADON
		set TRANGTHAI = 1
		where MAHD = @madh
	  end
	commit
go

------------------QUYEN ---------------------
--Trg Check Tên Quyền
create trigger trg_CheckTen_QUYEN
on QUYEN
for insert,update
as
begin
		if UPDATE(TENQUYEN)
		begin
			if exists (select * from QUYEN, inserted where QUYEN.TENQUYEN = inserted.TENQUYEN and QUYEN.MAQUYEN <> inserted.MAQUYEN )
			begin
				raiserror(N'Tên quyền bị trùng',16,1)
				rollback tran
				return
			end
		end
end
go

------------------TU CHUA---------------------
--Trg Check Tên Tủ Chứa
create trigger trg_CheckTen_TuChua
on TUCHUA
for insert,update
as
begin
		if UPDATE(TENTUCHUA)
		begin
			if exists (select * from TUCHUA, inserted where TUCHUA.TENTUCHUA = inserted.TENTUCHUA and TUCHUA.MATUCHUA <> inserted.MATUCHUA )
			begin
				raiserror(N'Tên tủ chứa bị trùng',16,1)
				rollback tran
				return
			end
		end
end
go

------------------CTNHAPHANGHOA ---------------------
--Trg Kiểm Tra Số Lượng Nhập
create trigger trg_KiemTraSoLuongNhap
on CTNHAPHANGHOA
for insert
as
	begin
		declare @soluongnhap int
		select @soluongnhap=SOLUONGNHAP from inserted
		if(@soluongnhap<100)
		begin
				raiserror(N'Số Lượng Nhập Tối Thiểu 100',16,1)
				rollback tran
				return
		end
	end
go

--Trg Kiểm Tra Nhập Hàng Tồn
create trigger trg_KiemTraNhapHangTon
on CTNHAPHANGHOA
for insert
as
	begin
		declare @soluongton int,@mahh varchar(10)
		select @mahh=MAHANGHOA from inserted
		select @soluongton=SOLUONGTON from HANGHOA where MAHANGHOA=@mahh
		if(@soluongton>50)
		begin
				raiserror(N'Hàng Tồn Còn Không Được Phép Nhập Thêm',16,1)
				rollback tran
				return
		end
	end
go

--Trg Tự Động Tăng Số Lượng Tồn
create trigger trg_TuDongTangSoLuongTon
on CTNHAPHANGHOA
for insert
as
	begin
		declare @manhap varchar(10),@mahh varchar(10), @soluongnhap int,@dongianhap int
		select @manhap = MANHAPHANGHOA,@mahh = MAHANGHOA,@soluongnhap = SOLUONGNHAP from inserted i
		select @dongianhap = DONGIANHAP from HANGHOA where MAHANGHOA = @mahh
		Update CTNHAPHANGHOA set THANHTIEN = @dongianhap*SOLUONGNHAP,DONGIANHAP=@dongianhap where MAHANGHOA=@mahh and MANHAPHANGHOA =@manhap
		Update NHAPHANGHOA set TONGSOTIEN=(Select SUM(THANHTIEN) from CTNHAPHANGHOA where MANHAPHANGHOA=@manhap)
		Update HANGHOA set SOLUONGTON=SOLUONGTON+@soluongnhap where MAHANGHOA=@mahh
	end
go

------------------- HOA DON -------------------
--Trg Tự Động Tính Tiền Thừa
create trigger trg_TuDongTinhTienThua
on HOADON
for update
as
	begin
	 declare @mahd varchar(10),@tongtien decimal(8,0),@tienthanhtoan decimal(8,0),@trangthai bit,@tienthua decimal(8,0),@makh varchar(10)
	 select @mahd=MAHD,@tongtien=TONGTIEN,@tienthanhtoan=TIENTHANHTOAN,@tienthua=TIENTHUA,@makh = MAKH from inserted i

	if update(TIENTHANHTOAN) or update(TONGTIEN)
	begin
	  update HOADON set TIENTHUA=@tienthanhtoan-@tongtien where MAHD=@mahd
	end
	end
go

------------------- SANPHAM-------------------
--Trg Tự Động Thêm Hàng Hóa Bán Tại Quầy
create trigger trg_TuDongThemHangHoaBanTaiQuay
on HANGHOA
for insert
as
	begin
	 declare @mahh nvarchar(10)
	 select @mahh = MAHANGHOA from inserted i
	 insert into CTQD values(@mahh,'A',0)
	end
go

--Trg Kiểm Tra Hàng Có Được Bán Online Không
create trigger trg_KiemTraHangHoaCoDuocBanOnlKhong
on CTDH
for insert, update
as
	begin
	declare @mahh varchar(10)
	select  @mahh = mahanghoa from inserted
	if not exists(select MaHANGHOA from CTQD where MAHANGHOA= @mahh and MAQUIDINH='B')
			begin
				raiserror('Món hàng không được phép đặt Online',16,1)
				rollback tran
			end	
	end
go
--Trg Kiểm Tra Số Lượng Giới Hạn
create trigger trg_KiemTraSoLuongGioiHan
on CTDH
for insert,update
as
	begin
	declare @mahh varchar(10),@soluongdat int
	select  @mahh = mahanghoa,@soluongdat=SOLUONG from inserted
	if exists(select MaHANGHOA from CTQD where MAHANGHOA= @mahh and MAQUIDINH='B')
		begin
			declare @slgioihan int
			select @slgioihan = SOLUONGQUIDINH from CTQD where MAHANGHOA= @mahh and MAQUIDINH='B'
			if(@slgioihan<>0)
			begin
			if(@soluongdat>@slgioihan)
			begin
				raiserror('Đặt quá số lượng giới hạn',16,1)
				rollback tran
			end	
			end
		end	
	end
go

--Trg Kiểm Tra Tuổi Khách Hàng
create trigger trg_KiemTuoiKhachHang
on KHACHHANG
for insert,update
as
	begin
	declare @makh varchar(10),@tuoi datetime
	select  @makh = MAKH,@tuoi=NGAYSINH from inserted
	if (datediff(year,@tuoi,getdate())<18)
		begin
				raiserror('Khách Hàng Phải Trên 18 Tuổi',16,1)
				rollback tran
			end
	end
go

--Trg Kiểm Tra ID Trùng
create trigger trg_KiemTraIDTrung
on KHACHHANG
for insert, update
as
	declare @ID varchar(30)
	select @ID = ID from inserted
	if ((select count (*) from KHACHHANG where ID = @ID)>1)
		begin
				raiserror('ID Đã Bị Trùng',16,1)
				rollback tran
			end