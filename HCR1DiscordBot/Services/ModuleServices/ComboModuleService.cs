using HCR1DiscordBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCR1DiscordBot.Services.ModuleServices
{
    public class ComboModuleService
    {
        private Random _rand;
        private JsonReaderService _jsonReaderService;

        public ComboModuleService(string vehiclesFilePath, string stagesFilePath)
        {
            _rand = new Random();
            _jsonReaderService = new JsonReaderService(vehiclesFilePath, stagesFilePath);
        }

        public Vehicle GetRandomVehicle()
        {
            var vehicles = _jsonReaderService.ReadAllVehicles();
            return vehicles[_rand.Next(vehicles.Length)];
        }

        public Stage GetRandomStage(bool excludeMissions)
        {
            var stages = _jsonReaderService.ReadAllStages(excludeMissions);
            return stages[_rand.Next(stages.Length)];
        }
    }
}
