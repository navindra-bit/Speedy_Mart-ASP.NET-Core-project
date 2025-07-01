create database SpeedyMartDB

use SpeedyMartDB

create table  UserInfo  ( UserId INT identity(1,1) Primary Key,
FullName nvarchar(100) not null ,
Email nvarchar(100) unique not null ,
Password nvarchar(100) not null,
Gender Nvarchar(10) ,
DateOfBirth Date ,
PhoneNumber Bigint  ,
ProfileImage Nvarchar(300),
CreatedAt datetime default getdate())

 
select * from UserInfo

drop table Userinfo