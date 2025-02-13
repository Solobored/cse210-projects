using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        protected bool _isComplete;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            _isComplete = false;
        }

        public abstract int RecordEvent();
        public abstract string GetDetails();
        public abstract string Serialize();

        public static Goal Deserialize(string data)
        {
            string[] parts = data.Split('|');
            string type = parts[0];
            if (type == "Simple")
            {
                SimpleGoal sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                sg.SetComplete(bool.Parse(parts[4]));
                return sg;
            }
            else if (type == "Eternal")
            {
                EternalGoal eg = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                eg.SetLastDate(DateTime.Parse(parts[4]));
                eg.StreakCount = int.Parse(parts[5]);
                return eg;
            }
            else if (type == "Checklist")
            {
                ChecklistGoal cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                                       int.Parse(parts[5]), int.Parse(parts[6]));
                cg.CurrentCount = int.Parse(parts[4]);
                cg.SetComplete(bool.Parse(parts[7]));
                return cg;
            }
            else if (type == "Negative")
            {
                NegativeGoal ng = new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]));
                ng.SetComplete(bool.Parse(parts[4]));
                return ng;
            }
            else
            {
                throw new Exception("Unknown goal type");
            }
        }

        public bool IsComplete() => _isComplete;
        public string GetName() => _name;
        public int GetPoints() => _points;
        public void SetComplete(bool complete) { _isComplete = complete; }
    }
}
