using System;

namespace EternalQuest
{
    public class NegativeGoal : Goal
    {
        public NegativeGoal(string name, string description, int penaltyPoints)
            : base(name, description, penaltyPoints)
        { }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                Console.WriteLine("Negative goal recorded. Try to avoid this habit!");
                return -_points;
            }
            return 0;
        }

        public override string GetDetails()
        {
            return $"[!] {_name} ({_description})";
        }

        public override string Serialize()
        {
            return $"Negative|{_name}|{_description}|{_points}|{_isComplete}";
        }
    }
}
