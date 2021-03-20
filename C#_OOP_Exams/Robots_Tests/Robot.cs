using System;
namespace Robots
{
    public class Robot
    {
        public Robot(string name, int maxBattery)
        {
            this.Name = name;
            this.MaximumBattery = maxBattery;
            this.Battery = maxBattery;
        }

        public string Name { get; set; }

        public int Battery { get; set; }

        public int MaximumBattery { get;  }

    }
}

