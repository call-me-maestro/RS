using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace RS
{
    class Program
    {
        private static string api = "https://apps.runescape.com/runemetrics/profile/profile";
        private static int activityCount = 5;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter your Username:");
                var playerName = Console.ReadLine();
                Console.WriteLine($"Username: {playerName}");
                var request = WebRequest.Create(
                    QueryHelpers.AddQueryString(api, new Dictionary<string, string> {
                    {"user", playerName },
                    {"activities", activityCount.ToString() } }
                    ));
                var response = request.GetResponse().GetResponseStream();
                var responseContent = new StreamReader(response).ReadToEnd();
                var playerStatistic = ConvertToPlayerStatistics(responseContent);
                //if (playerStatistic != null)
                //{
                //    foreach(var activity in playerStatistic.Activities)
                //    { Console.WriteLine($"{activity.Text} Was completed by {playerName} on {activity.Date}"); }    
                //}
                var cappingActivity = playerStatistic?.Activities?.SingleOrDefault(c => c.Text == "Capped at my Clan Citadel.");
                if (cappingActivity != null)
                {
                    Console.WriteLine($"{playerName} has capped \n");
                }
                else
                {
                    Console.WriteLine("Capping activity not visible \n");
                }
            }

        }

        private static PlayerStatistics ConvertToPlayerStatistics(string content)
        {
            if (content.Contains("PROFILE_PRIVATE"))
                return null;
            var playerStatistic = JsonConvert.DeserializeObject<PlayerStatistics>(content);

            return playerStatistic;
        }
    }
    public class Activity
    {
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public string Text { get; set; }

    }

    public class PlayerSkill
    {
        public int Level { get; set; }
        public long Xp { get; set; }
        public int Rank { get; set; }
        public int Id { get; set; }
    }

    public class PlayerStatistics
    {
        public long Magic { get; set; }
        public int QuestStarted { get; set; }
        public int TotalSkill { get; set; }
        public int QuestComplete { get; set; }
        public int QuestsNotStarted { get; set; }
        public long TotalXp { get; set; }
        public long Ranged { get; set; }
        public List<Activity> Activities { get; set; }
        public List<PlayerSkill> SkillValues { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public long Melee { get; set; }
        public int CombatLevel { get; set; }
        public bool LoggedIn { get; set; }

    }
}
