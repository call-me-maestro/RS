using Microsoft.AspNetCore.WebUtilities;
using RS.ClanStats.Converters;
using RS.ClanStats.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace RS.ClanStats.Services
{
    public class PlayerService
    {
        private readonly string api;
        private int ActivityCount { get; set; }
        private JsonObjectToPlayerSkillConverter _converter;

        public PlayerService()
        {
            api = "https://apps.runescape.com/runemetrics/profile/profile";
            ActivityCount = 5;
            _converter = new JsonObjectToPlayerSkillConverter();
        }
        public PlayerStatistics GetPlayerCappingStatistics(string playerName)
        {
            return GetPlayerCappingStatistic(playerName);
        }
        private PlayerStatistics GetPlayerCappingStatistic(string playerName)
        {
            var request = WebRequest.Create(
                    QueryHelpers.AddQueryString(api, new Dictionary<string, string>
                    {
                        {"user", playerName },
                        {"activities", ActivityCount.ToString() }
                    }
                    )
            );

            var response = request.GetResponse().GetResponseStream();
            var responseContent = new StreamReader(response).ReadToEnd();
            var playerStatistic = _converter.Convert(responseContent);
            return playerStatistic;
        }
        
    }
}
