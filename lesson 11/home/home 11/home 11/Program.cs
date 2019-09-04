using System;

namespace home_11
{
    class Program
    {
        static void Main(string[] args)
        {
            var reminder = new ReminderItem(DateTimeOffset.Parse("4/9/2019 2:22:11 AM"), "ALARM");
            reminder.Writer();
        }
    }

    class ReminderItem
    {

        private DateTimeOffset _alarmDate;
        private string _alarmMessage;
        private TimeSpan _timeToAlarm;
        private bool _isOutdated;

        public DateTimeOffset AlarmDate
        {
            get { return _alarmDate; }
            set
            {
                _alarmDate = value;
            }
        }
        public string AlarmMessage
        {
            get { return _alarmMessage; }
            set
            {
                _alarmMessage = value;
            }
        }
        public TimeSpan TimeToAlarm
        {
            get
            {
                return _timeToAlarm = _alarmDate - DateTimeOffset.Now ;
            }
        }
        public bool IsOutdated
        {
            get { return _isOutdated; }
            set
            {
                if (Convert.ToInt32(_timeToAlarm) < 0)
                    _isOutdated = true;
                else if (Convert.ToInt32(_timeToAlarm) >= 0)
                    _isOutdated = false;
            }
        }

        public ReminderItem (DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }
        public ReminderItem()
        {

        }

        public void Writer()
        {
            Console.WriteLine($"Alarm date: {_alarmDate}\n"
                + $"Alarm message: {_alarmMessage}\n"
                + $"Time to alarm: {TimeToAlarm}\n"
                + $"Outdated: {(_isOutdated ? "Yes" : "No")}");
        }
    }
}
