using System;
using Counter_Strike.Models.Guns.Contracts;
using Counter_Strike.Utilities.Messages;

namespace Counter_Strike.Repositories
{
    public class GunRepository : Repository<IGun>
    {
        protected override Func<IGun, bool> FindByNameDeligate(string name)
        {
            return x => x.Name == name;
        }

        protected override string GetNullModelValidationMessage()
        {
            return ExceptionMessages.InvalidGunRepository;
        }
    }
}
