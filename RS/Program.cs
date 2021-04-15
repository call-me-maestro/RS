using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using RS.ClanStats.Adapters;
using RS.ClanStats.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace RS
{
    class Program
    {       

        static void Main(string[] args)
        {
            while (true)
            {
                var service = new PlayerService();
                var adapter = new PlayerCappingStatisticAdaptor(service);
                Console.WriteLine("Enter your Username:");
                var playerName = Console.ReadLine();
                Console.WriteLine($"Username: {playerName}");
                Console.WriteLine(adapter.Adapt(playerName));
                
                //if (playerStatistic != null)
                //{
                //    foreach(var activity in playerStatistic.Activities)
                //    { Console.WriteLine($"{activity.Text} Was completed by {playerName} on {activity.Date}"); }    
                //}
                
            }

        }

        
    }
}
