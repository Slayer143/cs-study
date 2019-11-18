using System;
using System.Collections.Generic;

namespace Reminder.Storage.Core
{
	public interface IReminderStorage
	{
        //void Add(ReminderItem reminderItem);

        Guid Add(
            DateTimeOffset date,
            string message,
            string contactId,
            ReminderItemStatus status);

		void Update(Guid id, ReminderItemStatus status);

		ReminderItem Get(Guid id);

		List<ReminderItem> Get(ReminderItemStatus status);
	}
}
