using System;
using System.Collections.Generic;
using Reminder.Storage.Core;
using System.Linq;

namespace Reminder.Storage.InMemory
{
	public class InMemoryReminderStorage : IReminderStorage
	{
		public Dictionary<Guid, ReminderItem> reminders;

		public void Add(ReminderItem reminderItem)
		{
			reminders.Add(reminderItem.Id, reminderItem);
		}

		public ReminderItem Get(Guid id)
		{
			return reminders.ContainsKey(id)
				? reminders[id]
				: null;
		}

		public List<ReminderItem> Get(ReminderItemStatus status)
		{
			return reminders
				.Values
				.Where((ReminderItem ri) => ri.Status == status)
				.ToList();
		}

		public void Update(Guid id, ReminderItemStatus status)
		{
			if (reminders.ContainsKey(id))
				reminders[id].Status = status;
		}
	}
}
