use master
create database ChatBot

use ChatBot

create table dbo.ReminderItemStatus (
	StatusCode int not null,
	CodeName nvarchar(20) not null,
	constraint PK_ReminderItemStatusId primary key clustered (StatusCode),
);
go

create table dbo.ReminderItem (
	Id uniqueidentifier not null,
	Date datetimeoffset not null,
	Message nvarchar(100) not null,
	ContactId nvarchar(50) not null,
	StatusCode int not null,
	constraint PK_ReminderItemId primary key clustered (Id),
	constraint FK_ReminderItemStatus_CodeName foreign key (StatusCode)
	references dbo.ReminderItemStatus(StatusCode)
);
go

alter table dbo.ReminderItem
drop constraint PK_ReminderItemId, FK_ReminderItemStatus_CodeName;

alter table dbo.ReminderItemStatus
drop constraint PK_ReminderItemStatusId;

drop table dbo.ReminderItem
drop table dbo.ReminderItemStatus