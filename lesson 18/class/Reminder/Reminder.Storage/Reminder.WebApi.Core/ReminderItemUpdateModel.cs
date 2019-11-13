using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Core
{
	public class ReminderItemUpdateModel
	{
		[Required]
		public ReminderItemStatus Status { get; set; }
	}
}
