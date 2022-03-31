using System;
using System.Collections.Generic;
using Military_Elite.Contracts;
using Military_Elite.Models;
using System.Linq;

namespace Military_Elite.Factories
{
    static class LeutenantGeneralFactory
    {
        public static ILieutenantGeneral CreateLeutenantGeneral(string[] arg, ICollection<ISoldier> @privates)
        {
            string id = arg[0];
            string firstName = arg[1];
            string lastName = arg[2];
            decimal salary = decimal.Parse(arg[3]);
            string[] privateId = arg.Skip(4).ToArray();
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            if (privates.Count > 0)
            {
                foreach (var info in privateId)
                {
                    ISoldier @private = @privates.FirstOrDefault(x => x.Id == info);

                    if (@private is IPrivate && @private != null)
                    {
                        lieutenantGeneral.AddPrivate((Private)@private);
                    }
                }
            }

            return lieutenantGeneral;

        }
    }
}
