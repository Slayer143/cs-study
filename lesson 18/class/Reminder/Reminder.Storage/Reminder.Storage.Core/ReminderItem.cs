using System;

namespace Reminder.Storage.Core
{
	public class ReminderItem
	{
		public Guid Id { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status  { get; set; }

		public bool IsReadyToSend => DateTimeOffset.Now > Date;

		public TimeSpan TimeToAlarm => Date - DateTimeOffset.Now;

        public ReminderItem(
            DateTimeOffset date,
            string message,
            string contactId,
            ReminderItemStatus status) :
            this(Guid.NewGuid(), date, message, contactId, status)
        {
        }

        public ReminderItem(
			Guid id,
			DateTimeOffset date, 
			string message, 
			string contactId,
			ReminderItemStatus status)
		{
			Id = id;
			Date = date;
			Message = message;
			ContactId = contactId;
			Status = status;
		}
	}
}
