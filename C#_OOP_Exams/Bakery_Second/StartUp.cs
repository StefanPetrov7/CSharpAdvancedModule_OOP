using System;

namespace Bakery
{
    using Bakery.Core;
    using Bakery.Models.Tables;
    using Bakery.Models.Tables.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            var engine = new Engine();

            engine.Run();
        }
    }
}
