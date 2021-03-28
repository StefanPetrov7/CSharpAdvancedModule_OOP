using System;
using Logger_Exercise.Layouts.Contracts;

namespace Logger_Exercise.Layouts
{
    public class SimpleLayout : ILayout
    {
        public SimpleLayout()
        { }

        public string Template => "{0} - {1} - {2}";
    }
}
