create database MyDBF

go 

use MyDBF

create table Response_person
(
	id int primary key identity(1,1),
	person_name varchar(max) not null,
	lasname varchar(max) not null,
	surname varchar(max) not null,
	brthdate datetime not null,
	post varchar(max) not null,
)

create table Type_of_equip
(
	id int primary key identity(1,1),
	type_of_equip varchar(max) not null
)

create table Equipment
(
	id int primary key identity(1,1),
	name_of varchar(max) not null,
	type_of int references Type_of_equip(id),
	quantity int not null
)

create table Office
(
	id int primary key identity(1,1),
	number_of_office int not null,
	stored_equip id references Equipment(id)
)

create table Registration
(
	id int primary key identity(1,1),
	login_user varchar(max) not null,
	password_user varchar_max not null,
	person int references Response_person(id)
)