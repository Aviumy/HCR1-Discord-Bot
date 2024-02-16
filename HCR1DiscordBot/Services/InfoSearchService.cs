using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HCR1DiscordBot.Models;

namespace HCR1DiscordBot.Services
{
    internal class InfoSearchService
    {
        private string _whitespacePattern = @"[\s\-\+_=\*~`|]+";

        public Vehicle FindIn(Vehicle[] vehicles, string parameter)
        {
            parameter = Regex.Replace(parameter, _whitespacePattern, "").ToLower();

            Vehicle result = vehicles.FirstOrDefault(v => 
                Regex.Replace(v.Name.ToLower(), _whitespacePattern, "") == parameter ||
                Regex.Replace(v.Emoji.ToLower(), _whitespacePattern, "") == parameter ||
                v.Aliases.Select(a => Regex.Replace(a.ToLower(), _whitespacePattern, ""))
                         .Any(a => a == parameter)
            );

            return result;
        }

        public Stage FindIn(Stage[] stages, string parameter)
        {
            parameter = Regex.Replace(parameter, _whitespacePattern, "").ToLower();

            Stage result = stages.FirstOrDefault(s => 
                Regex.Replace(s.Name.ToLower(), _whitespacePattern, "") == parameter ||
                s.Aliases.Select(a => Regex.Replace(a.ToLower(), _whitespacePattern, ""))
                         .Any(a => a == parameter)
            );

            return result;
        }
    }
}
