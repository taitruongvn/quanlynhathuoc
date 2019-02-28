--T2
begin tran
	update HANGHOA set MANHACUNGCAP ='NCC0000001'
	where MAHANGHOA = 'HH00000001'

	waitfor delay '00:00:10'
	update NHACUNGCAP  set TENNHACUNGCAP = 'Test Deadlock'
	where MANHACUNGCAP = 'NCC0000001'
rollback tran