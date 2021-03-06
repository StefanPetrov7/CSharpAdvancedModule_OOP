using System;
using System.Linq;
using Practice.Contracts;
using Practice.Models;

namespace Practice.Factories
{
    public class EngineerFactory
    {

        public IEngineer CreateEngineer(string[] args)
        {
            string id = args[1];
            string firstName = args[2];
            string lastName = args[3];
            decimal salary = decimal.Parse(args[4]);
            string corpsStr = args[5];
            string[] repairInfo = args.Skip(6).ToArray();
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corpsStr);

            if (repairInfo.Length != 0)
            {
                for (int i = 0; i < repairInfo.Length; i += 2)
                {
                    string partName = repairInfo[i];
                    int hrWorked = int.Parse(repairInfo[i + 1]);

                    try
                    {
                        IRepair repair = new Repair(partName, hrWorked);
                        engineer.AddRepair(repair);
                    }
                    catch (Exception)
                    {

                    }
                }
            }

            return engineer;

        }
    }
}
