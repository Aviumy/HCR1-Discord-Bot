﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCR1DiscordBot.Models;

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

        public InfoModuleService(int randSeed, string vehiclesFilePath, string stagesFilePath)
        {
            _rand = new Random(randSeed);
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
            var vehicles = _jsonReaderService.ReadAllVehicles();
            dynamic item = _infoSearchService.FindIn(vehicles, parameter);
            if (item != null)
            {
                return GetVehicleInfo(item as Vehicle);
            }

            var stages = _jsonReaderService.ReadAllStages();
            item = _infoSearchService.FindIn(stages, parameter);
            if (item != null)
            {
                return GetStageInfo(item as Stage);
            }

            return "Couldn't find such vehicle or stage";
        }

        private string GetVehicleInfo(Vehicle vehicle)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{vehicle.Emoji} **{vehicle.Name}**");
            if (vehicle.Name.ToLower() == "garage")
            {
                sb.AppendLine($"Purchase cost: 300 gems");
                sb.AppendLine($"Upgrade cost: Random");
                sb.AppendLine($"Total cost (Purchase + Upgrade): Random");
            }
            else
            {
                sb.AppendLine(vehicle.PurchaseCost == 0
                    ? "Purchase cost: Free"
                    : $"Purchase cost: {vehicle.PurchaseCost:n0}");
                sb.AppendLine($"Upgrade cost: {vehicle.UpgradeCost:n0}");
                sb.AppendLine($"Total cost (Purchase + Upgrade): {(vehicle.PurchaseCost + vehicle.UpgradeCost):n0}");
            }
            sb.AppendLine($"Fuel duration: {vehicle.FuelDuration}");

            return sb.ToString();
        }

        private string GetStageInfo(Stage stage)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"**{stage.Name}**");
            sb.AppendLine(stage.PurchaseCost == 0
                ? "Purchase cost: Free"
                : $"Purchase cost: {stage.PurchaseCost:n0}");
            sb.AppendLine($"Fuel locations: coming soon...");

            return sb.ToString();
        }
    }
}
