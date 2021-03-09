using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    [Author("Stefan")]
    public class StartUp
    {
        [Author("LuBinBin")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }

    public class Tracker
    {

        public BindingFlags BlindFlag { get; private set; }

        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            foreach (var item in methods)
            {
                if (item.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = item.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine($"{item.Name} {attr.Name}");
                    }
                }
            }
        }
    }
}
