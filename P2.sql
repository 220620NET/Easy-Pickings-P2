create schema P2;
drop table P2.users;
drop table P2.policy;
drop table P2.insurance;
drop table P2.claims;

create table P2.users(
	userID int identity primary key,
	first_name varchar(100),
	middle_init char,
	last_name varchar(100),
	username varchar(50) unique not null,
	password varchar(50) not null,
	DoB date,
	contact_fk int foreign key references P2.contact(contactID),
	role varchar(10) not null
);

create table P2.policy(
	policyID int identity primary key,
	insurance int foreign key references P2.users(userID),
	coverage varbinary(MAX) not null
);


create table P2.insurance(
	provider int foreign key references P2.policy(policyID),
	benefactor int foreign key references P2.users(userID),
	primary key(provider,benefactor)
);

create table P2.contact(
	contactID int identity primary key, 
	PO_or_street bit not null,
	PO_number int not null default 0,
	street_number int not null default 0,
	street_name varchar(100) not null,
	city_state varchar(100) not null,
	zipcode int not null,	 
	phone int,
	email varchar(100) 
);

create table P2.claims(
	claimID int identity primary key,
	userID_fk int foreign key references P2.users(userID),
	doctorID_fk int foreign key references P2.users(userID),
	provider_fk int foreign key references P2.policy(policyID),
	reasonForVisit varbinary(MAX) not null,
	status varchar(50) not null default 'Pending'
);
alter table P2.users add constraint contact_fk foreign key (contactID) references P2.contact(contactID);