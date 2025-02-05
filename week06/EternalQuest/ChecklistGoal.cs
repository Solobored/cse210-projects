namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _pointsPerCompletion;
        private int _targetCount;
        private int _currentCount;

        public ChecklistGoal(string name, int pointsPerCompletion, int targetCount)
            : base(name, 0)
        {
            _pointsPerCompletion = pointsPerCompletion;
            _targetCount = targetCount;
            _currentCount = 0;
        }

        public override int RecordEvent()
        {
            if (_completed)
                return 0;

            _currentCount++;
            _points += _pointsPerCompletion;
            if (_currentCount >= _targetCount)
            {
                _completed = true;
                int bonus = 500;
                _points += bonus;
                return _pointsPerCompletion + bonus;
            }
            return _pointsPerCompletion;
        }

        public override string GetDescription()
        {
            string status = _completed ? "[X]" : $"[ {_currentCount}/{_targetCount} ]";
            return $"{_name} (Total points: {_points}) {status}";
        }

        public override string Serialize()
        {
            return $"{this.GetType().Name},{_name},{_points},{(_completed ? 1 : 0)},{_currentCount},{_targetCount}";
        }

        public void SetCompletionCount(int count)
        {
            _currentCount = count;
            if (_currentCount >= _targetCount)
                _completed = true;
        }
    }
}
