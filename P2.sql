create schema P2;

create table P2.users(
	userID int identity primary key,
	first_name varchar(100) not null,
	middle_init char not null,
	last_name varchar(100) not null,
	username varchar(50) unique not null,
	password varchar(50) not null,
	DoB date not null, 
	phone int,
	email varchar(100)
);

create table P2.insurance(
	provider int unique not null,
	benefactor int foreign key references P2.users(userID),
	primary key(provider,benefactor)
);

create table P2.address(
	userID_fk int foreign key references P2.users(userID),
	PO_or_street bit not null,
	PO_number int not null default 0,
	street_number int not null default 0,
	street_name varchar(100) not null,
	city_state varchar(100) not null,
	zipcode int not null,
	primary key(userID_fk, zipcode)
);

create table P2.claims(
	claimID int identity primary key,
	userID_fk int foreign key references P2.users(userID),
	provider_fk int foreign key references P2.insurance(provider),
	details varbinary(MAX) not null
);