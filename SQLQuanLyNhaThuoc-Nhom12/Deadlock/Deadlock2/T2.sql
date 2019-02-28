--T2
begin tran
	exec sp_SuaKhachHang 'KH00000001','Trương Thanh Tài Hai Hai',1,'1996-12-12','Tan Binh','0949496952','tai2@gmail.com','123456789'

	waitfor delay '00:00:05'
	exec sp_ThemDatHang '','KH00000001'
rollback tran