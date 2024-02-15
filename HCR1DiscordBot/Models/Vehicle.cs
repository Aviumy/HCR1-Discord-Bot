﻿namespace HCR1DiscordBot.Models
{
    internal class Vehicle
    {
        public string Name { get; set; }
        public float FuelDuration { get; set; }
        public int PurchaseCost { get; set; }
        public int UpgradeCost { get; set; }
        public string Emoji { get; set; }
        public string[] Aliases { get; set; }
    }
}