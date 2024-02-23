using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCR1DiscordBot.Services.ModuleServices
{
    public class HelpModuleService
    {
        private string _helpTextPath;

        public HelpModuleService(string helpTextPath)
        {
            _helpTextPath = helpTextPath;
        }

        public string ReadHelpText()
        {
            return File.ReadAllText(_helpTextPath);
        }
    }
}
