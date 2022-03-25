using System;
using Animals.Core;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();

            try
            {
                engine.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
