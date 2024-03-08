create database Warehouse

use Warehouse

-- drop database Warehouse
create table [Types](
Id int primary key identity,
[Name] nvarchar(100) not null check ([Name] <> '')
)
create table Producers(
Id int primary key identity,
[Name] nvarchar(100) not null check ([Name] <> '')
)
create table Products(
Id int primary key identity,
[Name] nvarchar(100) not null check ([Name] <> ''),
TypeId int references [Types](Id),
ProducerId int references Producers(Id),
Quantity int not null check(Quantity > 0),
CostPrice money not null check(CostPrice > 0),
Price money not null check(Price > 0),
DeliveryDate date not null default(GETDATE())
)

insert into [Types] values
					('Accesourses'),
					('Car Parts'),
					('Food'),
					('Clothes'),
					('Sport');
insert into Producers values
					('Wildberries'),
					('VAG'),
					('Nasha Ryaba'),
					('Nike'),
					('Adidass')
insert into Products values
					('Circle', 1,1,5,100,300,'2024-03-06'),
					('Engine', 2,2,6,40000,60000,'2024-02-06'),
					('Chicken', 3,3,50,50,150,'2024-03-07'),
					('Snickers', 4,4,10,600,1800,'2024-01-06'),
					('Ball', 5,5,5,100,400,'2023-12-06'),
					('Ball', 5,4,10,100,500,'2023-1-06'),
					('Snickers', 4,5,10,700,1900,'2023-11-06');

select* from [Types]

select* from Producers

select* from Products