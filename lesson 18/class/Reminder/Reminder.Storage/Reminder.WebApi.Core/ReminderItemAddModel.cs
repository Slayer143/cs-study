using Reminder.Storage.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemAddModel
	{
		[Required]
		public DateTimeOffset Date { get; set; }

		[Required,
		MaxLength(300)]
		public string Message { get; set; }

		[Required,
		MaxLength(50)]
		public string ContactId { get; set; }

        public ReminderItemStatus Status { get; set; }

		//public ReminderItemAddModel() { }

		//public ReminderItemAddModel(ReminderItem reminderItem)
		//{
		//	Date = reminderItem.Date;
		//	Message = reminderItem.Message;
		//	ContactId = reminderItem.ContactId;
		//}

		//public ReminderItem ConvertToReminderItem()
		//{
		//	return new ReminderItem(Guid.NewGuid(), Date, Message, ContactId, ReminderItemStatus.Awaiting);
		//}
	}
}
