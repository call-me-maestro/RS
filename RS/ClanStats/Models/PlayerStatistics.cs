using System.Collections.Generic;

namespace RS.ClanStats.Models
{
    public class PlayerStatistics
    {
        public long Magic { get; set; }
        public int QuestStarted { get; set; }
        public int TotalSkill { get; set; }
        public int QuestComplete { get; set; }
        public int QuestsNotStarted { get; set; }
        public long TotalXp { get; set; }
        public long Ranged { get; set; }
        public List<PlayerActivity> Activities { get; set; }
        public List<PlayerSkill> SkillValues { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public long Melee { get; set; }
        public int CombatLevel { get; set; }
        public bool LoggedIn { get; set; }

    }
}
