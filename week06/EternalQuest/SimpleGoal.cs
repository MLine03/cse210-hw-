using System;

namespace EternalQuestApp
{
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

        public override int RecordEvent()
        {
            if (!Completed)
            {
                Completed = true;
                return Points;
            }
            return 0;
        }
    }
}
