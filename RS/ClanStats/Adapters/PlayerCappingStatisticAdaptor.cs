using RS.ClanStats.Services;
using System.Linq;

namespace RS.ClanStats.Adapters
{
    public class PlayerCappingStatisticAdaptor
    {
        private readonly PlayerService _playerService;

        public PlayerCappingStatisticAdaptor(PlayerService playerService)
        {
            _playerService = playerService;
        }


        public string Adapt(string playerName)
        {
            var playerStatistic = _playerService.GetPlayerCappingStatistics(playerName);
            var cappingActivity = playerStatistic?.Activities?.Select(c => c.Text == "Capped at my Clan Citadel.");
            if (cappingActivity != null)
            {
                return $"{playerName} has capped \n";
            }
            else
            {
                return "Capping activity not visible \n";
            }
        }
    }

}
