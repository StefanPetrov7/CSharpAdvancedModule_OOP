namespace AquaShop
{
    using System;

    using AquaShop.Core;
    using AquaShop.Core.Contracts;
    using AquaShop.Models.Aquariums;

    public class StartUp
    {
        public static void Main()
        {

            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
