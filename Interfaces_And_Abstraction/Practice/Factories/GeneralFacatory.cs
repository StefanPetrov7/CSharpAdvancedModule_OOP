using System;
using System.Linq;
using System.Collections.Generic;
using Practice.Models;
using Practice.Contracts;

namespace Practice.Factories
{
    public class GeneralFacatory
    {
        public ILieutenantGeneral CreateLieutenantGeneral(string[] args, ICollection<ISoldier> soldiers)
        {
            string id = args[1];
            string firstName = args[2];
            string lastName = args[3];
            decimal salary = decimal.Parse(args[4]);
            string[] privateId = args.Skip(5).ToArray();

            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var soldier in soldiers)
            {
                if (privateId.Contains(soldier.Id))
                {
                    lieutenantGeneral.AddPrivate((IPrivate)soldier);
                }
            }

            return lieutenantGeneral;
        }
    }
}
