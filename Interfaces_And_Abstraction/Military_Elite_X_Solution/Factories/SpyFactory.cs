using System;
using Military_Elite.Contracts;
using Military_Elite.Models;

namespace Military_Elite.Factories
{
    static class SpyFactory
    {
        public static ISpy CreateSpy(params string[] arg)
        {
            string id = arg[0];
            string firstName = arg[1];
            string lastName = arg[2];
            string code = arg[3];
            ISpy spy = new Spy(id, firstName, lastName, code);
            return spy;
        }
    }
}
