create database Booking
go
use Booking
go

--Table user
create table login(
id int identity(1,1) primary key,
email varchar(50),
password varchar(50),
firstName nvarchar(50),
lastName nvarchar(50),
roleId char(5)
)
go
create table role(
id char(5) primary key,
roleName nvarchar(50),
)
go
create table customer(
id int identity(1,1) primary key,
cusName nvarchar(50),
phone varchar(10),
address nvarchar(255),
birthDay date,
gender bit,
email varchar(50)
)
go
create table doctor(
id varchar(8) primary key,
docName nvarchar(50),
phone varchar(10),
address nvarchar(255),
birthDay date,
gender bit,
email varchar(255),
price float,
avatar varchar(500),
positionId char(5),
Description text
)
go
create table service(
id char(5) primary key,
serviceName nvarchar(255),
price float,
description text,
)
go
create table position(
id char(5) primary key,
positionName nvarchar(255)
)
go
create table schedule(
id int identity(1,1) primary key,
currentNumber date,
maxNumber date,
timeId char(5),
doctorId varchar(8)
)
alter table schedule
add status int default 1 
go
create table time(
id char(5) primary key,
timeValue varchar(50),
)
go
create table booking(
id int identity primary key,
doctorId varchar(8),
customerId int,
dateBooking date,
timeId char(5),
status int DEFAULT 1
)

go
create table staff(
id int identity(1,1) primary key,
staffName varchar(50),
phone varchar(10),
address nvarchar(255),
position nvarchar(50),
gender bit,
birthDay date
)

create table TaiKhoan(
id int identity(1,1) primary key,
id_user varchar(8),
userName varchar(50),
passWord varchar(25),
status bit DEFAULT 1
)
alter table TaiKhoan
add loaiQuyen int