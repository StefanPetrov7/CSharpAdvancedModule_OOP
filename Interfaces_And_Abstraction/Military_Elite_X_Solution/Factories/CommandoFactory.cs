using System;
using System.Linq;
using Military_Elite.Contracts;
using Military_Elite.Models;

namespace Military_Elite.Factories
{
    static class CommandoFactory
    {
        public static ICommando CreateCommando(params string[] arg)
        {
            string id = arg[0];
            string firstName = arg[1];
            string lastName = arg[2];
            decimal salary = decimal.Parse(arg[3]);
            string strCorps = arg[4];
            string[] missions = arg.Skip(5).ToArray();
            ICommando comando = new Commando(id, firstName, lastName, salary, strCorps, missions);
            return comando;
        }
    }
}
