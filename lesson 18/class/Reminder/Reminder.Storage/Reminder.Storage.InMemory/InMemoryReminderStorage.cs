using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using System.Linq;

namespace Reminder.Storage.InMemory
{
	public class InMemoryReminderStorage : IReminderStorage
	{
		public Dictionary<Guid, ReminderItem> Reminders;

        public InMemoryReminderStorage()
        {
            Reminders = new Dictionary<Guid, ReminderItem>();
        }

        public Guid Add(
            DateTimeOffset date, 
            string message, 
            string contactId, 
            ReminderItemStatus status)
        {
            var reminderItem = new ReminderItem(
                date, 
                message, 
                contactId, 
                status);

            Reminders.Add(reminderItem.Id, reminderItem);

            return reminderItem.Id;
        }

        public ReminderItem Get(Guid id)
		{
			return Reminders.ContainsKey(id)
				? Reminders[id]
				: null;
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			return Reminders
				.Values
				.Where((ReminderItem ri) => ri.Status == status)
				.ToList();
		}

		public void Update(Guid id, ReminderItemStatus status)
		{
			if (Reminders.ContainsKey(id))
				Reminders[id].Status = status;
		}
	}
}
