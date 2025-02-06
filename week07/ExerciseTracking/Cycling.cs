namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speed; 

        public Cycling(System.DateTime date, int duration, double speed)
            : base(date, duration)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return (_speed * Duration) / 60;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            return Duration / distance;
        }
    }
}
