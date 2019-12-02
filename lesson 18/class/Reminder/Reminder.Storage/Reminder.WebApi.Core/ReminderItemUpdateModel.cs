using Reminder.Storage.Core;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Storage.WebApi.Core
{
    public class ReminderItemUpdateModel
	{
		[Required]
		public ReminderItemStatus Status { get; set; }
	}
}
