using Microsoft.AspNetCore.Mvc;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reminder.Storage.WebApi.Controllers
{
	[ApiController]
	[Route("/api/reminders")]
	public class ReminderController : ControllerBase
	{
		private IReminderStorage _reminderStorage;

		public ReminderController(IReminderStorage reminderStorage)
		{
			_reminderStorage = reminderStorage;
		}

		[HttpPost]
		public IActionResult AddReminder([FromBody] ReminderItemAddModel model)
		{
			if (model == null || !ModelState.IsValid)
				return BadRequest();

			Guid id = _reminderStorage.Add(
                model.Date,
                model.Message,
                model.ContactId,
                model.Status);

			return Created(
                $"/api/reminders/{id}",
                new ReminderItemGetModel
                {
                    Id = id,
                    Date = model.Date,
                    Message = model.Message,
                    ContactId = model.ContactId,
                    Status = model.Status
                });
		}

		[HttpGet("{id}")]
		public IActionResult GetReminder(Guid id)
		{
			if (id.GetType() != typeof(Guid)
				|| id == default(Guid)
				|| !ModelState.IsValid)
				return BadRequest();

			ReminderItemGetModel reminder = new ReminderItemGetModel(_reminderStorage.Get(id));

			if (reminder == null)
				return NotFound();

			return Ok(reminder);
		}

		[HttpGet]
		public IActionResult GetRemindersByStatus([FromQuery(Name = "[filter]status")] ReminderItemStatus status)
		{
			List<ReminderItem> reminders = _reminderStorage.Get(status);
			List<ReminderItemGetModel> remindersGetModel =
				reminders
				.Select(x => new ReminderItemGetModel(x))
				.ToList();

			return Ok(remindersGetModel);
		}

		[HttpPatch("{id}")]
		public IActionResult PatchReminders(Guid id, [FromBody] ReminderItemUpdateModel model)
		{
			if (model == null || !ModelState.IsValid)
				return BadRequest();

			if (id.GetType() != typeof(Guid)
				|| id == default(Guid)
				|| !ModelState.IsValid)
				return BadRequest();

			ReminderItem reminder = _reminderStorage.Get(id);
			if (reminder == null)
				return NotFound();

			_reminderStorage.Update(id, model.Status);

			return NoContent();
		}
	}
}
