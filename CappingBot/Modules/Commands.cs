using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CappingBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("new")]
        public async Task NewWeek()
        {
            await ReplyAsync("..........................................NEW WEEK...........................................");
        }

        [Command("all")]
        public async Task AllPlots()
        {
            await ReplyAsync("........................................ALL PLOTS OPEN.......................................");
        }

        [Command("cap")]
        public async Task Capped()
        {
            var user = Context.User;
            await ReplyAsync($"{user.Username} has capped at the citadel!");
        }

        [Command("me")]
        public async Task Me()
        {
            var random = new Random();
            var allAboutMe = new List<string>{ 
                  "I like sausage rolls"
                , "I could eat a chip barm"
                , "I like potatoes" };
            int index = random.Next(allAboutMe.Count);
            await ReplyAsync($"{allAboutMe[index]}");
        }
    }
}
