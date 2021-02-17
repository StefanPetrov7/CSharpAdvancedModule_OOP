using System;

using Football_Team_Generator.Core;

namespace Football_Team_Generator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
