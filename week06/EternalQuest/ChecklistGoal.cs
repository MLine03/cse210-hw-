using System;

namespace EternalQuestApp
{
    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; private set; }
        public int CurrentCount { get; private set; }
        public int BonusPoints { get; private set; }

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
            : base(name, description, points)
        {
            TargetCount = targetCount;
            BonusPoints = bonusPoints;
            CurrentCount = 0;
        }

        public override int RecordEvent()
        {
            if (Completed)
                return 0;

            CurrentCount++;
            int totalPoints = Points;

            if (CurrentCount >= TargetCount)
            {
                Completed = true;
                totalPoints += BonusPoints;
            }
            return totalPoints;
        }

        public override string DisplayGoal()
        {
            string status = Completed ? "[X]" : "[ ]";
            return $"{status} {Name} ({Description}) Completed {CurrentCount}/{TargetCount} times";
        }

        public override bool IsComplete()
        {
            return Completed;
        }
    }
}
