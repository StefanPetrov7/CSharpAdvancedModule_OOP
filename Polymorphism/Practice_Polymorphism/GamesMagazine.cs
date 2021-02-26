using System;
using System.Collections.Generic;

namespace Practice_Polymorphism
{
    public class GamesMagazine
    {
        private List<Game> games;  // Encapsulation => games are vissible inly in this class.

        public GamesMagazine()
        {
            this.games = new List<Game>();
        }

        public void AddGame(Game game) // Polymorphsm => game take many forms: Tennis, Chess, Football and uses game as a base class. 
        {                              // During compliation is the refered object => Tennis, Chess, Foootbal.
            this.games.Add(game);
        }

        public void StartGame()
        {
            foreach (var game in this.games)
            {
                game.Start();
            }
        }

        public void StopGame()
        {
            foreach (var game in this.games)
            {
                game.Stop();
            }
        }

        public void PrintDiscriptions()
        {
            foreach (var game in this.games)
            {
                if (game is Tennis) // Not good practice!!!!  
                {
                    Console.WriteLine(((Tennis)game).IsNoGoodPolymorphsm());
                }

                if (game is Chess) // Not good practice!!!!  
                {
                    Console.WriteLine(((Chess)game).NoGoodChessPolymorphs());
                }

                Console.WriteLine(game.GetDiscription());
            }
        }
    }
}
