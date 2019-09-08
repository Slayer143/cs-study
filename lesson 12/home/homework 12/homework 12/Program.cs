using System;
using System.Collections.Generic;

namespace homework_12
{
    class Program
    {
        static void Main(string[] args)
        {
            var reminders = new List<ReminderItem>();

            reminders.Add(new ReminderItem(
                    DateTimeOffset.Parse("2019-09-08 20:00:00"),
                    "HAVE A GOOD DAY"
                    ));

            reminders.Add(new PhoneReminderItem(
                    DateTimeOffset.Parse("2019-09-09 10:00:00"),
                    "CALL JOHN",
                    "+89258894544"
                    ));

            reminders.Add(new ChatReminderItem(
                    DateTimeOffset.Parse("2019-09-07 15:00:00"),
                    "NEW LESSON",
                    "Math class",
                    "Slayer"
                    ));

            foreach(var reminder in reminders)
            {
                Console.WriteLine(Convert.ToString(reminder.GetType()));
                reminder.WriteOutAlarmInfo();
            }
        }
    }
}
