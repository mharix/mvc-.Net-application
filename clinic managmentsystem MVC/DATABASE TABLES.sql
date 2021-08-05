
use master
go
drop database harispharmacy
go
create database harispharmacy
go 
use harispharmacy
go
drop table tbl_products
go
create table tbl_products(
pid int  primary key identity,
pname varchar(100),
ptype varchar(100) ,
price int,
cost int,
pcode varchar(15),
pweight int,
pdescription varchar(300),
pimage varchar(300)
);
go
drop table tbl_feedback
go
create table tbl_feedback(
id int  primary key identity,
name varchar(50),
phone varchar(11),
email varchar(50),
comments varchar(200),
status varchar(15)
);
go

 
drop table tbl_clientLogin
go
create table tbl_clientLogin(
cid int  primary key identity,
name varchar(50),
phone varchar(11),
email varchar(50),
caddress varchar(200),
);

go
 drop table tbl_inventory;
go
create table tbl_inventory(
id int  primary key identity,
pid int REFERENCES tbl_products(pid),
quantity int,
idate DATETIME,
);
go 
drop table tbl_orders
go
create table tbl_orders(
id int  primary key identity,
pid int REFERENCES tbl_products(pid),
inventoryid int references tbl_inventory(id),
quantity int,
cid int REFERENCES tbl_clientLogin(cid),
orderdate DATETIME NOT NULL DEFAULT(GETDATE()),
status varchar(15)
);

GO
DROP TABLE tbl_cart
go
 create table tbl_cart(
id int  primary key identity,
inventoryid int   REFERENCES tbl_inventory(id),
quantity int
 );
  