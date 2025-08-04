using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EternalQuestApp
{
    public class GoalManager
    {
        private List<Goal> Goals = new();
        private int TotalScore = 0;

        public void AddGoal(Goal goal)
        {
            Goals.Add(goal);
        }

        public void RecordGoalEvent(int goalIndex)
        {
            if (goalIndex < 0 || goalIndex >= Goals.Count)
            {
                Console.WriteLine("Invalid goal selection.");
                return;
            }
            int pointsEarned = Goals[goalIndex].RecordEvent();
            TotalScore += pointsEarned;
            Console.WriteLine($"You earned {pointsEarned} points!");
        }

        public void ShowGoals()
        {
            if (Goals.Count == 0)
            {
                Console.WriteLine("No goals yet.");
                return;
            }
            for (int i = 0; i < Goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Goals[i].DisplayGoal()}");
            }
        }

        public void ShowScore()
        {
            Console.WriteLine($"Total Score: {TotalScore}");
        }

        // Save data container for serialization
        private class SaveData
        {
            public List<GoalSaveModel> Goals { get; set; }
            public int Score { get; set; }
        }

        // Model to save/load polymorphic goals
        private class GoalSaveModel
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Points { get; set; }
            public bool Completed { get; set; }

            // For ChecklistGoal only:
            public int TargetCount { get; set; }
            public int CurrentCount { get; set; }
            public int BonusPoints { get; set; }
        }

        // Convert Goals to SaveModel for JSON serialization
        private List<GoalSaveModel> ToSaveModel()
        {
            var list = new List<GoalSaveModel>();
            foreach (var goal in Goals)
            {
                var model = new GoalSaveModel()
                {
                    Name = goal.Name,
                    Description = goal.Description,
                    Points = goal.Points,
                    Completed = goal.IsComplete(),
                    Type = goal.GetType().Name
                };

                if (goal is ChecklistGoal cgoal)
                {
                    model.TargetCount = cgoal.TargetCount;
                    model.CurrentCount = cgoal.CurrentCount;
                    model.BonusPoints = cgoal.BonusPoints;
                }

                list.Add(model);
            }
            return list;
        }

        // Convert SaveModel back to Goal objects
        private List<Goal> FromSaveModel(List<GoalSaveModel> saveModels)
        {
            var list = new List<Goal>();
            foreach (var model in saveModels)
            {
                Goal goal = null;
                switch (model.Type)
                {
                    case nameof(SimpleGoal):
                        goal = new SimpleGoal(model.Name, model.Description, model.Points);
                        if (model.Completed)
                            typeof(SimpleGoal).GetField("Completed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(goal, true);
                        break;
                    case nameof(EternalGoal):
                        goal = new EternalGoal(model.Name, model.Description, model.Points);
                        break;
                    case nameof(ChecklistGoal):
                        var checklist = new ChecklistGoal(model.Name, model.Description, model.Points, model.TargetCount, model.BonusPoints);
                        typeof(ChecklistGoal).GetProperty("CurrentCount").SetValue(checklist, model.CurrentCount);
                        if (model.Completed)
                            typeof(ChecklistGoal).GetField("Completed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(checklist, true);
                        goal = checklist;
                        break;
                }
                if (goal != null)
                    list.Add(goal);
            }
            return list;
        }

        public void Save(string filename)
        {
            var saveData = new SaveData()
            {
                Goals = ToSaveModel(),
                Score = TotalScore
            };

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(saveData, options);
            File.WriteAllText(filename, json);
            Console.WriteLine($"Progress saved to {filename}.");
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("Save file not found.");
                return;
            }
            string json = File.ReadAllText(filename);
            var saveData = JsonSerializer.Deserialize<SaveData>(json);
            if (saveData != null)
            {
                Goals = FromSaveModel(saveData.Goals);
                TotalScore = saveData.Score;
                Console.WriteLine("Progress loaded.");
            }
        }
    }
}
