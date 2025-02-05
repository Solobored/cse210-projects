namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points) { }

        public override int RecordEvent()
        {
            if (!_completed)
            {
                _completed = true;
                return _points;
            }
            return 0;
        }
    }
}
