using System;
using System.Collections.Generic;

namespace EternalQuest
{
    public class User
    {
        public int Score { get; set; }
        public int Level { get; set; }
        public List<string> Achievements { get; set; }

        public User()
        {
            Score = 0;
            Level = 1;
            Achievements = new List<string>();
        }

        public void AddScore(int points)
        {
            Score += points;
            CheckLevelUp();
            CheckAchievements();
        }

        private void CheckLevelUp()
        {
            int newLevel = Score / 1000 + 1;
            if (newLevel > Level)
            {
                Level = newLevel;
                Console.WriteLine($"Congratulations! You've reached level {Level}!");
            }
        }

        private void CheckAchievements()
        {
            if (Score >= 500 && !Achievements.Contains("500 Points Club"))
            {
                Achievements.Add("500 Points Club");
                Console.WriteLine("Achievement Unlocked: 500 Points Club!");
            }
            if (Score >= 1000 && !Achievements.Contains("1000 Points Milestone"))
            {
                Achievements.Add("1000 Points Milestone");
                Console.WriteLine("Achievement Unlocked: 1000 Points Milestone!");
            }
        }

        public override string ToString()
        {
            string achievementList = Achievements.Count > 0 ? string.Join(", ", Achievements) : "None";
            return $"Score: {Score}, Level: {Level}\nAchievements: {achievementList}";
        }

        public string Serialize()
        {
            return $"{Score}|{Level}|{string.Join(",", Achievements)}";
        }

        public static User Deserialize(string data)
        {
            string[] parts = data.Split('|');
            User user = new User();
            user.Score = int.Parse(parts[0]);
            user.Level = int.Parse(parts[1]);
            if (parts.Length > 2 && !string.IsNullOrEmpty(parts[2]))
                user.Achievements = new List<string>(parts[2].Split(','));
            return user;
        }
    }
}
