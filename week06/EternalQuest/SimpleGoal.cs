using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points) { }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            return 0;
        }

        public override string GetDetails()
        {
            string status = _isComplete ? "[X]" : "[ ]";
            return $"{status} {_name} ({_description})";
        }

        public override string Serialize()
        {
            return $"Simple|{_name}|{_description}|{_points}|{_isComplete}";
        }
    }
}
