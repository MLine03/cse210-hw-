using System;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speed; // km/h

        public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            // Distance = speed (km/h) * time (hours)
            return _speed * (Minutes / 60.0);
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            double distance = GetDistance();
            if (distance == 0)
                return 0;
            return Minutes / distance; // minutes per km
        }
    }
}
