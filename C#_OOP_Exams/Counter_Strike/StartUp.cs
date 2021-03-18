using Counter_Strike.Core;
using Counter_Strike.Core.Contracts;

namespace Counter_Strike
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
