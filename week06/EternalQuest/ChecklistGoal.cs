using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        public int CurrentCount { get; set; }
        public int TargetCount { get; private set; }
        public int BonusPoints { get; private set; }

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            CurrentCount = 0;
            TargetCount = targetCount;
            BonusPoints = bonusPoints;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                CurrentCount++;
                int total = _points;
                if (CurrentCount >= TargetCount)
                {
                    _isComplete = true;
                    total += BonusPoints;
                    Console.WriteLine("Checklist completed! Bonus " + BonusPoints + " points earned!");
                }
                return total;
            }
            return 0;
        }

        public override string GetDetails()
        {
            string status = _isComplete ? "[X]" : "[ ]";
            return $"{status} {_name} ({_description}) -- Completed {CurrentCount}/{TargetCount} times";
        }

        public override string Serialize()
        {
            return $"Checklist|{_name}|{_description}|{_points}|{CurrentCount}|{TargetCount}|{BonusPoints}|{_isComplete}";
        }
    }
}
