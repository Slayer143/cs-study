using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Models
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

		public ReminderItemAddModel() { }

		public ReminderItemAddModel(ReminderItem reminderItem)
		{
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			ContactId = reminderItem.ContactId;
		}

		public ReminderItem ConvertToReminderItem()
		{
			return new ReminderItem(Date, Message, ContactId);
		}
	}
}
