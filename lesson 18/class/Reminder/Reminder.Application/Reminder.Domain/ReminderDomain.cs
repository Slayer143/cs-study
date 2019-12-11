using Reminder.Storage.Core;
using System;
using System.Threading;
using Reminder.Domain.Models;
using Reminder.Parser;
using Reminder.Receiever.Core;
using MessageReceivedEventArgs = Reminder.Domain.Models.MessageReceivedEventArgs;

namespace Reminder.Domain
{
	public class ReminderDomain : IDisposable
	{
		internal IReminderStorage _storage;
		internal IReminderReceiever _receiever;

		internal TimeSpan _awaitingRemindersCheckingPeriod;

		internal TimeSpan _readyRemindersSendingPeriod;

		internal Timer _awaitingRemindersCheckingTimer;

		internal Timer _readyRemindersSendingTimer;

		public Action<ReminderItem> SendReminder { get; set; }

		public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;
		public event EventHandler<SendingFailedEventArgs> SendingFailed;

		public event EventHandler<MessageReceivedEventArgs> MessageReceieved;

		public event EventHandler<MessageParsingSucceddedEventArgs> MessageParsingSuccedded;
		public event EventHandler<MessageParsingFailedEventArgs> MessageParsingFailed;

		public event EventHandler<AddingToStorageFailedEventArgs> AddingToStorageFailed;
		public event EventHandler<AddingToStorageSucceddedEventArgs> AddingToStorageSucceeded;

		public ReminderDomain(
			IReminderStorage storage,
			IReminderReceiever receiever,
			TimeSpan awaitingRemindersCheckingPeriod,
			TimeSpan readyRemindersSendingPeriod)
		{
			_storage = storage;
			_receiever = receiever;
			_awaitingRemindersCheckingPeriod = awaitingRemindersCheckingPeriod;
			_readyRemindersSendingPeriod = readyRemindersSendingPeriod;

			_receiever.MessageRecieved += ReceiverMessageReceieved;
		}

		private void ReceiverMessageReceieved(object sender, Receiever.Core.MessageReceivedEventArgs e)
		{
			MessageReceievedInvoke(e.ContactId, e.Message);
			ParsedMessage parsedMessage;

			try
			{
				parsedMessage = MessageParser.Parse(e.Message);
				MessageParsingSucceddedInvoke(e.ContactId, parsedMessage.Date, parsedMessage.Message);


			}
			catch (Exception ex)
			{
				MessageParsingFailedInvoke(e.ContactId, e.Message, ex);

				return;
			}

            Guid id;

			try
			{
				id = _storage.Add(
                    parsedMessage.Date,
                    parsedMessage.Message,
                    e.ContactId,
                    ReminderItemStatus.Awaiting);



				AddingToStorageSucceddedInvoke(
                    id, 
                    parsedMessage.Date, 
                    parsedMessage.Message,
                    e.ContactId, 
                    ReminderItemStatus.Awaiting);
			}
			catch (Exception ex)
			{
				AddingToStorageFailedInvoke(
                    parsedMessage.Date,
                    parsedMessage.Message,
                    e.ContactId,
                    ReminderItemStatus.Awaiting, ex);
			}
		}

		private void AddingToStorageFailedInvoke(
                    DateTimeOffset date,
                    string message,
                    string contactId,
                    ReminderItemStatus status,
                    Exception exception)
		{
			AddingToStorageFailed?.Invoke(
						this,
						new AddingToStorageFailedEventArgs(
                            date, 
                            message, 
                            contactId, 
                            status, 
                            exception));
		}

		private void AddingToStorageSucceddedInvoke(
            Guid id,
            DateTimeOffset date,
            string message,
            string contactId,
            ReminderItemStatus status)
		{
			AddingToStorageSucceeded?.Invoke(
						this,
						new AddingToStorageSucceddedEventArgs(id, date, message, contactId, status));
		}

		private void MessageParsingFailedInvoke(string contactId, string message, Exception exception)
		{
			MessageParsingFailed?.Invoke(
			this,
			new MessageParsingFailedEventArgs
			{
				ContactId = contactId,
				Message = message,
				ParsingException = exception
			});
		}

		private void MessageParsingSucceddedInvoke(string contactId, DateTimeOffset date, string message)
		{
			MessageParsingSuccedded?.Invoke(
			this,
			new MessageParsingSucceddedEventArgs
			{
				ContactId = contactId,
				Date = date,
				Message = message
			});
		}

		private void MessageReceievedInvoke(string contactId, string message)
		{
			MessageReceieved?.Invoke(
				   this,
				   new MessageReceivedEventArgs
				   {
					   ContactId = contactId,
					   Message = message
				   });
		}

		public ReminderDomain(
			IReminderStorage storage,
			IReminderReceiever receiver)
			: this(storage, receiver, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1))
		{
		}

		public void Run()
		{
			_awaitingRemindersCheckingTimer = new Timer(
				CheckAwaitingReminders,
				null,
				TimeSpan.Zero,
				_awaitingRemindersCheckingPeriod);

			_readyRemindersSendingTimer = new Timer(
				SendReadyReminders,
				null,
				TimeSpan.FromSeconds(1),
				_readyRemindersSendingPeriod);

			_receiever.Run();
		}

		internal void CheckAwaitingReminders(object state)
		{
			// here will check storage for awaiting items 
			// check each for it`s date
			// if it is time to send, change the status to ready

			var awaitingReminders = _storage.Get(ReminderItemStatus.Awaiting);

			foreach (var awaitingReminder in awaitingReminders)
			{
				if (awaitingReminder.IsReadyToSend)
					_storage.Update(awaitingReminder.Id, ReminderItemStatus.Ready);
			}
		}

		internal void SendReadyReminders(object state)
		{
			// find ready reminders
			// try "send"
			// if success update status to Sent
			// else update status to Failed
			var readyReminders = _storage.Get(ReminderItemStatus.Ready);

			foreach (var readyReminder in readyReminders)
			{
				try
				{
					// try "send"
					SendReminder(readyReminder);

					// update status to Sent
					_storage.Update(readyReminder.Id, ReminderItemStatus.Sent);

					SendingSucceeded?.Invoke(
						this,
						new SendingSucceededEventArgs
						{
							SendingItem = readyReminder
						});
				}
				catch (Exception e)
				{
					// update status to Failed
					_storage.Update(readyReminder.Id, ReminderItemStatus.Failed);

					SendingFailed?.Invoke(
						this,
						new SendingFailedEventArgs
						{
							SendingItem = readyReminder,
							SendingException = e
						});
				}
			}
		}

		public void Dispose()
		{
			_awaitingRemindersCheckingTimer?.Dispose();
			_readyRemindersSendingTimer?.Dispose();
		}
	}
}
