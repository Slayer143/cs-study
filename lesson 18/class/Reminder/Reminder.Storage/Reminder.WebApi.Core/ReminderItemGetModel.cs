using Reminder.Storage.Core;
using System;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemGetModel
	{
		public Guid Id { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

        public ReminderItemGetModel() { }

        public ReminderItemGetModel(ReminderItem reminderItem)
        {
            Id = reminderItem.Id;
            Date = reminderItem.Date;
            Message = reminderItem.Message;
            ContactId = reminderItem.ContactId;
            Status = reminderItem.Status;
        }
	}
}
