using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected int _points;
        protected bool _completed;

        public Goal(string name, int points)
        {
            _name = name;
            _points = points;
            _completed = false;
        }

        public virtual int RecordEvent()
        {
            _completed = true;
            return _points;
        }

        public virtual string GetDescription()
        {
            string status = _completed ? "[X]" : "[ ]";
            return $"{_name} ({_points} pts) {status}";
        }

        public bool IsComplete() => _completed;

        public virtual string Serialize()
        {
            return $"{this.GetType().Name},{_name},{_points},{(_completed ? 1 : 0)}";
        }

        public static Goal Deserialize(string line)
        {
            string[] parts = line.Split(',');
            if (parts.Length < 4)
                throw new ArgumentException("Invalid data format");

            string type = parts[0];
            string name = parts[1];
            int points = int.Parse(parts[2]);
            bool completed = parts[3] == "1";

            Goal goal;
            switch (type)
            {
                case "SimpleGoal":
                    goal = new SimpleGoal(name, points);
                    break;
                case "EternalGoal":
                    goal = new EternalGoal(name, 100);
                    break;
                case "ChecklistGoal":
                    if (parts.Length < 6)
                        throw new ArgumentException("Invalid data format for ChecklistGoal");
                    int currentCount = int.Parse(parts[4]);
                    int targetCount = int.Parse(parts[5]);
                    goal = new ChecklistGoal(name, points, targetCount);
                    ((ChecklistGoal)goal).SetCompletionCount(currentCount);
                    break;
                default:
                    throw new ArgumentException("Unknown goal type");
            }

            if (completed)
                goal._completed = true;

            return goal;
        }
    }
}
