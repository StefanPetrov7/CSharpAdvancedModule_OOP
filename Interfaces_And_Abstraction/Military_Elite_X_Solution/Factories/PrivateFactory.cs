using System;
using Military_Elite.Contracts;
using Military_Elite.Models;

namespace Military_Elite.Factories
{
    static class PrivateFactory
    {
        public static IPrivate CreatePrivate(params string[] arg)
        {
            string id = arg[0];
            string firstName = arg[1];
            string lastName = arg[2];
            decimal salary = decimal.Parse(arg[3]);
            IPrivate @private = new Private(id, firstName, lastName, salary);
            return @private;
        }
    }
}
