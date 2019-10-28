using Reminder.Storage.Core;
using System;
using System.Threading;
using Reminder.Domain.Models;
using Reminder.Parser;
using Reminder.Reciever.Core;
using MessageRecievedEventArgs = Reminder.Domain.Models.MessageRecievedEventArgs;

namespace Reminder.Domain
{
    public class ReminderDomain : IDisposable
    {
        internal IReminderStorage _storage;
        internal IReminderReciever _reciever;

        internal TimeSpan _awaitingRemindersCheckingPeriod;

        internal TimeSpan _readyRemindersSendingPeriod;

        internal Timer _awaitingRemindersCheckingTimer;

        internal Timer _readyRemindersSendingTimer;

        public Action<ReminderItem> SendReminder { get; set; }

        public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;
        public event EventHandler<SendingFailedEventArgs> SendingFailed;

        public event EventHandler<MessageRecievedEventArgs> MessageRecieved;
        public event EventHandler<MessageParsingSucceddedEventArgs> MessageParsingSuccedded;
        public event EventHandler<MessageParsingFailedEventArgs> MessageParsingFailed;

        public event EventHandler<AddingToStorageFailedEventArgs> AddingToStorageFailed;
        public event EventHandler<AddingToStorageSucceddedEventArgs> AddingToStorageSucceeded;

        public ReminderDomain(
            IReminderStorage storage,
            IReminderReciever reciever,
            TimeSpan awaitingRemindersCheckingPeriod,
            TimeSpan readyRemindersSendingPeriod)
        {
            _storage = storage;
            _reciever = reciever;
            _awaitingRemindersCheckingPeriod = awaitingRemindersCheckingPeriod;
            _readyRemindersSendingPeriod = readyRemindersSendingPeriod;

            _reciever.MessageRecieved += (s, e) =>
            {
                MessageRecieved?.Invoke(
                    this,
                    new MessageRecievedEventArgs
                    {
                        ContactId = e.ContactId,
                        Message = e.Message
                    });

                ParsedMessage parsedMessage;

                try
                {
                    parsedMessage = MessageParser.Parse(e.Message);

                    MessageParsingSuccedded?.Invoke(
                        this,
                        new MessageParsingSucceddedEventArgs
                        {
                            ContactId = e.ContactId,
                            Date = parsedMessage.Date,
                            Message = parsedMessage.Message
                        });
                }
                catch (Exception ex)
                {
                    MessageParsingFailed?.Invoke(
                        this,
                        new MessageParsingFailedEventArgs
                        {
                            ContactId = e.ContactId,
                            Message = e.Message,
                            ParsingException = ex
                        });

                    return;
                }

                var item = new ReminderItem(
                        parsedMessage.Date,
                        parsedMessage.Message,
                        e.ContactId);

                try
                {
                    storage.Add(item);
                    AddingToStorageSucceeded?.Invoke(
                        this,
                        new AddingToStorageSucceddedEventArgs
                        {
                            ContactId = e.ContactId,
                            Message = e.Message
                        });

                }
                catch (Exception ex)
                {
                    AddingToStorageFailed?.Invoke(
                        this,
                        new AddingToStorageFailedEventArgs
                        {
                            ContactId = e.ContactId,
                            Message = e.Message,
                            AddingException = ex
                        });
                }
            };
        }

        public ReminderDomain(
            IReminderStorage storage,
            IReminderReciever receiver)
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

            _reciever.Run();
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
