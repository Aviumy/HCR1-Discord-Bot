using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCR1DiscordBot.Services.ModuleServices
{
    public class InfoModuleService
    {
        private Random _rand;
        private JsonReaderService _jsonReaderService;
        private InfoSearchService _infoSearchService;

        public InfoModuleService(string vehiclesFilePath, string stagesFilePath)
        {
            _rand = new Random();
            _jsonReaderService = new JsonReaderService(vehiclesFilePath, stagesFilePath);
            _infoSearchService = new InfoSearchService();
        }

        public dynamic GetRandomVehicleOrStage()
        {
            if (_rand.Next(2) == 0)
            {
                var vehicles = _jsonReaderService.ReadAllVehicles();
                return vehicles[_rand.Next(vehicles.Length)];
            }
            else
            {
                var stages = _jsonReaderService.ReadAllStages();
                return stages[_rand.Next(stages.Length)];
            }
        }

        public string GetVehicleOrStageInfo(string parameter)
        {
            StringBuilder sb = new StringBuilder();

            var vehicles = _jsonReaderService.ReadAllVehicles();
            dynamic item = _infoSearchService.FindIn(vehicles, parameter);
            if (item != null)
            {
                sb.AppendLine($"{item.Emoji} **{item.Name}**");
                if (item.Name.ToLower() == "garage")
                {
                    sb.AppendLine($"Purchase cost: 300 gems");
                    sb.AppendLine($"Upgrade cost: Random");
                    sb.AppendLine($"Total cost (Purchase + Upgrade): Random");
                }
                else
                {
                    sb.AppendLine($"Purchase cost: {item.PurchaseCost:n0}");
                    sb.AppendLine($"Upgrade cost: {item.UpgradeCost:n0}");
                    sb.AppendLine($"Total cost (Purchase + Upgrade): {(item.PurchaseCost + item.UpgradeCost):n0}");
                }
                sb.AppendLine($"Fuel Duration: {item.FuelDuration}");
            }
            else
            {
                var stages = _jsonReaderService.ReadAllStages();
                item = _infoSearchService.FindIn(stages, parameter);
                if (item != null)
                {
                    sb.AppendLine($"**{item.Name}**");
                    sb.AppendLine($"Purchase cost: {item.PurchaseCost:n0}");
                    sb.AppendLine($"Fuel locations: coming soon...");
                }
                else
                {
                    sb.AppendLine("Couldn't find such vehicle or stage");
                }
            }

            return sb.ToString();
        }
    }
}
