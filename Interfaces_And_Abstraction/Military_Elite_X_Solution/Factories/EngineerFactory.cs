using System;
using System.Linq;
using Military_Elite.Contracts;
using Military_Elite.Models;

namespace Military_Elite.Factories
{
    static class EngineerFactory
    {
        public static IEngineer CreateEngineer(params string[] arg)
        {
            string id = arg[0];
            string firstName = arg[1];
            string lastName = arg[2];
            decimal salary = decimal.Parse(arg[3]);
            string strCorps = arg[4];
            string[] repairs = arg.Skip(5).ToArray();
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, strCorps, repairs);
            return engineer;
        }
    }
}
