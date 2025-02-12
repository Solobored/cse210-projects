
using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        private int _pointsPerRecording;

        public EternalGoal(string name, int pointsPerRecording) : base(name, 0)
        {
            _pointsPerRecording = pointsPerRecording;
        }

        public override int RecordEvent()
        {
            _points += _pointsPerRecording;
            return _pointsPerRecording;
        }

        public override string GetDescription()
        {
            return $"{_name} (Total points: {_points}) [Eternal]";
        }

        public override string Serialize()
        {
            return $"{this.GetType().Name},{_name},{_points},{0}";
        }
    }
}
