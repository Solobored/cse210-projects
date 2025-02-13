using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public DateTime LastRecordedDate { get; private set; }
        public int StreakCount { get; set; }

        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
            LastRecordedDate = DateTime.MinValue;
            StreakCount = 0;
        }

        public override int RecordEvent()
        {
            int bonus = 0;
            DateTime today = DateTime.Today;
            if (LastRecordedDate == today.AddDays(-1) || LastRecordedDate == DateTime.MinValue)
            {
                StreakCount++;
                if (StreakCount > 1 && StreakCount % 3 == 0)
                {
                    bonus = 50;
                    Console.WriteLine("Streak Bonus! Your eternal goal streak is now " + StreakCount);
                }
            }
            else
            {
                StreakCount = 1;
            }
            LastRecordedDate = today;
            return _points + bonus;
        }

        public override string GetDetails()
        {
            return $"[∞] {_name} ({_description}) - Last Recorded: {LastRecordedDate.ToShortDateString()}, Streak: {StreakCount}";
        }

        public override string Serialize()
        {

            return $"Eternal|{_name}|{_description}|{_points}|{LastRecordedDate}|{StreakCount}";
        }

        public void SetLastDate(DateTime date)
        {
            LastRecordedDate = date;
        }
    }
}
