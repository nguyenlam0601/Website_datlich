---------------------------------------Doctor---------------------------------------------------------------------------------------------------
--GetAll
alter procedure Get_all_doctor
as
	begin
			select d.id, d.docName, d.phone, d.address,d.birthDay,d.gender,d.email,d.price,d.avatar,d.positionId,d.Description
			from doctor as d
	end
go
exec Get_all_doctor 
go
--GetBookingByDoctorID
create procedure search_booking_byDoctorID
@page_index   INT, 
@page_size    INT, 

@id varchar(8),
@total bigint out
as
begin
   if(@page_size <> 0)
	begin
		select(ROW_NUMBER() over(
                        order by b.dateBooking asc)) as RowNumber, 
                       b.dateBooking,
					   t.timeValue,
					   c.cusName,
					   c.gender,
					   c.address,
					   c.birthDay,
					   c.email,
					   c.phone,
					   d.docName,
					   b.status,
					   b.id
			    INTO Results2
                from booking as b 
				join doctor as d on b.doctorId=d.id 
				join customer c on b.customerId=c.id
				join time t on b.timeId=t.id
				where b.status=2 and doctorId=@id
				SELECT @total = COUNT(*)
                FROM Results2;
				select * ,@total as RecordCount
				from Results2
				WHERE ROWNUMBER BETWEEN ((@page_index - 1) * @page_size) + 1 AND(@page_index*@page_size)
			    DROP TABLE Results2;
	end		
	else
	begin
		select(ROW_NUMBER() over(
                         order by b.dateBooking asc)) as RowNumber, 
                       b.dateBooking,
					   t.timeValue,
					   c.cusName,
					   c.gender,
					   c.address,
					   c.birthDay,
					   c.email,
					   c.phone,
					   d.docName,
					   b.status,
					   b.id
			    INTO Results3
                from booking as b 
				join doctor as d on b.doctorId=d.id 
				join customer c on b.customerId=c.id
				join time t on b.timeId=t.id
				where b.status=2 and doctorId=@id
				SELECT @total = COUNT(*)
                FROM Results3;
				select * ,@total as RecordCount
				from Results3
				
			    DROP TABLE Results3;
	end			
end

---GetDoctorByID
alter procedure Get_doctor_ID
@id varchar(8)
as
	begin
	
			select d.id, d.docName, d.phone, d.address,d.birthDay,d.gender,d.email,d.price,d.avatar,d.positionId,d.Description
			from doctor as d
			where d.id= @id
		
	end
go
--Create doctor
alter procedure Create_doctor
@id varchar(8),
@name nvarchar(50),
@phone varchar(10),
@address nvarchar(255),
@birthday date,
@gender bit,
@email varchar(255),
@price float,
@avatar varchar(500),
@positionid char(5),
@description nvarchar(max)
as
	begin
	
			insert into doctor(id,docName,phone,address,birthDay,gender,email,price,avatar,positionId,Description)
			values(@id,@name,@phone,@address,@birthday,@gender,@email,@price,@avatar,@positionid,@description)
	
	end
go
--update doctor
alter procedure Update_doctor
@id varchar(8),
@name nvarchar(50),
@phone varchar(10),
@address nvarchar(255),
@birthday date,
@gender bit,
@email varchar(255),
@price float,
@avatar varchar(500),
@positionid char(5),
@description nvarchar(max)
as
	begin
			update doctor
			set
			docName=@name,
			phone=@phone,
			address=@address,
			birthDay=@birthday,
			gender=@gender,
			email=@email,
			price=@price,
			avatar=@avatar,
			positionId=@positionid,
			Description=@description
			where id=@id

	end
go
--Delete doctor
alter procedure Delete_doctor
@id varchar(8)
as
	begin
			delete from doctor 
			where id=@id
	end
go
-------------------------------------------------------Staff----------------------------------------------------------------------------
--Get staff
alter procedure Get_all_staff
as
	begin
		
			select s.id,s.staffName,s.phone,s.address,s.position,s.gender,s.birthDay
			from staff as s
	end
go
--GetStaffID
alter procedure Get_staff_ID
@id varchar(8)
as
	begin

			select s.id,s.staffName,s.phone,s.address,s.position,s.gender,s.birthDay,s.email,t.loaiQuyen
			from staff as s join TaiKhoan as t on s.id=t.id_user
			where s.id=@id
	end
go
--Create staff
alter procedure Create_staff

@name nvarchar(50),
@phone varchar(10),
@address nvarchar(255),
@birthday date,
@gender bit,
@position nvarchar(50),
@email varchar(255),
@loaiQuyen varchar(10)
as
	begin
	declare @role int;
	if(@loaiQuyen='Admin')
	set @role = 1
	if(@loaiQuyen='User')
	set @role = 2
			insert into staff(staffName,phone,address,position,gender,birthDay,email)
			values(@name,@phone,@address,@position,@gender,@birthday,@email)
			declare @id int;
			set @id = (select id from staff where staffName=@name and phone=@phone and address=@address and position=@position and gender=@gender and birthDay=@birthDay);
			insert into TaiKhoan(id_user,userName,passWord,loaiQuyen)
			values(@id,@email,123,@role)
	end

go
exec  Create_staff N'Test','0987654234',N'Hưng Yên','2-2-2000',1,N'Nhân viên','test@gmail.com','User'
--update staff
alter procedure Update_staff
@id varchar(8),
@name nvarchar(50),
@phone varchar(10),
@address nvarchar(255),
@birthday date,
@gender bit,
@position nvarchar(50),
@email varchar(255),
@loaiQuyen varchar(10)
as
	begin
			update staff
			set
			staffName=@name,
			phone=@phone,
			address=@address,
			position=@position,
			gender=@gender,
			birthDay=@birthday,
			email=@email
			where id=@id
			declare @role int;
				if(@loaiQuyen='Admin')
				set @role = 1
				if(@loaiQuyen='User')
				set @role = 2
			update TaiKhoan
			set loaiQuyen=@role
			where id_user=@id

	end
go
--Delete staff
alter procedure Delete_staff
@id varchar(8)
as
	begin
			delete from staff 
			where id=@id

	end
go
---search staff
-----------------------------------SCHEDULE----------------------------------------------------

select d.docName,t.timeValue,s.currentNumber
from schedule as s join time as t on s.timeId=t.id join doctor as d on s.doctorId=d.id

------------------------------------BOKING-----------------------------------------------------
---create booking
alter procedure Create_booking

@doctorId varchar(8),
@customerId int,
@datebooking date,
@timeId char(5)
as
	begin
			insert into booking(doctorId,customerId,dateBooking,timeId)
			values(@doctorId,@customerId,@datebooking,@timeId)
	end
go
 exec Create_booking 'BS01',1,'2022-12-18','T5'
 go
---update booking status=2
alter procedure update_booking_confirm
@id int
as
	begin
	declare @doctorId varchar(8), @timeId char(5), @dateBooking date
			update booking
			set
			status=2
			where id=@id 
			set @doctorId =(select b.doctorId from booking as b where id=@id)
			set @timeId = (select b.timeId from booking as b where id=@id)
			set @dateBooking = (select b.dateBooking from booking as b where id=@id)
			update schedule
			set
			status=0
			where doctorId=@doctorId and timeId=@timeId and currentNumber=@dateBooking
	end
go
exec update_booking_confirm 3
go
-------------------------------
create procedure update_booking_done
@id int
as
	begin
	
			update booking
			set
			status=3
			where id=@id 
	end
go
exec update_booking_done 3
go
go
--------------------
alter procedure update_booking_cancel
@id int
as
	begin
	declare @doctorId varchar(8), @timeId char(5), @dateBooking date
			update booking
			set
			status=4
			where id=@id 
			set @doctorId =(select b.doctorId from booking as b where id=@id)
			set @timeId = (select b.timeId from booking as b where id=@id)
			set @dateBooking = (select b.dateBooking from booking as b where id=@id)
			update schedule
			set
			status=1
			where doctorId=@doctorId and timeId=@timeId and currentNumber=@dateBooking
	end
go
exec update_booking_cancel 3
go

--Lấy lịch hẹn theo status



	exec search_booking_new 0,0,0
go
----------------------
alter procedure search_booking_confirm
@page_index   INT, 
@page_size    INT, 
@total bigint out
as
begin
   if(@page_size <> 0)
	begin
		select(ROW_NUMBER() over(
                        order by b.dateBooking asc)) as RowNumber, 
                       b.dateBooking,
					   t.timeValue,
					   c.cusName,
					   c.gender,
					   c.address,
					   c.birthDay,
					   c.email,
					   c.phone,
					   d.docName,
					   b.status,
					   b.id
			    INTO Results2
                from booking as b 
				join doctor as d on b.doctorId=d.id 
				join customer c on b.customerId=c.id
				join time t on b.timeId=t.id
				where b.status=2 
				SELECT @total = COUNT(*)
                FROM Results2;
				select * ,@total as RecordCount
				from Results2
				WHERE ROWNUMBER BETWEEN ((@page_index - 1) * @page_size) + 1 AND(@page_index*@page_size)
			    DROP TABLE Results2;
	end		
	else
	begin
		select(ROW_NUMBER() over(
                         order by b.dateBooking asc)) as RowNumber, 
                       b.dateBooking,
					   t.timeValue,
					   c.cusName,
					   c.gender,
					   c.address,
					   c.birthDay,
					   c.email,
					   c.phone,
					   d.docName,
					   b.status,
					   b.id
			    INTO Results3
                from booking as b 
				join doctor as d on b.doctorId=d.id 
				join customer c on b.customerId=c.id
				join time t on b.timeId=t.id
				where b.status=2 
				SELECT @total = COUNT(*)
                FROM Results3;
				select * ,@total as RecordCount
				from Results3
				
			    DROP TABLE Results3;
	end			
end

	exec search_booking_confirm 0,0,'',0
go
-----------------------------------------------
alter procedure search_booking_done
@page_index   INT, 
@page_size    INT, 
@total bigint out
as
begin
   if(@page_size <> 0)
	begin
		select(ROW_NUMBER() over(
                        order by b.dateBooking asc)) as RowNumber, 
                       b.dateBooking,
					   t.timeValue,
					   c.cusName,
					   c.gender,
					   c.address,
					   c.birthDay,
					   c.email,
					   c.phone,
					   d.docName,
					   b.id,
					   b.status
			    INTO Results2
                from booking as b 
				join doctor as d on b.doctorId=d.id 
				join customer c on b.customerId=c.id
				join time t on b.timeId=t.id
				where b.status=3 
				SELECT @total = COUNT(*)
                FROM Results2;
				select * ,@total as RecordCount
				from Results2
				WHERE ROWNUMBER BETWEEN ((@page_index - 1) * @page_size) + 1 AND(@page_index*@page_size)
			    DROP TABLE Results2;
	end		
	else
	begin
		select(ROW_NUMBER() over(
                         order by b.dateBooking asc)) as RowNumber, 
                       b.dateBooking,
					   t.timeValue,
					   c.cusName,
					   c.gender,
					   c.address,
					   c.birthDay,
					   c.email,
					   c.phone,
					   d.docName,
					    b.id,
					   b.status
			    INTO Results3
                from booking as b 
				join doctor as d on b.doctorId=d.id 
				join customer c on b.customerId=c.id
				join time t on b.timeId=t.id
				where b.status=3 
				SELECT @total = COUNT(*)
                FROM Results3;
				select * ,@total as RecordCount
				from Results3
				
			    DROP TABLE Results3;
	end			
end

	exec search_booking_done 0,0,'',0
go
------------------------------------
alter procedure search_booking_cancel
@page_index   INT, 
@page_size    INT, 
@total bigint out
as
begin
   if(@page_size <> 0)
	begin
		select(ROW_NUMBER() over(
                        order by b.dateBooking asc)) as RowNumber, 
                       b.dateBooking,
					   t.timeValue,
					   c.cusName,
					   c.gender,
					   c.address,
					   c.birthDay,
					   c.email,
					   c.phone,
					   d.docName,
					    b.id,
					   b.status
			    INTO Results2
                from booking as b 
				join doctor as d on b.doctorId=d.id 
				join customer c on b.customerId=c.id
				join time t on b.timeId=t.id
				where b.status=4 
				SELECT @total = COUNT(*)
                FROM Results2;
				select * ,@total as RecordCount
				from Results2
				WHERE ROWNUMBER BETWEEN ((@page_index - 1) * @page_size) + 1 AND(@page_index*@page_size)
			    DROP TABLE Results2;
	end		
	else
	begin
		select(ROW_NUMBER() over(
                         order by b.dateBooking asc)) as RowNumber, 
                       b.dateBooking,
					   t.timeValue,
					   c.cusName,
					   c.gender,
					   c.address,
					   c.birthDay,
					   c.email,
					   c.phone,
					   d.docName,
					    b.id,
					   b.status
			    INTO Results3
                from booking as b 
				join doctor as d on b.doctorId=d.id 
				join customer c on b.customerId=c.id
				join time t on b.timeId=t.id
				where b.status=4 
				SELECT @total = COUNT(*)
                FROM Results3;
				select * ,@total as RecordCount
				from Results3
				
			    DROP TABLE Results3;
	end			
end

	exec search_booking_cancel 0,0,'',0
go
-------------------------------------------------SCHEDULE------------------------------------------------------
alter procedure search_schedule
@page_index   INT, 
@page_size    INT, 
@doctorID varchar(8),
@currentNumber varchar(20),
@total bigint out
as
begin
	declare @date date
	set @date = convert(date,@currentNumber)
   if(@page_size <> 0)
	begin
		select(ROW_NUMBER() over(
                        order by s.id asc)) as RowNumber, 
					   s.id,
					   t.timeValue,
					   s.currentNumber,
					   s.timeId
			    INTO Results2
                from schedule as s 
				join doctor as d on s.doctorId=d.id 
				join time t on s.timeId=t.id
				where s.doctorId=@doctorID and  year(s.currentNumber) = year(@date)and  month(s.currentNumber) = month(@date) and  day(s.currentNumber) = day(@date)
				and status=1
				SELECT @total = COUNT(*)
                FROM Results2;
				select * ,@total as RecordCount
				from Results2
				WHERE ROWNUMBER BETWEEN ((@page_index - 1) * @page_size) + 1 AND(@page_index*@page_size)
			    DROP TABLE Results2;
	end		
	else
	begin
		select(ROW_NUMBER() over(
                        order by s.id asc)) as RowNumber, 
					   s.id,
					   t.timeValue,
					   s.currentNumber,
					   s.timeId
			    INTO Results3
                from schedule as s 
				join doctor as d on s.doctorId=d.id 
				join time t on s.timeId=t.id
				where s.doctorId=@doctorID and  year(s.currentNumber) = year(@date)and  month(s.currentNumber) = month(@date) and  day(s.currentNumber) = day(@date)
				and status =1
				SELECT @total = COUNT(*)
                FROM Results3;
				select * ,@total as RecordCount
				from Results3
				
			    DROP TABLE Results3;
	end			
end
exec search_schedule 0,0,'BS01','2023-2-6',0
go
---GetDaySchedule
create procedure Get_schedule_ID
@id int
as
	begin
	
			select s.id,s.currentNumber,s.timeId
			from schedule as s
			where s.id= @id
		
	end
	exec Get_schedule_ID 1
go
-------------------------------------Appointment-------------------------------------
alter procedure Create_appointment
@cusName nvarchar(50),
@phone varchar(10),
@address nvarchar(255),
@birthDay date,
@gender bit,
@email varchar(50),
@doctorId varchar(8),
@dateBooking date,
@timeId char(5)
as
	begin
			insert into customer(cusName,phone,address,email,gender,birthDay)
			values(@cusName,@phone,@address,@email,@gender,@birthDay)
			--select id from customer where cusName=@cusName and phone=@phone and address=@address and email=@email and gender=@gender and birthDay=@birthDay;
			declare @id int;
			set @id = (select id from customer where cusName=@cusName and phone=@phone and address=@address and email=@email and gender=@gender and birthDay=@birthDay);
			insert into booking(doctorId,customerId,dateBooking,timeId)
			values(@doctorId,@id,@dateBooking,@timeId)
			
	end
go
exec Create_appointment N'lâm','0947828482','Hưng Yên','2-2-2002',1,'lam@gmail.com','BS01','2-1-2022','T1'
go
---------------------------Time--------------------------------------------------------------------------------
create procedure Get_time_ID
@id varchar(5)
as
	begin
	
			select t.id,t.timeValue
			from time as t
			where t.id= @id
		
	end
go
-------------------------TaiKhoan--------------------
alter procedure Get_Taikhoan
@userName varchar(50),
@passWord varchar(25)
as
	begin
		select t.id_user,t.userName,t.passWord,t.status, s.staffName,s.phone,s.address,s.position,s.gender,s.birthDay,t.loaiQuyen,s.email
		from TaiKhoan as t join staff as s on t.id_user=s.id
		where t.userName=@userName and t.passWord=@passWord
	end
go
exec Get_Taikhoan 'nv01','123'