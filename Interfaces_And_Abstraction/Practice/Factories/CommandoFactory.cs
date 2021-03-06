using System;
using System.Linq;
using Practice.Contracts;
using Practice.Models;

namespace Practice.Factories
{
    public class CommandoFactory
    {

        public ICommando CreateCommando(string[] args)
        {
            string id = args[1];
            string firstName = args[2];
            string lastName = args[3];
            decimal salary = decimal.Parse(args[4]);
            string corpsStr = args[5];
            string[] missionInfo = args.Skip(6).ToArray();
            ICommando commando = new Commando(id, firstName, lastName, salary, corpsStr);

            if (missionInfo.Length != 0)
            {
                for (int i = 0; i < missionInfo.Length; i += 2)
                {
                    string codeName = missionInfo[i];
                    string status = missionInfo[i + 1];
                    try
                    {
                        Mission mission = new Mission(codeName, status);
                        commando.AddMission(mission);
                    }
                    catch (Exception)
                    {
                        
                    }
                   
                }
            }

            return commando;

        }
    }
}
