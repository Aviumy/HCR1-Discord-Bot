using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCR1DiscordBot.Models;
using Newtonsoft.Json;

namespace HCR1DiscordBot.Services
{
    internal class JsonReaderService
    {
        public Vehicle[] ReadAllVehicles()
        {
            var serializer = new JsonSerializer();
            List<Vehicle> vehicles = new List<Vehicle>();
            using (var streamReader = new StreamReader("_vehicles.json"))
            using (var textReader = new JsonTextReader(streamReader))
            {
                vehicles = serializer.Deserialize<List<Vehicle>>(textReader);
            }
            return vehicles.ToArray();
        }

        public Stage[] ReadAllStages()
        {
            var serializer = new JsonSerializer();
            List<Stage> stages = new List<Stage>();
            using (var streamReader = new StreamReader("_stages.json"))
            using (var textReader = new JsonTextReader(streamReader))
            {
                stages = serializer.Deserialize<List<Stage>>(textReader);
            }
            return stages.ToArray();
        }
    }
}
