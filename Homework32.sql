use [ChatBot]

drop procedure if exists dbo.GetReminderItemById
drop procedure if exists dbo.GetReminderItemByStatus
drop procedure if exists dbo.AddReminder
drop procedure if exists dbo.PatchReminder

create procedure dbo.GetReminderItemById(
	@guid AS uniqueidentifier
)
as
begin
	set nocount on
	
	select [Date], [Message], [ContactId], [StatusCode]
	from dbo.ReminderItem
	where [Id] = @guid
end
go

create procedure dbo.GetReminderItemByStatus(
	@statusCode AS int
)
as
begin
	set nocount on
	
	select [Date], [Message], [ContactId], [StatusCode]
	from dbo.ReminderItem
	where [StatusCode] = @statusCode
end
go

create procedure dbo.AddReminder(
	@guid AS uniqueidentifier,
	@date AS datetimeoffset(7),
	@message AS nvarchar(100),
	@contactId AS nvarchar(50),
	@statusCode AS int
)
as
begin
	set nocount on
	
	insert into dbo.ReminderItem([Id], [Date], [Message], [ContactId], [StatusCode]) 
	values (@guid, @date, @message, @contactId, @statusCode)
end
go

create procedure dbo.PatchReminder(
	@guid AS uniqueidentifier,
	@statusCode AS int
)
as
begin
	set nocount on

	update dbo.ReminderItem
	set [StatusCode] = @statusCode
	where [Id] = @guid
end
go