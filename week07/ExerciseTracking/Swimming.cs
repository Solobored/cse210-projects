namespace ExerciseTracking
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(System.DateTime date, int duration, int laps)
            : base(date, duration)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            return _laps * 50.0 / 1000 * 0.62;
        }

        public override double GetSpeed()
        {
            double distance = GetDistance();
            return (distance / Duration) * 60;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            return Duration / distance;
        }
    }
}
