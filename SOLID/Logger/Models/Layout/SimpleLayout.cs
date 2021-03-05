using System;
using ExLogger.Models.Contracts;

namespace ExLogger.Models.Layout
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
