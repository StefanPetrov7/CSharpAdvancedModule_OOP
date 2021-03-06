using System;
using Practice.Contracts;
using Practice.Models;

namespace Practice.Factories
{
    public class PrivateFactory
    {
        public IPrivate CreatePrivate(string[] args)
        {
            string id = args[1];
            string firstName = args[2];
            string lastName = args[3];
            decimal salary = decimal.Parse(args[4]);
            IPrivate @private = new Private(id, firstName, lastName, salary);
            return @private;
        }
    }
}
