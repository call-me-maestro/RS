using Newtonsoft.Json;
using RS.ClanStats.Models;

namespace RS.ClanStats.Converters
{
    public class JsonObjectToPlayerSkillConverter
    {
        public PlayerStatistics Convert(string content)
        {
            if (content.Contains("PROFILE_PRIVATE"))
                return null;
            var playerStatistic = JsonConvert.DeserializeObject<PlayerStatistics>(content);

            return playerStatistic;
        }
    }
}
