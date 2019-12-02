use master

create database [AirportInfo]

use [AirportInfo]

create table [DepartureBoard]
(
	FlightNumber int not null,
	DepartureCountry nvarchar(60) not null,
	DepartureCity nvarchar(60) not null,
	DepartureDate datetime not null,
	ArrivalCountry nvarchar(60) not null,
	ArrivalCity nvarchar(60) not null,
	ArrivatDate datetime not null,
	TimeOfFlight time not null,
	Airline nvarchar(60) not null,
	AirplaneModel nvarchar(60) not null
)

insert into DepartureBoard(
	FlightNumber, 
	DepartureCountry, 
	DepartureCity, 
	DepartureDate, 
	ArrivalCountry, 
	ArrivalCity, 
	ArrivatDate,
	TimeOfFlight,
	Airline,
	AirplaneModel)
values(
	1254,
	'USA',
	'New-York',
	'2019-11-25T15:14:35',
	'Russia',
	'Moscow',
	'2019-12-14T10:10:15',
	'10:20:00',
	'SWISS',
	'D14-423-FSD')

insert into DepartureBoard(
	FlightNumber, 
	DepartureCountry, 
	DepartureCity, 
	DepartureDate, 
	ArrivalCountry, 
	ArrivalCity, 
	ArrivatDate,
	TimeOfFlight,
	Airline,
	AirplaneModel)
values(
	1254,
	'Canada',
	'Toronto',
	'2019-12-25T11:10:00',
	'USA',
	'Washington',
	'2020-01-14T08:15:15',
	'04:00:00',
	'Norvegian air Shuttle',
	'U12-632-LIH')

use master
drop database AirportInfo