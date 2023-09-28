using Pizza_Calories.Core;

namespace Pizza_Calories;

public class StartUp
{
    static void Main(string[] args)
    {
        // 92 in Judge :(

        Engine engine = new Engine();
        engine.MakePizza();
    }
}

