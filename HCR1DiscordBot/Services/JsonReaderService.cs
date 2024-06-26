﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCR1DiscordBot.Models;
using Newtonsoft.Json;

namespace HCR1DiscordBot.Services
{
    public class JsonReaderService
    {
        public string VehiclesFilePath { get; private set; }
        public string StagesFilePath { get; private set; }

        public JsonReaderService(string vehiclesFilePath, string stagesFilePath)
        {
            VehiclesFilePath = vehiclesFilePath;
            StagesFilePath = stagesFilePath;
        }

        public Vehicle[] ReadAllVehicles()
        {
            var serializer = new JsonSerializer();
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var streamReader = new StreamReader(VehiclesFilePath))
            using (var textReader = new JsonTextReader(streamReader))
            {
                vehicles = serializer.Deserialize<List<Vehicle>>(textReader);
            }
            return vehicles.ToArray();
        }

        public Stage[] ReadAllStages(bool excludeMissions = false)
        {
            var serializer = new JsonSerializer();
            List<Stage> stages = new List<Stage>();
            using (var streamReader = new StreamReader(StagesFilePath))
            using (var textReader = new JsonTextReader(streamReader))
            {
                stages = serializer.Deserialize<List<Stage>>(textReader);
            }
            if (excludeMissions)
            {
                stages?.Remove(stages?.FirstOrDefault(s => s.Name.ToLower() == "suburbs"));
                stages?.Remove(stages?.FirstOrDefault(s => s.Name.ToLower() == "retro mission"));
                stages?.Remove(stages?.FirstOrDefault(s => s.Name.ToLower() == "space mission"));
            }
            return stages.ToArray();
        }
    }
}
