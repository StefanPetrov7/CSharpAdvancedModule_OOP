using System;
using System.Collections.Generic;

namespace Practice_Polymorphism
{
    public class FoodBallGame : Game
    {
        private List<Player> team; // Encapsulation => games are vissible only in this class.

        public FoodBallGame()
        {
            this.team = new List<Player>();
        }

        public override string GetDiscription() // Abstract implementation in the iherited classes.
        {
            return "The team is great";
        }

        public override void Start()
        {
            base.Start();
            Console.WriteLine("F Start");
        }

        public override void Stop()
        {
            base.Stop();
            Console.WriteLine("F finish");
        }
    }
}
