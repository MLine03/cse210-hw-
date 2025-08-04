using System;

namespace EternalQuestApp
{
    // Base Goal class
    public abstract class Goal
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Points { get; private set; }
        protected bool Completed;

        public Goal(string name, string description, int points)
        {
            Name = name;
            Description = description;
            Points = points;
            Completed = false;
        }

        // Record progress toward goal, return points earned this event
        public abstract int RecordEvent();

        // Is the goal complete? (override as needed)
        public virtual bool IsComplete()
        {
            return Completed;
        }

        // Display goal info for list
        public virtual string DisplayGoal()
        {
            string status = Completed ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description})";
        }
    }
}
