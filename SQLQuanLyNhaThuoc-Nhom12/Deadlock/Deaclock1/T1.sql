--T1
begin tran
	update NHACUNGCAP  set TENNHACUNGCAP = 'Test Deadlock'
	where MANHACUNGCAP = 'NCC0000001'

	waitfor delay '00:00:10'
	update HANGHOA set MANHACUNGCAP ='NCC0000001'
	where MAHANGHOA = 'HH00000001'
rollback tran