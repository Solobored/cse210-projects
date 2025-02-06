using System;

namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateTime _date;
        private int _duration; 

        public Activity(DateTime date, int duration)
        {
            _date = date;
            _duration = duration;
        }

        public DateTime Date => _date;
        public int Duration => _duration;

        public abstract double GetDistance(); 
        public abstract double GetSpeed();   
        public abstract double GetPace();     

        public virtual string GetSummary()
        {
            string dateStr = _date.ToString("dd MMM yyyy");
            double distance = GetDistance();
            double speed = GetSpeed();
            double pace = GetPace();
            string activityType = this.GetType().Name; 

            return $"{dateStr} {activityType} ({_duration} min) - Distance: {distance:F1} miles, " +
                   $"Speed: {speed:F1} mph, Pace: {pace:F1} min per mile";
        }
    }
}
