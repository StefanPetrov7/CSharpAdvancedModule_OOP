using System;
using Practice.Contracts;
using Practice.Models;

namespace Practice.Factories
{
    public class SpyFactory
    {
        public ISpy CreateSpy(string[] args)
        {
            string id = args[1];
            string firstName = args[2];
            string lastName = args[3];
            int code = int.Parse(args[4]);
            ISpy spy = new Spy(id, firstName, lastName, code);
            return spy;
        }
    }
}
